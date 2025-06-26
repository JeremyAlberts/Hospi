using Hopsi.Infrastructure;
using Hospi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Hopsi.Api.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Hopsi.Api.Interfaces;
using Hospi.Core.Interfaces.Services;
using Hopsi.Api.Core;
using Hospi.Core.Interfaces;
using Hospi.Core.Services;
using Hopsi.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HospiDbContext>(optionsAction =>
    optionsAction.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<HospiDbContext>();

//builder.Services.AddSwaggerSecurity();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddScoped<IRepository<House>, Repository<House>>();
builder.Services.AddScoped<IHouseService, HouseService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

var jwtConfiguration = builder.Configuration.GetSection(nameof(JwtOptions));
builder.Services.Configure<JwtOptions>(jwtConfiguration);

var jwtOptions = jwtConfiguration.Get<JwtOptions>();

builder.Services.AddAuthentication(cfg => {
    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x => {
        x.RequireHttpsMetadata = false;
        x.SaveToken = false;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8
                .GetBytes(jwtOptions.SecretKey)
            ),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<HospiDbContext>();

    var roleManger = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

    var roles = new[] { "Admin", "PaidUser", "FreeUser"  };

    foreach (var role in roles)
    {
        if (!await roleManger.RoleExistsAsync(role))
            await roleManger.CreateAsync(new IdentityRole<Guid>(role));
    }
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

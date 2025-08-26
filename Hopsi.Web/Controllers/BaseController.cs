using Hopsi.Api.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hopsi.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected Guid UserId => User.GetUserId();
        protected string UserIdAsString => User.GetUserIdAsString();
        protected ClaimsPrincipal CurrentUser => User;
    }
}

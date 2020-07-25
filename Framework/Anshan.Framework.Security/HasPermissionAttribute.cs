using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Anshan.Framework.Security
{
    [AttributeUsage(AttributeTargets.All)]
    public class HasPermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly MallPermissions _permission;

        public HasPermissionAttribute(MallPermissions permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (ShouldIgnorePermission())
                return;

            var identity = GetClaimsIdentity(context);

            if (IsAdmin(identity))
                return;

            SetForbiddenResult(context);
        }

        private static void SetForbiddenResult(AuthorizationFilterContext context)
        {
            context.Result = new ForbidResult();
        }

        private static bool IsAdmin(IEnumerable<Claim> claims)
        {
            var isAdmin = claims.Any(c => c.Type == "role" && c.Value == MallRoles.Admin);
            return isAdmin;
        }   

        private bool ShouldIgnorePermission()
        {
            return _permission == MallPermissions.AllowAnonymous;
        }

        private static IEnumerable<Claim> GetClaimsIdentity(AuthorizationFilterContext context)
        {
            return context.HttpContext.User.Claims;
        }
    }
}
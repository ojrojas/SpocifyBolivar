
namespace Identity.Api.Endpoints;

public static class ApplicationUserGroupRoute
{
    public static RouteGroupBuilder AddApplicationUserGroupRoute(this RouteGroupBuilder group)
    {
        GetUserInfo(group);
        return group;
    }

    private static void GetUserInfo(RouteGroupBuilder group)
    {
        group.MapGet("getinfouser", [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async (HttpContext _context) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
             throw new InvalidOperationException("Error request opration not found a valid request open iddict");

            return new ApplicationUser
            {
                Name = result.Principal.FindFirst(x => x.Type == Claims.Name).Value
            };
        });
    }
}


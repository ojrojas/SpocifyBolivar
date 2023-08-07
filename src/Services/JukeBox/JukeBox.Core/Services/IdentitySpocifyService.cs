namespace JukeBox.Core.Services;

public class IdentitySpocifyService : IIdentitySpocifyService
{
    private readonly ILoggingApplication<IdentitySpocifyService> _logger;

    public IdentitySpocifyService(ILoggingApplication<IdentitySpocifyService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public SpocifyIdentity GetSpocifyIdentity(ClaimsPrincipal principal)
    {

        _logger.LogInformation("Get identity from claims request");
        var identitySpocify = new SpocifyIdentity
        {
            Id = principal.Claims.FirstOrDefault(x => x.Type == "sub").Value,
            FullName = principal.Claims.FirstOrDefault(x => x.Type == "name").Value,
            Token = principal.Claims.FirstOrDefault(x => x.Type == "TokenSpocify").Value,
            Code = principal.Claims.FirstOrDefault(x => x.Type == "CodeSpocify").Value,
            RefreshToken = principal.Claims.FirstOrDefault(x => x.Type == "RefreshTokenSpocify").Value
        };

        return identitySpocify;
    }
}
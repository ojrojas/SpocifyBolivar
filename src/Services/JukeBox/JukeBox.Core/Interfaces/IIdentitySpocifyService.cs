namespace JukeBox.Core.Interfaces;

public interface IIdentitySpocifyService
{
    SpocifyIdentity GetSpocifyIdentity(ClaimsPrincipal principal);
}
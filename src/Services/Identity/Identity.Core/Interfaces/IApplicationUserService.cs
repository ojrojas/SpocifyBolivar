namespace Identity.Core.Interfaces;

public interface IApplicationUserService
{
    ValueTask<IResult> LoginAsync(LoginApplicationUserRequest request, CancellationToken cancellationToken);
}


namespace Identity.Core.Dtos;

public record CreateApplicationUserRequest: BaseRequest
{
    public ApplicationUser ApplicationUser { set; get; }
}

public record CreateApplicationUserResponse: BaseResponse
{
    public CreateApplicationUserResponse(Guid correlationId): base(correlationId) { }
    public ApplicationUser ApplicationUserCreated { get; set; }
}

public record UpdateApplicationUserRequest: BaseRequest
{
    public ApplicationUser ApplicationUser { get; set; }
}

public record UpdateApplicationUserResponse: BaseResponse
{
    public UpdateApplicationUserResponse(Guid correlationId): base(correlationId) { }
    public ApplicationUser ApplicationUpdated { get; set; }
}

public record DeleteApplicationUserRequest: BaseRequest
{
    public Guid Id { get; set; }
}

public record DeleteApplicationUserResponse: BaseResponse
{
    public DeleteApplicationUserResponse(Guid correlationId): base(correlationId) { }
    public bool IsDeleteApplicationUser { get; set; }
}

public record LoginApplicationUserRequest : BaseRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ClientId { get; set; }
    public IEnumerable<string> Scopes { get; set; }
}

public record LoginApplicationUserResponse : BaseResponse
{
    public LoginApplicationUserResponse(Guid correlationId): base(correlationId)  { }
    public string Token { get; set; }
    public IResult ActionResult { get; set; } = null!;
}
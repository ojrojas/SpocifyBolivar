namespace Identity.Api.Exceptions;

public class IdentityApplicationException : Exception
{
    public IdentityApplicationException()
    {
    }

    public IdentityApplicationException(string? message) : base(message)
    {
    }

    public IdentityApplicationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected IdentityApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}


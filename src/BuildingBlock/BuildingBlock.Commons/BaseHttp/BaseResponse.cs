namespace BuildingBlock.Commons.BaseHttp;

public record BaseResponse: BaseMessage
	{
    public BaseResponse(Guid correlationId) : base()
    {
        _correlationId = correlationId;
    }
}


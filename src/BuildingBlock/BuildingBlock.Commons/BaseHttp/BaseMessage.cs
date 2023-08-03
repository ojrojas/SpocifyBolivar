namespace BuildingBlock.Commons.BaseHttp;

public record BaseMessage
{
    protected Guid _correlationId = Guid.NewGuid();
    public Guid CorrelationId() => _correlationId;
}


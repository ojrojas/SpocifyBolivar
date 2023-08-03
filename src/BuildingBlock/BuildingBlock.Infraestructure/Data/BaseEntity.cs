namespace BuildingBlock.Infraestructure.Data;

public class BaseEntity
{
    public string Id { get; set; }
    public BaseEntityState State { get; set; }
    public DateTimeOffset CreateOn { get; set; }
    public DateTimeOffset UpdateOn { get; set; }
}

public enum BaseEntityState
{
    Inactive=0,
    Active=1,
    Cancelled=2
}
namespace Identity.Core.Entities;

public class ApplicationUser : IdentityUser, IAggregateRoot
{
    [Required] public string? Name { get; set; }
    public string? MiddleName { get; set; }
    [Required] public string? LastName { get; set; }
    public string? SurName { get; set; }
    [Required] public DateTime BirthDate { get; set; }
    [Required] public string? Address { get; set; }
    [Required] public string? Contact { get; set; }
}


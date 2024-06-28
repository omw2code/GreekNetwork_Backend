namespace Network.Api.Entites;

public class Profile
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string Name { get; set; }
    public string? ProfilePicture { get; set; }
    public required string School { get; set; }
    public required string Major { get; set; }
    public required string Minor { get; set; }
    public required bool AlumniStatus { get; set; }
    public required int OrganinizationId { get; set; }
    public Organization? Organization { get; set; }
    public int BadgeNum { get; set; }

}

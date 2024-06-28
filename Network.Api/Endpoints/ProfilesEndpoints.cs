using Network.Api.Dtos;

namespace Network.Api.Endpoints;

public static class ProfilesEndpoints
{
    const string GetProfile = "GetProfile";

    private static readonly List<ProfileDto> profiles = [
        new ProfileDto(
            Id: 1,
            Email: "john.doe@example.com",
            Name: "John Doe",
            ProfilePicture: "john_doe.jpg",
            School: "Example University",
            Major: "Computer Science",
            Minor: "Mathematics",
            AlumniStatus: true,
            Organization: "Tech Club",
            BadgeNum: 101
        ),
        new ProfileDto(
            Id: 2,
            Email: "jane.smith@example.com",
            Name: "Jane Smith",
            ProfilePicture: "jane_smith.jpg",
            School: "Example University",
            Major: "Biology",
            Minor: "Chemistry",
            AlumniStatus: false,
            Organization: "Bio Club",
            BadgeNum: 102
        ),
        new ProfileDto(
            Id: 3,
            Email: "alice.johnson@example.com",
            Name: "Alice Johnson",
            ProfilePicture: "alice_johnson.jpg",
            School: "Example University",
            Major: "Physics",
            Minor: "Astronomy",
            AlumniStatus: true,
            Organization: "Physics Club",
            BadgeNum: 103
        ),
        new ProfileDto(
            Id: 4,
            Email: "bob.brown@example.com",
            Name: "Bob Brown",
            ProfilePicture: "bob_brown.jpg",
            School: "Example University",
            Major: "Economics",
            Minor: "Statistics",
            AlumniStatus: false,
            Organization: "Econ Club",
            BadgeNum: 104
        ),
        new ProfileDto(
            Id: 5,
            Email: "carol.wilson@example.com",
            Name: "Carol Wilson",
            ProfilePicture: "carol_wilson.jpg",
            School: "Example University",
            Major: "History",
            Minor: "Political Science",
            AlumniStatus: true,
            Organization: "History Club",
            BadgeNum: 105
        )
    ];

    // Extensions
    public static RouteGroupBuilder MapGamesEndPoints(this WebApplication app)
    {

        var group = app.MapGroup("profiles")
                       .WithParameterValidation();
        // GET /profiles
        group.MapGet("/", () => profiles);

        // GET /profiles/1 (specific id)
        group.MapGet("/{id}", (int id) => 
        {
            ProfileDto? profile = profiles.Find(profile => profile.Id == id);

            return profile is null ? Results.NotFound() : Results.Ok(profile);
        })
        .WithName(GetProfile);

        // POST /profiles
        group.MapPost("/", (CreateProfileDto newProfile) =>
        {
            ProfileDto profile = new(
                profiles.Count() + 1,
                newProfile.Email,
                newProfile.Name,
                newProfile.ProfilePicture,
                newProfile.School,
                newProfile.Major,
                newProfile.Minor,
                newProfile.AlumniStatus,
                newProfile.Organization,
                newProfile.BadgeNum 
            );

            profiles.Add(profile);

            return Results.CreatedAtRoute(GetProfile, new { id = profile.Id }, profile);
        });

        // PUT /Profile/1

        group.MapPut("/{id}", (int id, UpdateProfileDto updatedProfile) => 
        {
            var index = profiles.FindIndex(profile => profile.Id == id);

            if(index == - 1) {
                return Results.NotFound();
            }

            profiles[index] = new ProfileDto( 
                id,
                updatedProfile.Email,
                updatedProfile.Name,
                updatedProfile.ProfilePicture,
                updatedProfile.School,
                updatedProfile.Major,
                updatedProfile.Minor,
                updatedProfile.AlumniStatus,
                updatedProfile.Organization,
                updatedProfile.BadgeNum
            );

            return Results.NoContent();

        });

        // DELETE /profiles/id

        group.MapDelete("/{id}", (int id) => 
        {
            //TODO: ensure that if a profile is deleted, the Id's are updated
            //bc creating a new profile goes by the number of existing profiles
            profiles.RemoveAll(profile => profile.Id == id);

            return Results.NoContent();
        });

        return group;
    }
}

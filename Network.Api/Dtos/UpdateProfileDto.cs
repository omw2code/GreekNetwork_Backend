using System.ComponentModel.DataAnnotations;

namespace Network.Api.Dtos;

public record class UpdateProfileDto(
    [Required][StringLength(50)]      string      Email, 
    [Required][StringLength(50)]      string      Name, 
                                      string      ProfilePicture, 
    [Required][StringLength(50)]      string      School,
    [Required][StringLength(50)]      string      Major,
    [Required][StringLength(50)]      string      Minor,
    [Required]                        bool        AlumniStatus,
    [Required][StringLength(50)]      string      Organization,
    [Range(1, 100000)]                int         BadgeNum);

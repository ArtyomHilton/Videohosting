using Videohosting.Domain.Entities.Base;

namespace Videohosting.Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Channel Channel { get; set; } = null!;
    public ICollection<Video> Videos { get; set; } = new List<Video>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
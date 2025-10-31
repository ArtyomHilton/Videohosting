using Videohosting.Domain.Entities.Base;

namespace Videohosting.Domain.Entities;

public class Channel : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<Video> Videos = new List<Video>();
}
using Videohosting.Domain.Entities.Base;

namespace Videohosting.Domain.Entities;
public class Video : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid ChannelId { get; set; }
    public Channel Channel = null!;
    public string Url { get; set; } = null!;
    public ICollection<VideoTag> VideoTags { get; set; } = new List<VideoTag>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
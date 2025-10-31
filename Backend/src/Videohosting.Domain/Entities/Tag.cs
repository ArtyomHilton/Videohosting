using Videohosting.Domain.Entities.Base;

namespace Videohosting.Domain.Entities;

public class Tag : BaseEntity
{
    public string Name { get; set; } = null!;
    public ICollection<VideoTag> VideoTags { get; set; } = new List<VideoTag>();
}
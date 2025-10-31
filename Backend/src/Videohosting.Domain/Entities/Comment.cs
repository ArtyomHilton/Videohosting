using Videohosting.Domain.Entities.Base;

namespace Videohosting.Domain.Entities;

public class Comment : BaseEntity
{
    public string Text { get; set; } = null!;
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid VideoId { get; set; }
    public Video Video { get; set; } = null!;
}
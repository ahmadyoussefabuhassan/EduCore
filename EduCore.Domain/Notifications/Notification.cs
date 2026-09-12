using EduCore.Domain.Abstractions;
using EduCore.Domain.Users;

namespace EduCore.Domain.Notifications
{
    public sealed class Notification : Entity
    {
        private Notification() : base(Guid.Empty)
        {
        }
        private Notification(Guid Id, Title title, Message message, bool isRead, DateTime createdAt, Guid userId) : base(Id)
        {
            Title = title;
            Message = message;
            IsRead = isRead;
            CreatedAt = createdAt;
            UserId = userId;
        }
        public Title Title { get; private set; }
        public Message Message { get; private set; }
        public bool IsRead { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; } = null!;
        public static Notification Create(Title title, Message message, Guid userId)
        {
            var notification = new Notification(Guid.NewGuid(), title, message, false, DateTime.UtcNow, userId);
            return notification;
        }
        public void MarkAsRead() => IsRead = true;
    }
}

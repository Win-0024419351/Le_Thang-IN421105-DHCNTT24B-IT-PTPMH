using EduHub.Ch02.Notifications;

namespace EduHub.Ch02.Patterns.Factory;

/// <summary>Factory: tạo INotificationService theo NotificationChannel, thay cho chuỗi if/else.</summary>
public class NotificationServiceFactory : INotificationServiceFactory
{
    public INotificationService Create(NotificationChannel channel) => channel switch
    {
        NotificationChannel.Email => new EmailNotificationService(),
        NotificationChannel.Sms   => new SmsNotificationService(),
        NotificationChannel.Slack => new SlackNotificationService(),
        _ => throw new ArgumentOutOfRangeException(nameof(channel), channel, "Unsupported channel")
    };
}
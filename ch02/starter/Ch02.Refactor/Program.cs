using EduHub.Ch02.Domain;
using EduHub.Ch02.Logging;
using EduHub.Ch02.Notifications;
using EduHub.Ch02.Patterns.Decorators;
using EduHub.Ch02.Patterns.Factory;
using EduHub.Ch02.Patterns.Observers;
using EduHub.Ch02.Patterns.Strategies;
using EduHub.Ch02.Repositories;
using EduHub.Ch02.Services;

// ═══════════════════════════════════════════════════════════════
//  Composition root: nơi DUY NHẤT dùng `new` lớp cụ thể.
//  Mọi class còn lại chỉ biết interface (DIP).
// ═══════════════════════════════════════════════════════════════

IAppLogger logger = new ConsoleLogger();

// Decorator: LoggingClubRepository bọc repository thật để ghi log mỗi lần truy cập
IClubRepository clubRepo = new LoggingClubRepository(new InMemoryClubRepository(), logger);
IMemberRepository memberRepo = new InMemoryMemberRepository();
IEventRepository eventRepo = new InMemoryEventRepository();

// Factory: tạo INotificationService theo NotificationChannel
INotificationServiceFactory notificationFactory = new NotificationServiceFactory();
INotificationService notifier = notificationFactory.Create(NotificationChannel.Email);

IClubService clubService = new ClubService(clubRepo, memberRepo, notifier, logger);
IEventService eventService = new EventService(clubRepo, memberRepo, eventRepo);
IReportService reportService = new ReportService(clubRepo, memberRepo, eventRepo);

// Observer: đăng ký các observer, khi tạo sự kiện sẽ tự được báo
eventService.Subscribe(new EmailNotifier(memberRepo, notifier));
eventService.Subscribe(new LogNotifier(logger));

// Demo: giống kịch bản cũ nhưng chạy qua các service mới
var club = clubService.CreateClub("Tech Club", "Câu lạc bộ công nghệ", "president@gmail.com");
clubService.AddMember(club.Id, "Nguyễn Văn A", "a@student.dthu.edu.vn");
eventService.CreateEvent(club.Id, "Workshop SOLID", new DateTime(2026, 11, 20));

// Strategy: cùng dữ liệu, hai cách định dạng
Console.WriteLine("\n--- Báo cáo Console ---");
Console.WriteLine(reportService.Generate(new ConsoleReportStrategy()));
Console.WriteLine("\n--- Báo cáo CSV ---");
Console.WriteLine(reportService.Generate(new CsvReportStrategy()));
# Phân tích vi phạm SOLID trong `ClubManager`

`ClubManager` là một "God class": một class ôm cả nghiệp vụ, ghi log, gửi thông báo, tạo sự kiện và in báo cáo. Dưới đây là 6 vi phạm, ghi theo số dòng trong `ClubManager.cs`.

---

## 1. SRP — method `CreateClub` làm quá nhiều việc

- **Vị trí:** dòng 34
- **Nguyên tắc vi phạm:** SRP (Single Responsibility Principle)
- **Biểu hiện:** một method làm 3 việc: kiểm tra hợp lệ (validate), lưu dữ liệu, gửi thông báo.
- **Hậu quả:** đổi luật kiểm tra, đổi nơi lưu hoặc đổi cách thông báo đều phải sửa chung một method. Dễ gây lỗi lan truyền, khó viết test riêng cho từng việc.

---

## 2. DIP — ghi file log trực tiếp

- **Vị trí:** dòng 47
- **Nguyên tắc vi phạm:** DIP (Dependency Inversion Principle)
- **Biểu hiện:** `ClubManager` ghi log thẳng vào file, không đi qua abstraction (interface).
- **Hậu quả:** class nghiệp vụ phụ thuộc vào cách ghi file cụ thể. Không thay được bằng logger khác (console, database), và khi test sẽ ghi ra file thật vì không thay được bằng bản giả.

---

## 3. OCP — gửi thông báo bằng cách sửa method

- **Vị trí:** dòng 50
- **Nguyên tắc vi phạm:** OCP (Open/Closed Principle)
- **Biểu hiện:** muốn thêm kênh SMS phải sửa chính method này.
- **Hậu quả:** mỗi lần thêm kênh mới (SMS, Slack, ...) là phải mở lại code đang chạy ổn định, có nguy cơ làm hỏng kênh cũ và phải test lại toàn bộ.

---

## 4. SRP — nghiệp vụ lẫn với gửi thông báo

- **Vị trí:** dòng 66
- **Nguyên tắc vi phạm:** SRP
- **Biểu hiện:** method này vừa xử lý nghiệp vụ vừa gửi thông báo.
- **Hậu quả:** logic nghiệp vụ bị trộn với việc thông báo, không thể test hoặc tái sử dụng phần nghiệp vụ mà không kéo theo việc gửi thông báo.

---

## 5. SRP + OCP — tạo sự kiện nhưng tự gửi thông báo cho từng thành viên

- **Vị trí:** dòng 86
- **Nguyên tắc vi phạm:** SRP và OCP
- **Biểu hiện:** method tạo sự kiện đồng thời tự lặp qua từng thành viên để gửi thông báo.
- **Hậu quả:** (SRP) việc "tạo sự kiện" và "báo cho mọi người" nằm chung một chỗ. (OCP) muốn thêm một nơi nhận khác (ghi log, gửi webhook) lại phải sửa method này, nên method ngày càng phình ra.

---

## 6. SRP + OCP — báo cáo trộn với nghiệp vụ

- **Vị trí:** dòng 101
- **Nguyên tắc vi phạm:** SRP và OCP
- **Biểu hiện:** logic in báo cáo (`PrintClubReport`) nằm lẫn trong class nghiệp vụ.
- **Hậu quả:** (SRP) class nghiệp vụ phải biết cả cách trình bày. (OCP) muốn xuất thêm CSV phải sửa chính method này, không đổi được định dạng lúc chạy.

---

## Bảng tổng hợp

| # | Dòng | Nguyên tắc | Cách khắc phục |
|---|---|---|---|
| 1 | 34 | SRP | Tách `ClubService` điều phối, luật hợp lệ chuyển vào `Club.Create` |
| 2 | 47 | DIP | Nhận `IAppLogger` qua constructor |
| 3 | 50 | OCP | Factory tạo `INotificationService` theo `NotificationChannel` |
| 4 | 66 | SRP | Tách việc thông báo sang `INotificationService` |
| 5 | 86 | SRP + OCP | `EventService` + Observer (`IEventObserver`) |
| 6 | 101 | SRP + OCP | `ReportService` + Strategy (`IReportStrategy`: Console, CSV) |
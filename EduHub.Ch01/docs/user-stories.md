# User Stories – Hệ thống quản lý Câu lạc bộ (CLB)

## 1. Actor: Sinh viên

### US01 – Đăng ký tham gia CLB
**User Story:**

As a sinh viên, I want to đăng ký tham gia CLB, so that tôi có thể trở thành thành viên của CLB mà mình yêu thích.

**Acceptance Criteria:**
- Given sinh viên đã đăng nhập, When sinh viên chọn CLB và gửi yêu cầu tham gia, Then hệ thống ghi nhận yêu cầu đăng ký.
- Given sinh viên đã gửi yêu cầu tham gia CLB, When sinh viên đăng ký lại cùng CLB, Then hệ thống thông báo đã gửi yêu cầu hoặc đã là thành viên.

### US02 – Đăng ký tham gia sự kiện
**User Story:**

As a sinh viên, I want to đăng ký tham gia sự kiện, so that tôi có thể tham gia các hoạt động do CLB tổ chức.

**Acceptance Criteria:**
- Given sự kiện đang mở đăng ký và còn chỗ, When sinh viên nhấn đăng ký, Then hệ thống ghi nhận đăng ký thành công.
- Given sự kiện đã hết hạn đăng ký hoặc hết chỗ, When sinh viên gửi yêu cầu đăng ký, Then hệ thống thông báo không thể đăng ký sự kiện.

### US03 – Check-in sự kiện
**User Story:**

As a sinh viên, I want to check-in khi tham gia sự kiện, so that hệ thống ghi nhận việc tham dự của tôi.

**Acceptance Criteria:**
- Given sinh viên đã đăng ký sự kiện hợp lệ, When sinh viên check-in trong thời gian cho phép, Then hệ thống ghi nhận thời gian tham dự.
- Given sinh viên chưa đăng ký sự kiện hoặc đã check-in trước đó, When sinh viên thực hiện check-in, Then hệ thống từ chối thao tác không hợp lệ và hiển thị thông báo phù hợp.

## 2. Actor: Ban CLB

### US04 – Tạo sự kiện
**User Story:**

As a ban CLB, I want to tạo sự kiện mới, so that tôi có thể tổ chức các hoạt động cho thành viên.

**Acceptance Criteria:**
- Given người dùng có quyền quản lý CLB, When người dùng nhập đầy đủ thông tin hợp lệ và tạo sự kiện, Then hệ thống lưu sự kiện thành công.
- Given thông tin sự kiện bị thiếu hoặc thời gian tổ chức không hợp lệ, When người dùng gửi biểu mẫu, Then hệ thống hiển thị lỗi và không tạo sự kiện.

### US05 – Xem danh sách thành viên
**User Story:**

As a ban CLB, I want to xem danh sách thành viên CLB, so that tôi có thể theo dõi và quản lý thành viên.

**Acceptance Criteria:**
- Given ban CLB đã đăng nhập và có quyền quản lý CLB, When người dùng mở mục thành viên, Then hệ thống hiển thị danh sách thành viên của CLB đó.
- Given ban CLB không có quyền truy cập CLB được yêu cầu, When người dùng mở danh sách thành viên của CLB đó, Then hệ thống từ chối truy cập.

### US06 – Xuất báo cáo
**User Story:**

As a ban CLB, I want to xuất báo cáo hoạt động của CLB, so that tôi có thể tổng hợp và theo dõi kết quả hoạt động.

**Acceptance Criteria:**
- Given ban CLB có quyền xem báo cáo, When người dùng chọn loại báo cáo và khoảng thời gian hợp lệ, Then hệ thống tạo báo cáo với dữ liệu tương ứng.
- Given dữ liệu báo cáo không có hoặc bộ lọc không hợp lệ, When người dùng yêu cầu xuất báo cáo, Then hệ thống thông báo phù hợp và không tạo báo cáo sai dữ liệu.

## 3. Actor: Admin

### US07 – Quản lý CLB
**User Story:**

As an admin, I want to quản lý thông tin các CLB, so that tôi có thể đảm bảo thông tin CLB trong hệ thống chính xác và đầy đủ.

**Acceptance Criteria:**
- Given admin đã đăng nhập, When admin tạo hoặc cập nhật CLB với thông tin hợp lệ, Then hệ thống lưu thông tin CLB thành công.
- Given admin nhập thiếu thông tin bắt buộc hoặc dữ liệu không hợp lệ, When admin lưu thông tin CLB, Then hệ thống hiển thị lỗi và không lưu dữ liệu sai.

### US08 – Phê duyệt thành viên
**User Story:**

As an admin, I want to phê duyệt yêu cầu tham gia CLB, so that tôi có thể kiểm soát việc tiếp nhận thành viên mới.

**Acceptance Criteria:**
- Given có yêu cầu tham gia CLB đang chờ xử lý, When admin phê duyệt yêu cầu, Then hệ thống cập nhật trạng thái yêu cầu thành đã được phê duyệt.
- Given yêu cầu đã được xử lý trước đó hoặc không tồn tại, When admin thực hiện phê duyệt, Then hệ thống thông báo yêu cầu không hợp lệ và không cập nhật sai trạng thái.
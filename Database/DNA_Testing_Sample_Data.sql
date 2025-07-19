-- =====================================================================================
-- DNA Testing Service Management System - Sample Data
-- Sample data insertion script for testing and development
-- =====================================================================================

USE DNATestingDB;
GO

-- =====================================================================================
-- 1. INSERT SAMPLE USERS
-- =====================================================================================

-- Insert Admin users
INSERT INTO Users (Username, Email, PasswordHash, FullName, Phone, Address, UserType, IsActive)
VALUES 
('admin', 'admin@dnatesting.com', 'hashedpassword123', N'Quản trị viên hệ thống', '0901000001', N'123 Đường ABC, Quận 1, TP.HCM', 'Admin', 1),
('manager1', 'manager1@dnatesting.com', 'hashedpassword123', N'Nguyễn Văn Quản', '0901000002', N'456 Đường DEF, Quận 3, TP.HCM', 'Manager', 1);

-- Insert Staff users
INSERT INTO Users (Username, Email, PasswordHash, FullName, Phone, Address, UserType, IsActive)
VALUES 
('staff1', 'staff1@dnatesting.com', 'hashedpassword123', N'Trần Thị Nhân', '0901000003', N'789 Đường GHI, Quận 5, TP.HCM', 'Staff', 1),
('staff2', 'staff2@dnatesting.com', 'hashedpassword123', N'Lê Văn Viên', '0901000004', N'321 Đường JKL, Quận 7, TP.HCM', 'Staff', 1),
('doctor1', 'doctor1@dnatesting.com', 'hashedpassword123', N'BS. Phạm Minh Tuấn', '0901000005', N'654 Đường MNO, Quận 2, TP.HCM', 'Staff', 1);

-- Insert Customer users
INSERT INTO Users (Username, Email, PasswordHash, FullName, Phone, Address, UserType, IsActive)
VALUES 
('customer1', 'hoa.nguyen@email.com', 'hashedpassword123', N'Nguyễn Thị Hoa', '0901234567', N'123 Đường Lê Lợi, Quận 1, TP.HCM', 'Customer', 1),
('customer2', 'nam.tran@email.com', 'hashedpassword123', N'Trần Văn Nam', '0912345678', N'456 Đường Nguyễn Huệ, Quận 3, TP.HCM', 'Customer', 1),
('customer3', 'lan.le@email.com', 'hashedpassword123', N'Lê Thị Lan', '0923456789', N'789 Đường Trần Hưng Đạo, Quận 5, TP.HCM', 'Customer', 1);

-- =====================================================================================
-- 2. INSERT SAMPLE PATIENTS
-- =====================================================================================

INSERT INTO Patients (UserId, FullName, DateOfBirth, Gender, Phone, Email, Address, MedicalHistory, EmergencyContact, EmergencyPhone, BloodType, IsActive)
VALUES 
(6, N'Nguyễn Thị Hoa', '1990-05-15', N'Nữ', '0901234567', 'hoa.nguyen@email.com', N'123 Đường Lê Lợi, Quận 1, TP.HCM', N'Không có tiền sử bệnh đặc biệt', N'Nguyễn Văn Tuấn', '0901234568', 'O+', 1),
(7, N'Trần Văn Nam', '1988-08-20', N'Nam', '0912345678', 'nam.tran@email.com', N'456 Đường Nguyễn Huệ, Quận 3, TP.HCM', N'Tiểu đường type 2', N'Trần Thị Mai', '0912345679', 'A+', 1),
(8, N'Lê Thị Lan', '1992-03-10', N'Nữ', '0923456789', 'lan.le@email.com', N'789 Đường Trần Hưng Đạo, Quận 5, TP.HCM', N'Dị ứng penicillin', N'Lê Văn Bình', '0923456790', 'B+', 1),
(NULL, N'Phạm Minh Đức', '1985-12-05', N'Nam', '0934567890', 'duc.pham@email.com', N'321 Đường Hai Bà Trưng, Quận 1, TP.HCM', N'Cao huyết áp', N'Phạm Thị Linh', '0934567891', 'AB+', 0),
(NULL, N'Hoàng Thị Mai', '1993-07-25', N'Nữ', '0945678901', 'mai.hoang@email.com', N'654 Đường Cách Mạng Tháng 8, Quận 10, TP.HCM', N'Không có', N'Hoàng Văn Tùng', '0945678902', 'O-', 1);

-- =====================================================================================
-- 3. INSERT DNA TEST SERVICES
-- =====================================================================================

INSERT INTO DNATestServices (ServiceCode, ServiceName, ServiceType, Description, Price, EstimatedDays, RequiresSample, AllowHomeSample, AllowClinicSample, IsActive)
VALUES 
('DNA001', N'Xét nghiệm ADN xác định huyết thống cha con', N'Dân sự', N'Xét nghiệm ADN để xác định mối quan hệ huyết thống giữa cha và con với độ chính xác 99.9%', 2500000, 7, 1, 1, 1, 1),
('DNA002', N'Xét nghiệm ADN xác định huyết thống mẹ con', N'Dân sự', N'Xét nghiệm ADN để xác định mối quan hệ huyết thống giữa mẹ và con', 2300000, 7, 1, 1, 1, 1),
('DNA003', N'Xét nghiệm ADN xác định huyết thống anh em', N'Dân sự', N'Xét nghiệm ADN để xác định mối quan hệ anh em ruột', 2800000, 10, 1, 1, 1, 1),
('DNA004', N'Xét nghiệm ADN pháp y', N'Hành chính', N'Xét nghiệm ADN cho mục đích pháp lý, có giá trị pháp lý', 3500000, 14, 1, 0, 1, 1),
('DNA005', N'Xét nghiệm ADN định danh cá nhân', N'Y tế', N'Xét nghiệm ADN để định danh cá nhân cho mục đích y tế', 2000000, 5, 1, 1, 1, 1),
('DNA006', N'Xét nghiệm ADN gia đình mở rộng', N'Dân sự', N'Xét nghiệm ADN để xác định quan hệ huyết thống trong gia đình mở rộng', 4000000, 14, 1, 1, 1, 1);

-- =====================================================================================
-- 4. INSERT DOCTORS
-- =====================================================================================

INSERT INTO Doctors (UserId, LicenseNumber, Specialization, Qualification, Experience, IsActive)
VALUES 
(5, 'BS123456', N'Bác sĩ Di truyền học', N'Tiến sĩ Y học - Chuyên ngành Di truyền học phân tử', 15, 1);

-- =====================================================================================
-- 5. INSERT DOCTOR SCHEDULES
-- =====================================================================================

INSERT INTO DoctorSchedules (DoctorId, DayOfWeek, StartTime, EndTime, IsAvailable, MaxAppointments)
VALUES 
(1, 1, '08:00', '17:00', 1, 8), -- Monday
(1, 2, '08:00', '17:00', 1, 8), -- Tuesday
(1, 3, '08:00', '17:00', 1, 8), -- Wednesday
(1, 4, '08:00', '17:00', 1, 8), -- Thursday
(1, 5, '08:00', '17:00', 1, 8), -- Friday
(1, 6, '08:00', '12:00', 1, 4); -- Saturday

-- =====================================================================================
-- 6. INSERT DNA TEST REGISTRATIONS
-- =====================================================================================

INSERT INTO DNATestRegistrations (PatientId, ServiceId, SampleCollectionMethod, Status, TotalCost, PaidAmount, PaymentStatus, Notes, ExpectedCompletionDate, CreatedBy, AssignedStaff)
VALUES 
(1, 1, N'Tại nhà', N'Hoàn thành', 2500000, 2500000, N'Đã thanh toán', N'Khách hàng yêu cầu thu mẫu tại nhà', '2025-07-10', 3, 3),
(2, 4, N'Tại cơ sở', N'Đang xét nghiệm', 3500000, 1750000, N'Đã cọc', N'Xét nghiệm pháp y theo yêu cầu tòa án', '2025-07-28', 3, 4),
(3, 2, N'Tự thu thập', N'Đã gửi kit', 2300000, 0, N'Chưa thanh toán', N'Gửi kit về địa chỉ khách hàng', '2025-07-26', 3, 3),
(4, 3, N'Tại cơ sở', N'Đã hủy', 2800000, 0, N'Chưa thanh toán', N'Khách hàng hủy do lý do cá nhân', NULL, 3, NULL),
(5, 5, N'Tại nhà', N'Đã thu mẫu', 2000000, 2000000, N'Đã thanh toán', N'Thu mẫu tại nhà thành công', '2025-07-24', 3, 4);

-- =====================================================================================
-- 7. INSERT SAMPLE COLLECTIONS
-- =====================================================================================

INSERT INTO SampleCollections (RegistrationId, CollectionMethod, CollectionDate, CollectorStaffId, SampleType, SampleQuality, SampleReceivedDate, Address, Status)
VALUES 
(1, N'Tại nhà', '2025-07-03', 3, N'Nước bọt', N'Tốt', '2025-07-03', N'123 Đường Lê Lợi, Quận 1, TP.HCM', N'Đã nhận mẫu'),
(2, N'Tại cơ sở', '2025-07-05', 4, N'Máu', N'Tốt', '2025-07-05', NULL, N'Đã nhận mẫu'),
(3, N'Tự thu thập', NULL, NULL, N'Nước bọt', NULL, NULL, N'789 Đường Trần Hưng Đạo, Quận 5, TP.HCM', N'Chờ thu thập'),
(5, N'Tại nhà', '2025-07-12', 4, N'Tóc', N'Tốt', '2025-07-12', N'654 Đường Cách Mạng Tháng 8, Quận 10, TP.HCM', N'Đã nhận mẫu');

-- =====================================================================================
-- 8. INSERT TEST PROGRESS
-- =====================================================================================

-- Progress for Registration 1 (Completed)
INSERT INTO TestProgress (RegistrationId, StepName, StepDescription, StepOrder, Status, StartDate, CompletedDate, PerformedBy)
VALUES 
(1, N'Thu thập mẫu', N'Thu thập mẫu nước bọt tại nhà khách hàng', 1, N'Hoàn thành', '2025-07-03 08:00', '2025-07-03 09:00', 3),
(1, N'Vận chuyển mẫu', N'Vận chuyển mẫu về phòng thí nghiệm', 2, N'Hoàn thành', '2025-07-03 09:00', '2025-07-03 10:00', 3),
(1, N'Chuẩn bị mẫu', N'Chuẩn bị và xử lý mẫu cho phân tích', 3, N'Hoàn thành', '2025-07-04 08:00', '2025-07-04 10:00', 4),
(1, N'Phân tích ADN', N'Tiến hành phân tích và so sánh ADN', 4, N'Hoàn thành', '2025-07-04 10:00', '2025-07-08 16:00', 5),
(1, N'Kiểm tra kết quả', N'Kiểm tra và xác nhận kết quả phân tích', 5, N'Hoàn thành', '2025-07-08 16:00', '2025-07-09 10:00', 5),
(1, N'Xuất báo cáo', N'Tạo báo cáo kết quả và gửi cho khách hàng', 6, N'Hoàn thành', '2025-07-09 10:00', '2025-07-10 09:00', 4);

-- Progress for Registration 2 (In Progress)
INSERT INTO TestProgress (RegistrationId, StepName, StepDescription, StepOrder, Status, StartDate, CompletedDate, PerformedBy)
VALUES 
(2, N'Thu thập mẫu', N'Thu thập mẫu máu tại cơ sở', 1, N'Hoàn thành', '2025-07-05 08:00', '2025-07-05 08:30', 4),
(2, N'Chuẩn bị mẫu', N'Chuẩn bị và xử lý mẫu cho phân tích', 2, N'Hoàn thành', '2025-07-05 08:30', '2025-07-05 10:00', 4),
(2, N'Phân tích ADN', N'Tiến hành phân tích và so sánh ADN', 3, N'Đang thực hiện', '2025-07-06 08:00', NULL, 5),
(2, N'Kiểm tra kết quả', N'Kiểm tra và xác nhận kết quả phân tích', 4, N'Chờ xử lý', NULL, NULL, NULL),
(2, N'Xuất báo cáo', N'Tạo báo cáo kết quả và gửi cho khách hàng', 5, N'Chờ xử lý', NULL, NULL, NULL);

-- =====================================================================================
-- 9. INSERT TEST RESULTS
-- =====================================================================================

INSERT INTO TestResults (RegistrationId, ResultType, ResultData, ResultSummary, Confidence, VerifiedBy, IsReleased, ReleasedDate, ReleasedBy)
VALUES 
(1, N'Final', N'{"paternity_index": 2500000, "probability": 99.99, "markers_tested": 23, "conclusion": "positive"}', 
 N'Kết quả xét nghiệm cho thấy xác suất để ông X là cha ruột của bé Y là 99.99%. Kết luận: ông X là cha ruột của bé Y.', 
 99.99, 5, 1, '2025-07-10 09:00', 4);

-- =====================================================================================
-- 10. INSERT APPOINTMENTS
-- =====================================================================================

INSERT INTO Appointments (PatientId, RegistrationId, AppointmentType, AppointmentDate, Duration, Status, AssignedStaff, Location, Notes)
VALUES 
(1, 1, N'Thu mẫu', '2025-07-03 08:00', 60, N'Hoàn thành', 3, N'Tại nhà khách hàng', N'Thu mẫu nước bọt thành công'),
(2, 2, N'Thu mẫu', '2025-07-05 08:00', 30, N'Hoàn thành', 4, N'Phòng khám ADN', N'Thu mẫu máu thành công'),
(3, NULL, N'Tư vấn', '2025-07-20 14:00', 30, N'Đã đặt', 5, N'Phòng tư vấn 1', N'Tư vấn về dịch vụ xét nghiệm ADN'),
(5, 5, N'Thu mẫu', '2025-07-12 09:00', 45, N'Hoàn thành', 4, N'Tại nhà khách hàng', N'Thu mẫu tóc thành công');

-- =====================================================================================
-- 11. INSERT PATIENT FEEDBACK
-- =====================================================================================

INSERT INTO PatientFeedback (PatientId, RegistrationId, ServiceId, Rating, FeedbackType, Title, Comment, IsPublic, IsVerified, ResponseFromStaff, ResponseDate, ResponseBy)
VALUES 
(1, 1, 1, 5, N'Dịch vụ', N'Dịch vụ tuyệt vời', N'Tôi rất hài lòng với dịch vụ của trung tâm. Nhân viên chuyên nghiệp, kết quả chính xác và nhanh chóng.', 1, 1, 
 N'Cảm ơn quý khách đã tin tưởng và sử dụng dịch vụ của chúng tôi. Chúng tôi luôn nỗ lực để mang lại dịch vụ tốt nhất.', '2025-07-11 10:00', 2),
(2, 2, 4, 4, N'Nhân viên', N'Nhân viên nhiệt tình', N'Nhân viên thu mẫu rất nhiệt tình và chu đáo, giải thích rõ ràng quy trình.', 1, 1, 
 N'Chúng tôi sẽ chuyển lời cảm ơn của quý khách đến nhân viên. Cảm ơn quý khách!', '2025-07-07 14:00', 2);

-- =====================================================================================
-- 12. INSERT NOTIFICATIONS
-- =====================================================================================

INSERT INTO Notifications (UserId, NotificationType, Title, Message, IsRead, SendMethod, RelatedEntityType, RelatedEntityId)
VALUES 
(6, N'Thông tin', N'Kết quả xét nghiệm đã sẵn sàng', N'Kết quả xét nghiệm ADN của quý khách đã sẵn sàng. Vui lòng đăng nhập để xem chi tiết.', 1, 'Email', 'Registration', 1),
(7, N'Nhắc nhở', N'Thanh toán phí xét nghiệm', N'Quý khách vui lòng hoàn tất thanh toán phí xét nghiệm ADN để chúng tôi tiếp tục quy trình phân tích.', 0, 'Email', 'Registration', 2),
(8, N'Thông tin', N'Kit xét nghiệm đã được gửi', N'Kit xét nghiệm ADN đã được gửi đến địa chỉ của quý khách. Vui lòng theo dõi hướng dẫn sử dụng.', 0, 'SMS', 'Registration', 3);

-- =====================================================================================
-- 13. INSERT BLOG POSTS
-- =====================================================================================

INSERT INTO BlogPosts (Title, Slug, Content, Summary, Category, Tags, AuthorId, Status, PublishedDate, ViewCount)
VALUES 
(N'Xét nghiệm ADN là gì? Tìm hiểu về công nghệ phân tích gen', 'xet-nghiem-adn-la-gi', 
 N'Xét nghiệm ADN (DNA) là phương pháp phân tích vật chất di truyền để xác định mối quan hệ huyết thống giữa các cá nhân...', 
 N'Tìm hiểu cơ bản về xét nghiệm ADN, quy trình và ý nghĩa của kết quả xét nghiệm.', 
 N'Kiến thức ADN', 'ADN, xét nghiệm, di truyền, huyết thống', 2, 'Published', '2025-07-01 10:00', 150),

(N'Hướng dẫn thu thập mẫu nước bọt tại nhà', 'huong-dan-thu-thap-mau-nuoc-bot', 
 N'Để đảm bảo chất lượng mẫu xét nghiệm, quý khách cần tuân thủ đúng quy trình thu thập mẫu...', 
 N'Hướng dẫn chi tiết cách thu thập mẫu nước bọt đúng cách tại nhà.', 
 N'Hướng dẫn', 'thu mẫu, nước bọt, hướng dẫn', 3, 'Published', '2025-06-28 14:00', 89),

(N'Độ chính xác của xét nghiệm ADN xác định cha con', 'do-chinh-xac-xet-nghiem-adn', 
 N'Xét nghiệm ADN hiện đại có thể đạt độ chính xác lên đến 99.99% trong việc xác định mối quan hệ cha con...', 
 N'Phân tích về độ chính xác và độ tin cậy của xét nghiệm ADN.', 
 N'Kiến thức ADN', 'độ chính xác, ADN, cha con', 5, 'Published', '2025-07-05 09:00', 234);

-- =====================================================================================
-- 14. INSERT SYSTEM SETTINGS
-- =====================================================================================

INSERT INTO SystemSettings (SettingKey, SettingValue, Description, Category, UpdatedBy)
VALUES 
('clinic_name', N'Trung tâm Xét nghiệm ADN Bloodline', N'Tên trung tâm', 'General', 1),
('clinic_address', N'123 Đường ABC, Quận 1, TP.HCM', N'Địa chỉ trung tâm', 'General', 1),
('clinic_phone', '0901000000', N'Số điện thoại liên hệ', 'General', 1),
('clinic_email', 'info@dnatesting.com', N'Email liên hệ', 'General', 1),
('working_hours', N'Thứ 2-6: 8:00-17:00, Thứ 7: 8:00-12:00', N'Giờ làm việc', 'General', 1),
('max_appointments_per_day', '50', N'Số lượng cuộc hẹn tối đa mỗi ngày', 'General', 1),
('default_test_duration', '7', N'Thời gian xét nghiệm mặc định (ngày)', 'General', 1),
('email_notification_enabled', 'true', N'Bật thông báo email', 'Email', 1),
('sms_notification_enabled', 'true', N'Bật thông báo SMS', 'SMS', 1);

-- =====================================================================================
-- 15. INSERT PROMOTIONS
-- =====================================================================================

INSERT INTO Promotions (PromotionCode, PromotionName, Description, DiscountType, DiscountValue, MinimumOrderValue, StartDate, EndDate, MaxUsage, CreatedBy)
VALUES 
('NEWCUST20', N'Ưu đãi khách hàng mới', N'Giảm 20% cho khách hàng lần đầu sử dụng dịch vụ', 'Percentage', 20, 2000000, '2025-07-01', '2025-12-31', 100, 2),
('FAMILY15', N'Ưu đãi gia đình', N'Giảm 15% cho xét nghiệm nhiều thành viên trong gia đình', 'Percentage', 15, 5000000, '2025-07-01', '2025-09-30', 50, 2);

GO

PRINT 'Sample data inserted successfully!';

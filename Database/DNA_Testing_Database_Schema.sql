-- =====================================================================================
-- DNA Testing Service Management System Database Schema
-- Bloodline DNA Testing Service Management System
-- Created: July 19, 2025
-- =====================================================================================

USE master;
GO

-- Drop database if exists
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'DNATestingDB')
BEGIN
    ALTER DATABASE DNATestingDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE DNATestingDB;
END
GO

-- Create database
CREATE DATABASE DNATestingDB;
GO

USE DNATestingDB;
GO

-- =====================================================================================
-- 1. USER MANAGEMENT TABLES
-- =====================================================================================

-- Users table (for different user types: Guest, Customer, Staff, Manager, Admin)
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20),
    Address NVARCHAR(500),
    UserType NVARCHAR(20) NOT NULL CHECK (UserType IN ('Guest', 'Customer', 'Staff', 'Manager', 'Admin')),
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    LastLoginDate DATETIME NULL
);

-- =====================================================================================
-- 2. PATIENT MANAGEMENT TABLES
-- =====================================================================================

-- Patients table
CREATE TABLE Patients (
    PatientId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NULL, -- Link to Users table for customer accounts
    FullName NVARCHAR(100) NOT NULL,
    DateOfBirth DATETIME NOT NULL,
    Gender NVARCHAR(10) NOT NULL CHECK (Gender IN ('Nam', 'Nữ', 'Khác')),
    Phone NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Address NVARCHAR(500),
    MedicalHistory NVARCHAR(MAX),
    EmergencyContact NVARCHAR(100),
    EmergencyPhone NVARCHAR(20),
    BloodType NVARCHAR(5),
    Allergies NVARCHAR(500),
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

-- Patient Records table
CREATE TABLE PatientRecords (
    RecordId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    RecordType NVARCHAR(50) NOT NULL, -- 'Medical History', 'Test Result', 'Note', etc.
    Title NVARCHAR(200) NOT NULL,
    Content NVARCHAR(MAX),
    RecordDate DATETIME NOT NULL DEFAULT GETDATE(),
    CreatedBy INT NOT NULL, -- UserId of staff who created the record
    IsConfidential BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserId)
);

-- =====================================================================================
-- 3. DNA TESTING SERVICE TABLES
-- =====================================================================================

-- DNA Test Services table (different types of DNA tests)
CREATE TABLE DNATestServices (
    ServiceId INT IDENTITY(1,1) PRIMARY KEY,
    ServiceCode NVARCHAR(20) NOT NULL UNIQUE,
    ServiceName NVARCHAR(200) NOT NULL,
    ServiceType NVARCHAR(50) NOT NULL CHECK (ServiceType IN ('Dân sự', 'Hành chính', 'Y tế')),
    Description NVARCHAR(MAX),
    Price DECIMAL(18,2) NOT NULL,
    EstimatedDays INT NOT NULL, -- Estimated completion days
    RequiresSample BIT NOT NULL DEFAULT 1,
    AllowHomeSample BIT NOT NULL DEFAULT 1, -- Can collect sample at home
    AllowClinicSample BIT NOT NULL DEFAULT 1, -- Can collect sample at clinic
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL
);

-- DNA Test Registration table
CREATE TABLE DNATestRegistrations (
    RegistrationId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    ServiceId INT NOT NULL,
    RegistrationDate DATETIME NOT NULL DEFAULT GETDATE(),
    SampleCollectionMethod NVARCHAR(20) NOT NULL CHECK (SampleCollectionMethod IN ('Tại nhà', 'Tại cơ sở', 'Tự thu thập')),
    Status NVARCHAR(30) NOT NULL DEFAULT 'Đã đăng ký' CHECK (Status IN ('Đã đăng ký', 'Đã gửi kit', 'Đã thu mẫu', 'Đang xét nghiệm', 'Hoàn thành', 'Đã hủy')),
    Priority NVARCHAR(20) NOT NULL DEFAULT 'Bình thường' CHECK (Priority IN ('Thấp', 'Bình thường', 'Cao', 'Khẩn cấp')),
    TotalCost DECIMAL(18,2) NOT NULL,
    PaidAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    PaymentStatus NVARCHAR(20) NOT NULL DEFAULT 'Chưa thanh toán' CHECK (PaymentStatus IN ('Chưa thanh toán', 'Đã cọc', 'Đã thanh toán')),
    Notes NVARCHAR(MAX),
    ExpectedCompletionDate DATETIME,
    ActualCompletionDate DATETIME NULL,
    CreatedBy INT NOT NULL, -- UserId of who created the registration
    AssignedStaff INT NULL, -- UserId of assigned staff
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (ServiceId) REFERENCES DNATestServices(ServiceId),
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserId),
    FOREIGN KEY (AssignedStaff) REFERENCES Users(UserId)
);

-- Sample Collection table
CREATE TABLE SampleCollections (
    CollectionId INT IDENTITY(1,1) PRIMARY KEY,
    RegistrationId INT NOT NULL,
    CollectionMethod NVARCHAR(20) NOT NULL CHECK (CollectionMethod IN ('Tại nhà', 'Tại cơ sở', 'Tự thu thập')),
    CollectionDate DATETIME NULL,
    CollectorStaffId INT NULL, -- Staff who collected the sample
    SampleType NVARCHAR(50) NOT NULL, -- 'Máu', 'Nước bọt', 'Tóc', etc.
    SampleQuality NVARCHAR(20) CHECK (SampleQuality IN ('Tốt', 'Khá', 'Kém', 'Không đạt')),
    KitSentDate DATETIME NULL,
    KitReceivedDate DATETIME NULL,
    SampleReceivedDate DATETIME NULL,
    Address NVARCHAR(500), -- Address for home collection
    ScheduledDate DATETIME NULL, -- Scheduled collection date
    Notes NVARCHAR(MAX),
    Status NVARCHAR(30) NOT NULL DEFAULT 'Chờ thu thập' CHECK (Status IN ('Chờ thu thập', 'Đã lên lịch', 'Đã thu thập', 'Đã nhận mẫu', 'Mẫu không đạt')),
    FOREIGN KEY (RegistrationId) REFERENCES DNATestRegistrations(RegistrationId),
    FOREIGN KEY (CollectorStaffId) REFERENCES Users(UserId)
);

-- Test Progress table
CREATE TABLE TestProgress (
    ProgressId INT IDENTITY(1,1) PRIMARY KEY,
    RegistrationId INT NOT NULL,
    StepName NVARCHAR(100) NOT NULL,
    StepDescription NVARCHAR(500),
    StepOrder INT NOT NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Chờ xử lý' CHECK (Status IN ('Chờ xử lý', 'Đang thực hiện', 'Hoàn thành', 'Có vấn đề')),
    StartDate DATETIME NULL,
    CompletedDate DATETIME NULL,
    PerformedBy INT NULL, -- UserId of staff who performed this step
    Notes NVARCHAR(MAX),
    FOREIGN KEY (RegistrationId) REFERENCES DNATestRegistrations(RegistrationId),
    FOREIGN KEY (PerformedBy) REFERENCES Users(UserId)
);

-- Test Results table
CREATE TABLE TestResults (
    ResultId INT IDENTITY(1,1) PRIMARY KEY,
    RegistrationId INT NOT NULL,
    ResultType NVARCHAR(50) NOT NULL, -- 'Preliminary', 'Final', 'Additional'
    ResultData NVARCHAR(MAX) NOT NULL, -- JSON or XML data containing test results
    ResultSummary NVARCHAR(MAX),
    Confidence DECIMAL(5,2), -- Confidence percentage
    ResultDate DATETIME NOT NULL DEFAULT GETDATE(),
    VerifiedBy INT NOT NULL, -- UserId of staff who verified the result
    IsReleased BIT NOT NULL DEFAULT 0, -- Whether result is released to patient
    ReleasedDate DATETIME NULL,
    ReleasedBy INT NULL, -- UserId of staff who released the result
    ResultFilePath NVARCHAR(500), -- Path to result file (PDF, etc.)
    FOREIGN KEY (RegistrationId) REFERENCES DNATestRegistrations(RegistrationId),
    FOREIGN KEY (VerifiedBy) REFERENCES Users(UserId),
    FOREIGN KEY (ReleasedBy) REFERENCES Users(UserId)
);

-- =====================================================================================
-- 4. APPOINTMENT AND SCHEDULING TABLES
-- =====================================================================================

-- Appointments table
CREATE TABLE Appointments (
    AppointmentId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    RegistrationId INT NULL, -- Link to DNA test registration if applicable
    AppointmentType NVARCHAR(50) NOT NULL, -- 'Tư vấn', 'Thu mẫu', 'Trả kết quả', etc.
    AppointmentDate DATETIME NOT NULL,
    Duration INT NOT NULL DEFAULT 30, -- Duration in minutes
    Status NVARCHAR(20) NOT NULL DEFAULT 'Đã đặt' CHECK (Status IN ('Đã đặt', 'Xác nhận', 'Đang thực hiện', 'Hoàn thành', 'Đã hủy', 'Không đến')),
    AssignedStaff INT NULL,
    Location NVARCHAR(200),
    Notes NVARCHAR(MAX),
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (RegistrationId) REFERENCES DNATestRegistrations(RegistrationId),
    FOREIGN KEY (AssignedStaff) REFERENCES Users(UserId)
);

-- =====================================================================================
-- 5. FEEDBACK AND RATING TABLES
-- =====================================================================================

-- Patient Feedback table
CREATE TABLE PatientFeedback (
    FeedbackId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    RegistrationId INT NULL, -- Link to specific DNA test if applicable
    ServiceId INT NULL, -- Link to specific service being rated
    Rating INT NOT NULL CHECK (Rating BETWEEN 1 AND 5),
    FeedbackType NVARCHAR(30) NOT NULL CHECK (FeedbackType IN ('Dịch vụ', 'Nhân viên', 'Cơ sở vật chất', 'Quy trình', 'Kết quả')),
    Title NVARCHAR(200),
    Comment NVARCHAR(MAX),
    IsPublic BIT NOT NULL DEFAULT 0, -- Whether feedback can be shown publicly
    IsVerified BIT NOT NULL DEFAULT 0, -- Whether feedback is verified by staff
    FeedbackDate DATETIME NOT NULL DEFAULT GETDATE(),
    ResponseFromStaff NVARCHAR(MAX) NULL,
    ResponseDate DATETIME NULL,
    ResponseBy INT NULL, -- UserId of staff who responded
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (RegistrationId) REFERENCES DNATestRegistrations(RegistrationId),
    FOREIGN KEY (ServiceId) REFERENCES DNATestServices(ServiceId),
    FOREIGN KEY (ResponseBy) REFERENCES Users(UserId)
);

-- =====================================================================================
-- 6. NOTIFICATION SYSTEM TABLES
-- =====================================================================================

-- Notifications table
CREATE TABLE Notifications (
    NotificationId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    NotificationType NVARCHAR(30) NOT NULL CHECK (NotificationType IN ('Thông tin', 'Cảnh báo', 'Khẩn cấp', 'Nhắc nhở')),
    Title NVARCHAR(200) NOT NULL,
    Message NVARCHAR(MAX) NOT NULL,
    IsRead BIT NOT NULL DEFAULT 0,
    IsSent BIT NOT NULL DEFAULT 0,
    SendMethod NVARCHAR(20) CHECK (SendMethod IN ('Email', 'SMS', 'In-app', 'All')),
    RelatedEntityType NVARCHAR(50), -- 'Registration', 'Appointment', 'Result', etc.
    RelatedEntityId INT, -- ID of related entity
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    SentDate DATETIME NULL,
    ReadDate DATETIME NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

-- =====================================================================================
-- 7. BLOG AND CONTENT MANAGEMENT TABLES
-- =====================================================================================

-- Blog Posts table (for sharing DNA knowledge and experiences)
CREATE TABLE BlogPosts (
    PostId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(300) NOT NULL,
    Slug NVARCHAR(300) NOT NULL UNIQUE,
    Content NVARCHAR(MAX) NOT NULL,
    Summary NVARCHAR(500),
    Category NVARCHAR(50) NOT NULL, -- 'Kiến thức ADN', 'Hướng dẫn', 'Tin tức', etc.
    Tags NVARCHAR(500), -- Comma-separated tags
    FeaturedImage NVARCHAR(500),
    AuthorId INT NOT NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Draft' CHECK (Status IN ('Draft', 'Published', 'Archived')),
    PublishedDate DATETIME NULL,
    ViewCount INT NOT NULL DEFAULT 0,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    FOREIGN KEY (AuthorId) REFERENCES Users(UserId)
);

-- =====================================================================================
-- 8. DOCTOR AND STAFF MANAGEMENT TABLES
-- =====================================================================================

-- Doctors table
CREATE TABLE Doctors (
    DoctorId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    LicenseNumber NVARCHAR(50) NOT NULL UNIQUE,
    Specialization NVARCHAR(200),
    Qualification NVARCHAR(500),
    Experience INT, -- Years of experience
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

-- Doctor Schedules table
CREATE TABLE DoctorSchedules (
    ScheduleId INT IDENTITY(1,1) PRIMARY KEY,
    DoctorId INT NOT NULL,
    DayOfWeek INT NOT NULL CHECK (DayOfWeek BETWEEN 0 AND 6), -- 0=Sunday, 6=Saturday
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    IsAvailable BIT NOT NULL DEFAULT 1,
    MaxAppointments INT NOT NULL DEFAULT 10,
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);

-- =====================================================================================
-- 9. PRICING AND SERVICE MANAGEMENT TABLES
-- =====================================================================================

-- Service Pricing History table
CREATE TABLE ServicePricingHistory (
    PricingId INT IDENTITY(1,1) PRIMARY KEY,
    ServiceId INT NOT NULL,
    OldPrice DECIMAL(18,2),
    NewPrice DECIMAL(18,2) NOT NULL,
    EffectiveDate DATETIME NOT NULL DEFAULT GETDATE(),
    Reason NVARCHAR(500),
    ChangedBy INT NOT NULL,
    FOREIGN KEY (ServiceId) REFERENCES DNATestServices(ServiceId),
    FOREIGN KEY (ChangedBy) REFERENCES Users(UserId)
);

-- Promotions table
CREATE TABLE Promotions (
    PromotionId INT IDENTITY(1,1) PRIMARY KEY,
    PromotionCode NVARCHAR(20) NOT NULL UNIQUE,
    PromotionName NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    DiscountType NVARCHAR(20) NOT NULL CHECK (DiscountType IN ('Percentage', 'Fixed')),
    DiscountValue DECIMAL(18,2) NOT NULL,
    MinimumOrderValue DECIMAL(18,2) DEFAULT 0,
    MaxDiscountAmount DECIMAL(18,2),
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    MaxUsage INT, -- Maximum number of times this promotion can be used
    CurrentUsage INT NOT NULL DEFAULT 0,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedBy INT NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserId)
);

-- =====================================================================================
-- 10. AUDIT AND LOGGING TABLES
-- =====================================================================================

-- Audit Logs table
CREATE TABLE AuditLogs (
    LogId INT IDENTITY(1,1) PRIMARY KEY,
    TableName NVARCHAR(50) NOT NULL,
    RecordId INT NOT NULL,
    Action NVARCHAR(20) NOT NULL CHECK (Action IN ('INSERT', 'UPDATE', 'DELETE')),
    OldValues NVARCHAR(MAX),
    NewValues NVARCHAR(MAX),
    ChangedBy INT NOT NULL,
    ChangeDate DATETIME NOT NULL DEFAULT GETDATE(),
    IPAddress NVARCHAR(45),
    UserAgent NVARCHAR(500),
    FOREIGN KEY (ChangedBy) REFERENCES Users(UserId)
);

-- System Settings table
CREATE TABLE SystemSettings (
    SettingId INT IDENTITY(1,1) PRIMARY KEY,
    SettingKey NVARCHAR(100) NOT NULL UNIQUE,
    SettingValue NVARCHAR(MAX) NOT NULL,
    Description NVARCHAR(500),
    Category NVARCHAR(50) NOT NULL, -- 'General', 'Email', 'SMS', 'Security', etc.
    IsEditable BIT NOT NULL DEFAULT 1,
    UpdatedBy INT NOT NULL,
    UpdatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (UpdatedBy) REFERENCES Users(UserId)
);

-- =====================================================================================
-- CREATE INDEXES FOR PERFORMANCE
-- =====================================================================================

-- Users table indexes
CREATE INDEX IX_Users_Email ON Users(Email);
CREATE INDEX IX_Users_UserType ON Users(UserType);
CREATE INDEX IX_Users_IsActive ON Users(IsActive);

-- Patients table indexes
CREATE INDEX IX_Patients_Email ON Patients(Email);
CREATE INDEX IX_Patients_Phone ON Patients(Phone);
CREATE INDEX IX_Patients_IsActive ON Patients(IsActive);

-- DNA Test Registrations indexes
CREATE INDEX IX_DNATestRegistrations_PatientId ON DNATestRegistrations(PatientId);
CREATE INDEX IX_DNATestRegistrations_ServiceId ON DNATestRegistrations(ServiceId);
CREATE INDEX IX_DNATestRegistrations_Status ON DNATestRegistrations(Status);
CREATE INDEX IX_DNATestRegistrations_RegistrationDate ON DNATestRegistrations(RegistrationDate);

-- Test Results indexes
CREATE INDEX IX_TestResults_RegistrationId ON TestResults(RegistrationId);
CREATE INDEX IX_TestResults_IsReleased ON TestResults(IsReleased);
CREATE INDEX IX_TestResults_ResultDate ON TestResults(ResultDate);

-- Appointments indexes
CREATE INDEX IX_Appointments_PatientId ON Appointments(PatientId);
CREATE INDEX IX_Appointments_AppointmentDate ON Appointments(AppointmentDate);
CREATE INDEX IX_Appointments_Status ON Appointments(Status);

-- Notifications indexes
CREATE INDEX IX_Notifications_UserId ON Notifications(UserId);
CREATE INDEX IX_Notifications_IsRead ON Notifications(IsRead);
CREATE INDEX IX_Notifications_CreatedDate ON Notifications(CreatedDate);

-- Blog Posts indexes
CREATE INDEX IX_BlogPosts_Status ON BlogPosts(Status);
CREATE INDEX IX_BlogPosts_Category ON BlogPosts(Category);
CREATE INDEX IX_BlogPosts_PublishedDate ON BlogPosts(PublishedDate);

-- Feedback indexes
CREATE INDEX IX_PatientFeedback_PatientId ON PatientFeedback(PatientId);
CREATE INDEX IX_PatientFeedback_Rating ON PatientFeedback(Rating);
CREATE INDEX IX_PatientFeedback_IsPublic ON PatientFeedback(IsPublic);

GO

PRINT 'DNA Testing Service Management Database schema created successfully!';

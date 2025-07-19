-- =====================================================================================
-- DNA Testing Service Management System - Views and Stored Procedures
-- Database views and stored procedures for application functionality
-- =====================================================================================

USE DNATestingDB;
GO

-- =====================================================================================
-- 1. CREATE VIEWS FOR DATA ACCESS
-- =====================================================================================

-- View for Patient List with DNA Test Status
CREATE VIEW vw_PatientList AS
SELECT 
    p.PatientId,
    p.FullName,
    p.Email,
    p.Phone,
    p.DateOfBirth,
    p.Gender,
    p.Address,
    p.IsActive,
    p.CreatedDate,
    
    -- DNA Test Status Information
    ISNULL(dna_stats.TotalTests, 0) as TotalDNATests,
    ISNULL(dna_stats.CompletedTests, 0) as CompletedDNATests,
    ISNULL(dna_stats.InProgressTests, 0) as InProgressDNATests,
    dna_stats.LastTestDate as LastDNATestDate,
    
    -- Current DNA Test Status
    CASE 
        WHEN dna_stats.InProgressTests > 0 THEN N'Đang xét nghiệm'
        WHEN dna_stats.CompletedTests > 0 THEN N'Hoàn thành'
        WHEN dna_stats.TotalTests > 0 THEN N'Đã hủy'
        ELSE N'Chưa xét nghiệm'
    END as DNATestStatus,
    
    -- Age calculation
    DATEDIFF(YEAR, p.DateOfBirth, GETDATE()) - 
    CASE WHEN DATEADD(YEAR, DATEDIFF(YEAR, p.DateOfBirth, GETDATE()), p.DateOfBirth) > GETDATE() 
         THEN 1 ELSE 0 END as Age
         
FROM Patients p
LEFT JOIN (
    SELECT 
        dtr.PatientId,
        COUNT(*) as TotalTests,
        SUM(CASE WHEN dtr.Status = N'Hoàn thành' THEN 1 ELSE 0 END) as CompletedTests,
        SUM(CASE WHEN dtr.Status IN (N'Đã đăng ký', N'Đã gửi kit', N'Đã thu mẫu', N'Đang xét nghiệm') THEN 1 ELSE 0 END) as InProgressTests,
        MAX(dtr.RegistrationDate) as LastTestDate
    FROM DNATestRegistrations dtr
    WHERE dtr.Status != N'Đã hủy'
    GROUP BY dtr.PatientId
) dna_stats ON p.PatientId = dna_stats.PatientId;

GO

-- View for DNA Test Registration Details
CREATE VIEW vw_DNATestRegistrationDetails AS
SELECT 
    dtr.RegistrationId,
    dtr.PatientId,
    p.FullName as PatientName,
    p.Phone as PatientPhone,
    p.Email as PatientEmail,
    dtr.ServiceId,
    dts.ServiceName,
    dts.ServiceType,
    dtr.RegistrationDate,
    dtr.SampleCollectionMethod,
    dtr.Status,
    dtr.Priority,
    dtr.TotalCost,
    dtr.PaidAmount,
    dtr.PaymentStatus,
    dtr.ExpectedCompletionDate,
    dtr.ActualCompletionDate,
    
    -- Staff Information
    creator.FullName as CreatedByName,
    assigned.FullName as AssignedStaffName,
    
    -- Sample Collection Info
    sc.CollectionDate,
    sc.SampleType,
    sc.SampleQuality,
    sc.SampleReceivedDate,
    
    -- Progress Information
    ISNULL(progress_info.CompletedSteps, 0) as CompletedSteps,
    ISNULL(progress_info.TotalSteps, 0) as TotalSteps,
    CASE 
        WHEN progress_info.TotalSteps > 0 
        THEN CAST(progress_info.CompletedSteps AS FLOAT) / progress_info.TotalSteps * 100 
        ELSE 0 
    END as ProgressPercentage
    
FROM DNATestRegistrations dtr
INNER JOIN Patients p ON dtr.PatientId = p.PatientId
INNER JOIN DNATestServices dts ON dtr.ServiceId = dts.ServiceId
INNER JOIN Users creator ON dtr.CreatedBy = creator.UserId
LEFT JOIN Users assigned ON dtr.AssignedStaff = assigned.UserId
LEFT JOIN SampleCollections sc ON dtr.RegistrationId = sc.RegistrationId
LEFT JOIN (
    SELECT 
        tp.RegistrationId,
        COUNT(*) as TotalSteps,
        SUM(CASE WHEN tp.Status = N'Hoàn thành' THEN 1 ELSE 0 END) as CompletedSteps
    FROM TestProgress tp
    GROUP BY tp.RegistrationId
) progress_info ON dtr.RegistrationId = progress_info.RegistrationId;

GO

-- View for Dashboard Statistics
CREATE VIEW vw_DashboardStats AS
SELECT 
    -- Today's statistics
    (SELECT COUNT(*) FROM DNATestRegistrations WHERE CAST(RegistrationDate AS DATE) = CAST(GETDATE() AS DATE)) as TodayRegistrations,
    (SELECT COUNT(*) FROM Appointments WHERE CAST(AppointmentDate AS DATE) = CAST(GETDATE() AS DATE) AND Status != N'Đã hủy') as TodayAppointments,
    (SELECT COUNT(*) FROM TestResults WHERE CAST(ResultDate AS DATE) = CAST(GETDATE() AS DATE)) as TodayResults,
    
    -- This month's statistics
    (SELECT COUNT(*) FROM DNATestRegistrations WHERE YEAR(RegistrationDate) = YEAR(GETDATE()) AND MONTH(RegistrationDate) = MONTH(GETDATE())) as MonthRegistrations,
    (SELECT SUM(TotalCost) FROM DNATestRegistrations WHERE YEAR(RegistrationDate) = YEAR(GETDATE()) AND MONTH(RegistrationDate) = MONTH(GETDATE())) as MonthRevenue,
    
    -- Overall statistics
    (SELECT COUNT(*) FROM Patients WHERE IsActive = 1) as TotalActivePatients,
    (SELECT COUNT(*) FROM DNATestRegistrations WHERE Status = N'Đang xét nghiệm') as ActiveTests,
    (SELECT COUNT(*) FROM DNATestRegistrations WHERE Status = N'Hoàn thành') as CompletedTests,
    
    -- Service statistics
    (SELECT COUNT(*) FROM DNATestServices WHERE IsActive = 1) as ActiveServices,
    (SELECT AVG(CAST(Rating AS FLOAT)) FROM PatientFeedback) as AverageRating;

GO

-- =====================================================================================
-- 2. CREATE STORED PROCEDURES
-- =====================================================================================

-- Procedure to get patient list with filtering
CREATE PROCEDURE sp_GetPatientList
    @SearchTerm NVARCHAR(100) = NULL,
    @Gender NVARCHAR(10) = NULL,
    @IsActive BIT = NULL,
    @DNATestStatus NVARCHAR(30) = NULL,
    @PageNumber INT = 1,
    @PageSize INT = 50
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        PatientId,
        FullName,
        Email,
        Phone,
        DateOfBirth,
        Gender,
        Address,
        IsActive,
        CreatedDate,
        TotalDNATests,
        CompletedDNATests,
        InProgressDNATests,
        LastDNATestDate,
        DNATestStatus,
        Age
    FROM vw_PatientList
    WHERE 
        (@SearchTerm IS NULL OR 
         FullName LIKE '%' + @SearchTerm + '%' OR 
         Email LIKE '%' + @SearchTerm + '%' OR 
         Phone LIKE '%' + @SearchTerm + '%')
    AND (@Gender IS NULL OR Gender = @Gender)
    AND (@IsActive IS NULL OR IsActive = @IsActive)
    AND (@DNATestStatus IS NULL OR DNATestStatus = @DNATestStatus)
    ORDER BY CreatedDate DESC
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END;

GO

-- Procedure to create new DNA test registration
CREATE PROCEDURE sp_CreateDNATestRegistration
    @PatientId INT,
    @ServiceId INT,
    @SampleCollectionMethod NVARCHAR(20),
    @Priority NVARCHAR(20) = N'Bình thường',
    @Notes NVARCHAR(MAX) = NULL,
    @CreatedBy INT,
    @RegistrationId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Get service details
        DECLARE @ServicePrice DECIMAL(18,2), @EstimatedDays INT;
        SELECT @ServicePrice = Price, @EstimatedDays = EstimatedDays
        FROM DNATestServices 
        WHERE ServiceId = @ServiceId AND IsActive = 1;
        
        IF @ServicePrice IS NULL
        BEGIN
            RAISERROR('Service not found or inactive', 16, 1);
            RETURN;
        END
        
        -- Calculate expected completion date
        DECLARE @ExpectedDate DATETIME = DATEADD(DAY, @EstimatedDays, GETDATE());
        
        -- Insert registration
        INSERT INTO DNATestRegistrations (
            PatientId, ServiceId, SampleCollectionMethod, Status, Priority,
            TotalCost, Notes, ExpectedCompletionDate, CreatedBy
        )
        VALUES (
            @PatientId, @ServiceId, @SampleCollectionMethod, N'Đã đăng ký', @Priority,
            @ServicePrice, @Notes, @ExpectedDate, @CreatedBy
        );
        
        SET @RegistrationId = SCOPE_IDENTITY();
        
        -- Create initial test progress steps
        INSERT INTO TestProgress (RegistrationId, StepName, StepDescription, StepOrder, Status)
        VALUES 
            (@RegistrationId, N'Thu thập mẫu', N'Thu thập mẫu xét nghiệm từ bệnh nhân', 1, N'Chờ xử lý'),
            (@RegistrationId, N'Chuẩn bị mẫu', N'Chuẩn bị và xử lý mẫu cho phân tích', 2, N'Chờ xử lý'),
            (@RegistrationId, N'Phân tích ADN', N'Tiến hành phân tích và so sánh ADN', 3, N'Chờ xử lý'),
            (@RegistrationId, N'Kiểm tra kết quả', N'Kiểm tra và xác nhận kết quả phân tích', 4, N'Chờ xử lý'),
            (@RegistrationId, N'Xuất báo cáo', N'Tạo báo cáo kết quả và gửi cho khách hàng', 5, N'Chờ xử lý');
        
        -- Create notification for patient
        IF EXISTS (SELECT 1 FROM Patients WHERE PatientId = @PatientId AND UserId IS NOT NULL)
        BEGIN
            DECLARE @PatientUserId INT;
            SELECT @PatientUserId = UserId FROM Patients WHERE PatientId = @PatientId;
            
            INSERT INTO Notifications (UserId, NotificationType, Title, Message, RelatedEntityType, RelatedEntityId)
            VALUES (
                @PatientUserId, N'Thông tin', 
                N'Đăng ký xét nghiệm ADN thành công',
                N'Bạn đã đăng ký xét nghiệm ADN thành công. Mã đăng ký: ' + CAST(@RegistrationId AS NVARCHAR(10)),
                'Registration', @RegistrationId
            );
        END
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

GO

-- Procedure to update test progress
CREATE PROCEDURE sp_UpdateTestProgress
    @ProgressId INT,
    @Status NVARCHAR(20),
    @PerformedBy INT,
    @Notes NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Update progress step
        UPDATE TestProgress 
        SET 
            Status = @Status,
            PerformedBy = @PerformedBy,
            Notes = @Notes,
            StartDate = CASE WHEN StartDate IS NULL AND @Status = N'Đang thực hiện' THEN GETDATE() ELSE StartDate END,
            CompletedDate = CASE WHEN @Status = N'Hoàn thành' THEN GETDATE() ELSE NULL END
        WHERE ProgressId = @ProgressId;
        
        -- Check if all steps are completed to update registration status
        DECLARE @RegistrationId INT;
        SELECT @RegistrationId = RegistrationId FROM TestProgress WHERE ProgressId = @ProgressId;
        
        DECLARE @CompletedSteps INT, @TotalSteps INT;
        SELECT 
            @CompletedSteps = SUM(CASE WHEN Status = N'Hoàn thành' THEN 1 ELSE 0 END),
            @TotalSteps = COUNT(*)
        FROM TestProgress 
        WHERE RegistrationId = @RegistrationId;
        
        -- Update registration status if all steps completed
        IF @CompletedSteps = @TotalSteps
        BEGIN
            UPDATE DNATestRegistrations 
            SET Status = N'Hoàn thành', ActualCompletionDate = GETDATE()
            WHERE RegistrationId = @RegistrationId;
            
            -- Send notification to patient
            DECLARE @PatientUserId INT;
            SELECT @PatientUserId = p.UserId 
            FROM DNATestRegistrations dtr
            INNER JOIN Patients p ON dtr.PatientId = p.PatientId
            WHERE dtr.RegistrationId = @RegistrationId AND p.UserId IS NOT NULL;
            
            IF @PatientUserId IS NOT NULL
            BEGIN
                INSERT INTO Notifications (UserId, NotificationType, Title, Message, RelatedEntityType, RelatedEntityId)
                VALUES (
                    @PatientUserId, N'Thông tin',
                    N'Xét nghiệm ADN hoàn thành',
                    N'Xét nghiệm ADN của bạn đã hoàn thành. Vui lòng đăng nhập để xem kết quả.',
                    'Registration', @RegistrationId
                );
            END
        END
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

GO

-- Procedure to get DNA test history for a patient
CREATE PROCEDURE sp_GetPatientDNATestHistory
    @PatientId INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        RegistrationId,
        ServiceName,
        ServiceType,
        RegistrationDate,
        Status,
        TotalCost,
        PaymentStatus,
        ExpectedCompletionDate,
        ActualCompletionDate,
        ProgressPercentage,
        SampleCollectionMethod,
        CollectionDate,
        SampleType
    FROM vw_DNATestRegistrationDetails
    WHERE PatientId = @PatientId
    ORDER BY RegistrationDate DESC;
END;

GO

-- Procedure to submit patient feedback
CREATE PROCEDURE sp_SubmitPatientFeedback
    @PatientId INT,
    @RegistrationId INT = NULL,
    @ServiceId INT = NULL,
    @Rating INT,
    @FeedbackType NVARCHAR(30),
    @Title NVARCHAR(200) = NULL,
    @Comment NVARCHAR(MAX) = NULL,
    @FeedbackId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    IF @Rating NOT BETWEEN 1 AND 5
    BEGIN
        RAISERROR('Rating must be between 1 and 5', 16, 1);
        RETURN;
    END
    
    INSERT INTO PatientFeedback (
        PatientId, RegistrationId, ServiceId, Rating, 
        FeedbackType, Title, Comment, IsPublic
    )
    VALUES (
        @PatientId, @RegistrationId, @ServiceId, @Rating,
        @FeedbackType, @Title, @Comment, 0
    );
    
    SET @FeedbackId = SCOPE_IDENTITY();
    
    -- Notify management about new feedback
    INSERT INTO Notifications (UserId, NotificationType, Title, Message, RelatedEntityType, RelatedEntityId)
    SELECT 
        u.UserId, N'Thông tin',
        N'Phản hồi mới từ khách hàng',
        N'Có phản hồi mới từ khách hàng với đánh giá ' + CAST(@Rating AS NVARCHAR(1)) + ' sao.',
        'Feedback', @FeedbackId
    FROM Users u 
    WHERE u.UserType IN ('Manager', 'Admin') AND u.IsActive = 1;
END;

GO

-- Procedure to get dashboard statistics
CREATE PROCEDURE sp_GetDashboardStatistics
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT * FROM vw_DashboardStats;
    
    -- Recent registrations
    SELECT TOP 10
        RegistrationId,
        PatientName,
        ServiceName,
        RegistrationDate,
        Status,
        TotalCost
    FROM vw_DNATestRegistrationDetails
    ORDER BY RegistrationDate DESC;
    
    -- Upcoming appointments
    SELECT TOP 10
        a.AppointmentId,
        p.FullName as PatientName,
        a.AppointmentType,
        a.AppointmentDate,
        a.Status,
        u.FullName as AssignedStaffName
    FROM Appointments a
    INNER JOIN Patients p ON a.PatientId = p.PatientId
    LEFT JOIN Users u ON a.AssignedStaff = u.UserId
    WHERE a.AppointmentDate >= GETDATE() AND a.Status != N'Đã hủy'
    ORDER BY a.AppointmentDate;
END;

GO

-- Procedure to search patients for quick lookup
CREATE PROCEDURE sp_SearchPatients
    @SearchTerm NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT TOP 20
        PatientId,
        FullName,
        Email,
        Phone,
        DateOfBirth,
        DNATestStatus,
        TotalDNATests
    FROM vw_PatientList
    WHERE 
        FullName LIKE '%' + @SearchTerm + '%' OR
        Email LIKE '%' + @SearchTerm + '%' OR
        Phone LIKE '%' + @SearchTerm + '%'
    ORDER BY 
        CASE 
            WHEN FullName LIKE @SearchTerm + '%' THEN 1
            WHEN Email LIKE @SearchTerm + '%' THEN 2
            WHEN Phone LIKE @SearchTerm + '%' THEN 3
            ELSE 4
        END,
        FullName;
END;

GO

PRINT 'Views and stored procedures created successfully!';

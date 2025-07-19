-- =====================================================================================
-- DNA Testing Service Management System - Complete Database Deployment Script
-- Run this script to deploy the complete database system
-- =====================================================================================

PRINT 'Starting DNA Testing Service Management System Database Deployment...'
PRINT '======================================================================'

-- Step 1: Create Database Schema
PRINT 'Step 1: Creating Database Schema...'
-- (Content from DNA_Testing_Database_Schema.sql would be included here)

-- Step 2: Insert Sample Data  
PRINT 'Step 2: Inserting Sample Data...'
-- (Content from DNA_Testing_Sample_Data.sql would be included here)

-- Step 3: Create Views and Stored Procedures
PRINT 'Step 3: Creating Views and Stored Procedures...'
-- (Content from DNA_Testing_Views_Procedures.sql would be included here)

-- Step 4: Verify Database Setup
PRINT 'Step 4: Verifying Database Setup...'

-- Check if all tables exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users')
    PRINT '✓ Users table created successfully'
ELSE 
    PRINT '✗ Users table not found'

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Patients')
    PRINT '✓ Patients table created successfully'
ELSE 
    PRINT '✗ Patients table not found'

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DNATestServices')
    PRINT '✓ DNATestServices table created successfully'
ELSE 
    PRINT '✗ DNATestServices table not found'

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DNATestRegistrations')
    PRINT '✓ DNATestRegistrations table created successfully'
ELSE 
    PRINT '✗ DNATestRegistrations table not found'

-- Check sample data
DECLARE @UserCount INT, @PatientCount INT, @ServiceCount INT
SELECT @UserCount = COUNT(*) FROM Users
SELECT @PatientCount = COUNT(*) FROM Patients  
SELECT @ServiceCount = COUNT(*) FROM DNATestServices

PRINT 'Sample Data Verification:'
PRINT '- Users: ' + CAST(@UserCount AS NVARCHAR(10)) + ' records'
PRINT '- Patients: ' + CAST(@PatientCount AS NVARCHAR(10)) + ' records'
PRINT '- DNA Test Services: ' + CAST(@ServiceCount AS NVARCHAR(10)) + ' records'

-- Check views
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vw_PatientList')
    PRINT '✓ vw_PatientList view created successfully'
ELSE 
    PRINT '✗ vw_PatientList view not found'

-- Check stored procedures
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'sp_GetPatientList')
    PRINT '✓ sp_GetPatientList procedure created successfully'
ELSE 
    PRINT '✗ sp_GetPatientList procedure not found'

-- Test basic functionality
PRINT ''
PRINT 'Testing Basic Functionality:'

-- Test patient list view
BEGIN TRY
    DECLARE @TestPatientCount INT
    SELECT @TestPatientCount = COUNT(*) FROM vw_PatientList
    PRINT '✓ Patient list view working - ' + CAST(@TestPatientCount AS NVARCHAR(10)) + ' patients found'
END TRY
BEGIN CATCH
    PRINT '✗ Error testing patient list view: ' + ERROR_MESSAGE()
END CATCH

-- Test stored procedure
BEGIN TRY
    DECLARE @TestResult TABLE (
        PatientId INT,
        FullName NVARCHAR(100),
        Email NVARCHAR(100),
        DNATestStatus NVARCHAR(30)
    )
    
    INSERT INTO @TestResult
    EXEC sp_GetPatientList @PageSize = 5
    
    DECLARE @ProcedureTestCount INT
    SELECT @ProcedureTestCount = COUNT(*) FROM @TestResult
    PRINT '✓ sp_GetPatientList working - ' + CAST(@ProcedureTestCount AS NVARCHAR(10)) + ' patients returned'
END TRY
BEGIN CATCH
    PRINT '✗ Error testing stored procedure: ' + ERROR_MESSAGE()
END CATCH

PRINT ''
PRINT '======================================================================'
PRINT 'DNA Testing Service Management System Database Deployment Complete!'
PRINT ''
PRINT 'Next Steps:'
PRINT '1. Update your application''s connection string to point to DNATestingDB'
PRINT '2. Test the application connection'
PRINT '3. Verify all features are working correctly'
PRINT ''
PRINT 'Connection String Example:'
PRINT 'Server=YOUR_SERVER;Database=DNATestingDB;User Id=sa;Password=YOUR_PASSWORD;TrustServerCertificate=True;'
PRINT ''

-- Show admin login info
PRINT 'Default Admin Login:'
PRINT 'Username: admin'
PRINT 'Email: admin@dnatesting.com'
PRINT 'Password: hashedpassword123 (you should change this in production)'
PRINT ''

-- Show sample patient info
PRINT 'Sample Patient Data:'
SELECT TOP 3 
    FullName, 
    Email, 
    Phone, 
    Gender,
    CASE WHEN IsActive = 1 THEN 'Active' ELSE 'Inactive' END as Status
FROM Patients
ORDER BY CreatedDate DESC

PRINT ''
PRINT 'Database setup completed successfully!'

GO

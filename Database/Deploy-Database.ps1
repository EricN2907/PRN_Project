# =====================================================================================
# DNA Testing Service Management System - Database Deployment PowerShell Script
# This script automatically deploys the complete database system
# =====================================================================================

param(
    [Parameter(Mandatory=$true)]
    [string]$ServerName,
    
    [Parameter(Mandatory=$false)]
    [string]$Username = "sa",
    
    [Parameter(Mandatory=$true)]
    [string]$Password,
    
    [Parameter(Mandatory=$false)]
    [string]$DatabaseName = "DNATestingDB"
)

Write-Host "==================================================================" -ForegroundColor Cyan
Write-Host "DNA Testing Service Management System - Database Deployment" -ForegroundColor Cyan
Write-Host "==================================================================" -ForegroundColor Cyan
Write-Host ""

# Get the script directory
$ScriptDirectory = Split-Path -Parent $MyInvocation.MyCommand.Path

# Define SQL files
$SqlFiles = @(
    @{
        Name = "Database Schema"
        File = "DNA_Testing_Database_Schema.sql"
        Description = "Creating database and table structure"
    },
    @{
        Name = "Sample Data"
        File = "DNA_Testing_Sample_Data.sql"
        Description = "Inserting sample data"
    },
    @{
        Name = "Views and Procedures"
        File = "DNA_Testing_Views_Procedures.sql"
        Description = "Creating views and stored procedures"
    }
)

# Function to execute SQL file
function Execute-SqlFile {
    param(
        [string]$FilePath,
        [string]$ServerName,
        [string]$Username,
        [string]$Password,
        [string]$Description
    )
    
    try {
        Write-Host "[$Description]" -ForegroundColor Yellow
        Write-Host "Executing: $FilePath" -ForegroundColor Gray
        
        $ConnectionString = "Server=$ServerName;User Id=$Username;Password=$Password;TrustServerCertificate=True;"
        
        # Use sqlcmd to execute the SQL file
        $Result = & sqlcmd -S $ServerName -U $Username -P $Password -i $FilePath -b
        
        if ($LASTEXITCODE -eq 0) {
            Write-Host "✓ $Description completed successfully!" -ForegroundColor Green
            return $true
        } else {
            Write-Host "✗ $Description failed!" -ForegroundColor Red
            Write-Host "Error: $Result" -ForegroundColor Red
            return $false
        }
    }
    catch {
        Write-Host "✗ Error executing $Description`: $($_.Exception.Message)" -ForegroundColor Red
        return $false
    }
}

# Function to test database connection
function Test-DatabaseConnection {
    param(
        [string]$ServerName,
        [string]$Username,
        [string]$Password,
        [string]$DatabaseName
    )
    
    try {
        Write-Host "Testing database connection..." -ForegroundColor Yellow
        
        $TestQuery = "SELECT COUNT(*) as PatientCount FROM [$DatabaseName].[dbo].[Patients]"
        $Result = & sqlcmd -S $ServerName -U $Username -P $Password -Q $TestQuery -h -1
        
        if ($LASTEXITCODE -eq 0) {
            Write-Host "✓ Database connection successful!" -ForegroundColor Green
            Write-Host "✓ Found $($Result.Trim()) patients in database" -ForegroundColor Green
            return $true
        } else {
            Write-Host "✗ Database connection failed!" -ForegroundColor Red
            return $false
        }
    }
    catch {
        Write-Host "✗ Connection test error: $($_.Exception.Message)" -ForegroundColor Red
        return $false
    }
}

# Main deployment process
Write-Host "Starting database deployment..." -ForegroundColor Cyan
Write-Host "Server: $ServerName" -ForegroundColor Gray
Write-Host "Database: $DatabaseName" -ForegroundColor Gray
Write-Host "Username: $Username" -ForegroundColor Gray
Write-Host ""

$AllSuccessful = $true

# Execute each SQL file
foreach ($SqlFile in $SqlFiles) {
    $FilePath = Join-Path $ScriptDirectory $SqlFile.File
    
    if (Test-Path $FilePath) {
        $Success = Execute-SqlFile -FilePath $FilePath -ServerName $ServerName -Username $Username -Password $Password -Description $SqlFile.Description
        if (-not $Success) {
            $AllSuccessful = $false
            break
        }
    } else {
        Write-Host "✗ SQL file not found: $FilePath" -ForegroundColor Red
        $AllSuccessful = $false
        break
    }
    Write-Host ""
}

# Test the database if all scripts executed successfully
if ($AllSuccessful) {
    Write-Host "==================================================================" -ForegroundColor Cyan
    Write-Host "Verifying database deployment..." -ForegroundColor Cyan
    Write-Host ""
    
    $ConnectionTest = Test-DatabaseConnection -ServerName $ServerName -Username $Username -Password $Password -DatabaseName $DatabaseName
    
    if ($ConnectionTest) {
        Write-Host ""
        Write-Host "==================================================================" -ForegroundColor Green
        Write-Host "🎉 DATABASE DEPLOYMENT COMPLETED SUCCESSFULLY! 🎉" -ForegroundColor Green
        Write-Host "==================================================================" -ForegroundColor Green
        Write-Host ""
        
        Write-Host "Next Steps:" -ForegroundColor Yellow
        Write-Host "1. Update your application's appsettings.json with the following connection string:" -ForegroundColor White
        Write-Host ""
        $ConnectionString = "Server=$ServerName;Database=$DatabaseName;User Id=$Username;Password=$Password;TrustServerCertificate=True;"
        Write-Host "`"DefaultConnection`": `"$ConnectionString`"" -ForegroundColor Cyan
        Write-Host ""
        
        Write-Host "2. Default Admin Login:" -ForegroundColor Yellow
        Write-Host "   Email: admin@dnatesting.com" -ForegroundColor White
        Write-Host "   Username: admin" -ForegroundColor White
        Write-Host "   Password: hashedpassword123" -ForegroundColor White
        Write-Host ""
        
        Write-Host "3. Sample Customer Logins:" -ForegroundColor Yellow
        Write-Host "   - hoa.nguyen@email.com (Nguyễn Thị Hoa)" -ForegroundColor White
        Write-Host "   - nam.tran@email.com (Trần Văn Nam)" -ForegroundColor White
        Write-Host "   - lan.le@email.com (Lê Thị Lan)" -ForegroundColor White
        Write-Host ""
        
        Write-Host "4. Test your application and verify all features are working!" -ForegroundColor Yellow
        Write-Host ""
        
    } else {
        Write-Host ""
        Write-Host "==================================================================" -ForegroundColor Red
        Write-Host "❌ DATABASE DEPLOYMENT COMPLETED WITH ERRORS" -ForegroundColor Red
        Write-Host "==================================================================" -ForegroundColor Red
        Write-Host ""
        Write-Host "Please check the errors above and try again." -ForegroundColor Yellow
    }
} else {
    Write-Host ""
    Write-Host "==================================================================" -ForegroundColor Red
    Write-Host "❌ DATABASE DEPLOYMENT FAILED" -ForegroundColor Red
    Write-Host "==================================================================" -ForegroundColor Red
    Write-Host ""
    Write-Host "Please check the errors above and try again." -ForegroundColor Yellow
    Write-Host ""
    Write-Host "Common Issues:" -ForegroundColor Yellow
    Write-Host "- SQL Server is not running" -ForegroundColor White
    Write-Host "- Incorrect server name or credentials" -ForegroundColor White
    Write-Host "- SQL files are missing or corrupted" -ForegroundColor White
    Write-Host "- Permission issues" -ForegroundColor White
}

Write-Host ""
Write-Host "Press any key to exit..." -ForegroundColor Gray
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")

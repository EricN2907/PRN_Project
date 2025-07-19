# DNA Testing Service Management System - Database Setup Guide

## Hướng dẫn cài đặt và cấu hình Database

### 1. Yêu cầu hệ thống
- **SQL Server 2019** hoặc cao hơn
- **SQL Server Management Studio (SSMS)** để quản lý database
- **Visual Studio 2022** với .NET 6.0 hoặc cao hơn
- **Entity Framework Core** đã được cài đặt trong project

### 2. Cài đặt Database

#### Bước 1: Tạo Database Schema
```sql
-- Chạy file SQL này để tạo database và tables
-- File: DNA_Testing_Database_Schema.sql
```

1. Mở **SQL Server Management Studio (SSMS)**
2. Kết nối đến SQL Server instance của bạn
3. Mở file `DNA_Testing_Database_Schema.sql`
4. Thực thi script để tạo database `DNATestingDB` và tất cả tables

#### Bước 2: Insert dữ liệu mẫu
```sql
-- Chạy file SQL này để insert dữ liệu mẫu
-- File: DNA_Testing_Sample_Data.sql
```

1. Sau khi tạo xong database schema
2. Mở file `DNA_Testing_Sample_Data.sql`
3. Thực thi script để insert dữ liệu mẫu

#### Bước 3: Tạo Views và Stored Procedures
```sql
-- Chạy file SQL này để tạo views và stored procedures
-- File: DNA_Testing_Views_Procedures.sql
```

1. Mở file `DNA_Testing_Views_Procedures.sql`
2. Thực thi script để tạo các views và stored procedures hỗ trợ ứng dụng

### 3. Cấu hình Connection String

#### Cập nhật file `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=DNATestingDB;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;TrustServerCertificate=True;",
    "DNATestingDB": "Server=YOUR_SERVER_NAME;Database=DNATestingDB;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
  }
}
```

**Thay thế:**
- `YOUR_SERVER_NAME`: Tên SQL Server instance của bạn (VD: `localhost`, `DESKTOP-XYZ\\SQLEXPRESS`)
- `YOUR_USERNAME`: Username SQL Server (VD: `sa`)
- `YOUR_PASSWORD`: Password của username

#### Ví dụ connection string:
```json
"DefaultConnection": "Server=DUCKYRICHEST\\MSSQLSERVER1;Database=DNATestingDB;User Id=sa;Password=12345;TrustServerCertificate=True;"
```

### 4. Cấu hình DatabaseConnection Class

Đảm bảo file `DatabaseConnection.cs` đọc đúng connection string:

```csharp
public static string GetConnectionString()
{
    // Đọc từ appsettings.json
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
        
    return configuration.GetConnectionString("DefaultConnection") ?? 
           "Server=DUCKYRICHEST\\MSSQLSERVER1;Database=DNATestingDB;User Id=sa;Password=12345;TrustServerCertificate=True;";
}
```

### 5. Kiểm tra Database đã hoạt động

#### Test Connection:
```csharp
using (var context = new ApplicationDbContext())
{
    try
    {
        var patients = context.Patients.Take(5).ToList();
        Console.WriteLine($"Kết nối thành công! Tìm thấy {patients.Count} bệnh nhân.");
        
        foreach (var patient in patients)
        {
            Console.WriteLine($"- {patient.FullName} ({patient.Email})");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Lỗi kết nối database: {ex.Message}");
    }
}
```

### 6. Dữ liệu mẫu có sẵn

Database đã được insert sẵn dữ liệu mẫu bao gồm:

#### Users (Người dùng):
- **Admin**: admin@dnatesting.com (admin/hashedpassword123)
- **Manager**: manager1@dnatesting.com
- **Staff**: staff1@dnatesting.com, staff2@dnatesting.com
- **Doctor**: doctor1@dnatesting.com
- **Customers**: hoa.nguyen@email.com, nam.tran@email.com, lan.le@email.com

#### Patients (Bệnh nhân):
- Nguyễn Thị Hoa (Nữ, 34 tuổi) - Hoàn thành xét nghiệm
- Trần Văn Nam (Nam, 36 tuổi) - Đang xét nghiệm  
- Lê Thị Lan (Nữ, 32 tuổi) - Chưa xét nghiệm
- Phạm Minh Đức (Nam, 39 tuổi) - Đã hủy
- Hoàng Thị Mai (Nữ, 31 tuổi) - Hoàn thành xét nghiệm

#### DNA Test Services:
- Xét nghiệm ADN xác định huyết thống cha con (2,500,000 VND)
- Xét nghiệm ADN xác định huyết thống mẹ con (2,300,000 VND)
- Xét nghiệm ADN xác định huyết thống anh em (2,800,000 VND)
- Xét nghiệm ADN pháp y (3,500,000 VND)
- Xét nghiệm ADN định danh cá nhân (2,000,000 VND)
- Xét nghiệm ADN gia đình mở rộng (4,000,000 VND)

### 7. Cấu trúc Database chính

#### Tables quan trọng:
- **Users**: Quản lý người dùng hệ thống
- **Patients**: Thông tin bệnh nhân
- **DNATestServices**: Các dịch vụ xét nghiệm ADN
- **DNATestRegistrations**: Đăng ký xét nghiệm
- **SampleCollections**: Thu thập mẫu xét nghiệm
- **TestProgress**: Tiến độ xét nghiệm
- **TestResults**: Kết quả xét nghiệm
- **PatientFeedback**: Đánh giá và phản hồi
- **Notifications**: Hệ thống thông báo
- **BlogPosts**: Quản lý nội dung blog

#### Views hỗ trợ:
- **vw_PatientList**: Danh sách bệnh nhân với thông tin xét nghiệm ADN
- **vw_DNATestRegistrationDetails**: Chi tiết đăng ký xét nghiệm
- **vw_DashboardStats**: Thống kê dashboard

#### Stored Procedures:
- **sp_GetPatientList**: Lấy danh sách bệnh nhân có lọc
- **sp_CreateDNATestRegistration**: Tạo đăng ký xét nghiệm mới
- **sp_UpdateTestProgress**: Cập nhật tiến độ xét nghiệm
- **sp_GetPatientDNATestHistory**: Lịch sử xét nghiệm của bệnh nhân
- **sp_SubmitPatientFeedback**: Gửi phản hồi đánh giá
- **sp_GetDashboardStatistics**: Lấy thống kê dashboard

### 8. Troubleshooting

#### Lỗi thường gặp:

1. **Không kết nối được database:**
   - Kiểm tra SQL Server đã running
   - Kiểm tra tên server trong connection string
   - Kiểm tra username/password

2. **Database không tồn tại:**
   - Chạy lại script `DNA_Testing_Database_Schema.sql`
   - Đảm bảo script chạy thành công không lỗi

3. **Thiếu dữ liệu:**
   - Chạy script `DNA_Testing_Sample_Data.sql`
   - Kiểm tra các tables đã có dữ liệu

4. **Entity Framework lỗi:**
   - Update package Entity Framework Core
   - Clean và rebuild solution
   - Kiểm tra ApplicationDbContext configuration

### 9. Backup và Restore

#### Tạo backup:
```sql
BACKUP DATABASE DNATestingDB 
TO DISK = 'C:\Backup\DNATestingDB.bak'
WITH FORMAT, INIT;
```

#### Restore từ backup:
```sql
USE master;
RESTORE DATABASE DNATestingDB 
FROM DISK = 'C:\Backup\DNATestingDB.bak'
WITH REPLACE;
```

### 10. Bảo mật Database

1. **Đổi mật khẩu mặc định**
2. **Tạo user riêng cho ứng dụng**
3. **Phân quyền truy cập phù hợp**
4. **Enable encryption nếu cần**
5. **Regular backup data**

---

**Lưu ý**: Đây là database cho môi trường development. Trong production cần có thêm các biện pháp bảo mật và tối ưu hóa hiệu suất.

# DNA Testing Service Management System - Database Summary

## 🧬 Tổng quan Database System

Database `DNATestingDB` được thiết kế để hỗ trợ đầy đủ chức năng của **Bloodline DNA Testing Service Management System** với khả năng quản lý:

- ✅ **Quản lý người dùng**: Admin, Manager, Staff, Customer, Guest
- ✅ **Quản lý bệnh nhân**: Thông tin cá nhân, hồ sơ y tế
- ✅ **Dịch vụ xét nghiệm ADN**: Dân sự, Hành chính, Y tế
- ✅ **Quy trình xét nghiệm**: Thu mẫu, phân tích, trả kết quả
- ✅ **Quản lý lịch hẹn**: Tư vấn, thu mẫu, trả kết quả
- ✅ **Hệ thống đánh giá**: Rating, feedback từ khách hàng
- ✅ **Quản lý nội dung**: Blog, kiến thức ADN
- ✅ **Hệ thống thông báo**: Email, SMS, in-app notifications

---

## 📊 Database Schema

### 🏗️ Cấu trúc chính (15 Tables)

| Table | Mục đích | Records |
|-------|----------|---------|
| **Users** | Quản lý người dùng hệ thống | 8 users |
| **Patients** | Thông tin bệnh nhân | 5 patients |
| **DNATestServices** | Các dịch vụ xét nghiệm ADN | 6 services |
| **DNATestRegistrations** | Đăng ký xét nghiệm | 5 registrations |
| **SampleCollections** | Thu thập mẫu xét nghiệm | 4 collections |
| **TestProgress** | Tiến độ thực hiện xét nghiệm | 11 steps |
| **TestResults** | Kết quả xét nghiệm | 1 result |
| **Appointments** | Lịch hẹn khám/tư vấn | 4 appointments |
| **PatientFeedback** | Đánh giá từ khách hàng | 2 feedbacks |
| **Notifications** | Hệ thống thông báo | 3 notifications |
| **BlogPosts** | Nội dung blog/tin tức | 3 posts |
| **Doctors** | Thông tin bác sĩ | 1 doctor |
| **DoctorSchedules** | Lịch làm việc bác sĩ | 6 schedules |
| **SystemSettings** | Cài đặt hệ thống | 9 settings |
| **AuditLogs** | Nhật ký audit | - |

---

## 🔧 Features hỗ trợ

### 1. **Views (3 views)**
- `vw_PatientList`: Danh sách bệnh nhân với thông tin ADN
- `vw_DNATestRegistrationDetails`: Chi tiết đăng ký xét nghiệm  
- `vw_DashboardStats`: Thống kê tổng quan dashboard

### 2. **Stored Procedures (6 procedures)**
- `sp_GetPatientList`: Lấy danh sách bệnh nhân có phân trang và lọc
- `sp_CreateDNATestRegistration`: Tạo đăng ký xét nghiệm mới
- `sp_UpdateTestProgress`: Cập nhật tiến độ xét nghiệm
- `sp_GetPatientDNATestHistory`: Lịch sử xét nghiệm của bệnh nhân
- `sp_SubmitPatientFeedback`: Gửi đánh giá feedback
- `sp_GetDashboardStatistics`: Lấy thống kê dashboard

### 3. **Indexes (18 indexes)**
Tối ưu hóa performance cho:
- Tìm kiếm bệnh nhân (email, phone)
- Lọc theo trạng thái xét nghiệm
- Thống kê và báo cáo
- Hệ thống thông báo

---

## 🎯 Quy trình xét nghiệm ADN được hỗ trợ

### **Quy trình 1: Tự thu mẫu tại nhà (Dân sự)**
```
1. Đăng ký đặt hẹn dịch vụ xét nghiệm
2. Nhận bộ kit xét nghiệm  
3. Thu thập mẫu xét nghiệm (tự thực hiện)
4. Chuyển mẫu đến cơ sở y tế
5. Thực hiện xét nghiệm tại cơ sở y tế và ghi nhận kết quả
6. Trả kết quả xét nghiệm
```

### **Quy trình 2: Thu mẫu tại cơ sở y tế**
```
1. Đăng ký đặt hẹn dịch vụ xét nghiệm
2. Nhân viên cơ sở y tế thu thập mẫu và cập nhật đơn yêu cầu xét nghiệm
3. Thực hiện xét nghiệm tại cơ sở y tế và ghi nhận kết quả
4. Trả kết quả xét nghiệm
```

---

## 💰 Dịch vụ và Bảng giá

| Mã dịch vụ | Tên dịch vụ | Loại | Giá (VND) | Thời gian |
|------------|-------------|------|-----------|----------|
| **DNA001** | Xét nghiệm ADN xác định huyết thống cha con | Dân sự | 2,500,000 | 7 ngày |
| **DNA002** | Xét nghiệm ADN xác định huyết thống mẹ con | Dân sự | 2,300,000 | 7 ngày |
| **DNA003** | Xét nghiệm ADN xác định huyết thống anh em | Dân sự | 2,800,000 | 10 ngày |
| **DNA004** | Xét nghiệm ADN pháp y | Hành chính | 3,500,000 | 14 ngày |
| **DNA005** | Xét nghiệm ADN định danh cá nhân | Y tế | 2,000,000 | 5 ngày |
| **DNA006** | Xét nghiệm ADN gia đình mở rộng | Dân sự | 4,000,000 | 14 ngày |

---

## 👥 Accounts mặc định

### **Admin Account**
- **Username**: admin
- **Email**: admin@dnatesting.com  
- **Password**: hashedpassword123
- **Role**: Admin (Full access)

### **Manager Account**
- **Username**: manager1
- **Email**: manager1@dnatesting.com
- **Role**: Manager (Management access)

### **Staff Accounts**
- **staff1@dnatesting.com** - Trần Thị Nhân (Staff)
- **staff2@dnatesting.com** - Lê Văn Viên (Staff)
- **doctor1@dnatesting.com** - BS. Phạm Minh Tuấn (Doctor)

### **Customer Accounts**
- **hoa.nguyen@email.com** - Nguyễn Thị Hoa (Customer)
- **nam.tran@email.com** - Trần Văn Nam (Customer)  
- **lan.le@email.com** - Lê Thị Lan (Customer)

---

## 📁 File Structure

```
Database/
├── DNA_Testing_Database_Schema.sql      # Database schema and tables
├── DNA_Testing_Sample_Data.sql          # Sample data insertion
├── DNA_Testing_Views_Procedures.sql     # Views and stored procedures
├── Deploy_Complete_Database.sql         # Complete deployment script
├── Deploy-Database.ps1                  # PowerShell deployment script
└── README_Database_Setup.md             # Setup instructions
```

---

## 🚀 Deployment Steps

### **Option 1: Manual Deployment**
1. Run `DNA_Testing_Database_Schema.sql`
2. Run `DNA_Testing_Sample_Data.sql`  
3. Run `DNA_Testing_Views_Procedures.sql`

### **Option 2: PowerShell Deployment**
```powershell
.\Deploy-Database.ps1 -ServerName "YOUR_SERVER" -Username "sa" -Password "YOUR_PASSWORD"
```

### **Option 3: Single Script Deployment**
```sql
-- Run Deploy_Complete_Database.sql
```

---

## 🔗 Connection String

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=DNATestingDB;User Id=sa;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
  }
}
```

**Ví dụ:**
```json
"DefaultConnection": "Server=DUCKYRICHEST\\MSSQLSERVER1;Database=DNATestingDB;User Id=sa;Password=12345;TrustServerCertificate=True;"
```

---

## ✅ Verification Checklist

- [ ] Database `DNATestingDB` được tạo thành công
- [ ] 15 tables được tạo với đúng structure
- [ ] Sample data được insert (8 users, 5 patients, 6 services)
- [ ] 3 views hoạt động đúng
- [ ] 6 stored procedures hoạt động đúng
- [ ] 18 indexes được tạo để tối ưu performance
- [ ] Connection string được cập nhật trong appsettings.json
- [ ] Application kết nối database thành công
- [ ] Các chức năng trong UI hoạt động với database

---

## 🛡️ Security & Best Practices

### **Implemented**
- ✅ Foreign key constraints
- ✅ Data validation through CHECK constraints
- ✅ Audit logging system
- ✅ Proper indexes for performance
- ✅ User role-based access

### **Recommended for Production**
- 🔒 Change default passwords
- 🔒 Create dedicated application user
- 🔒 Enable database encryption
- 🔒 Regular backup schedule
- 🔒 Security auditing
- 🔒 Network security configuration

---

## 📈 Performance Considerations

- **Optimized queries** with proper WHERE clauses
- **Strategic indexing** on frequently queried columns
- **Pagination support** in stored procedures
- **Minimal data transfer** through DTOs
- **Cached views** for dashboard statistics

---

## 🔧 Maintenance

### **Regular Tasks**
- Update statistics weekly
- Rebuild indexes monthly  
- Backup database daily
- Monitor query performance
- Clean old audit logs
- Update sample data as needed

### **Monitoring**
- Track database size growth
- Monitor active connections
- Watch for blocking queries
- Check backup success
- Review audit logs

---

**Database đã sẵn sàng để tích hợp với DNA Testing Service Management System!** 🎉

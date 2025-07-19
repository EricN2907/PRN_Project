## DNA Testing Service Management System - Role-Based Access Control

### Hệ thống phân quyền người dùng đã được triển khai:

## 🔐 **Các Role và Quyền hạn:**

### 1. **Admin** (Quản trị viên)
- ✅ **Toàn quyền truy cập hệ thống**
- ✅ Quản lý người dùng
- ✅ Quản lý bệnh nhân
- ✅ Quản lý dịch vụ xét nghiệm ADN
- ✅ Xem Dashboard đầy đủ
- ✅ Xem báo cáo tổng hợp
- ✅ Quản lý bảng giá
- ✅ Quản lý hệ thống

### 2. **Manager** (Quản lý)
- ✅ Quản lý bệnh nhân
- ✅ Quản lý dịch vụ xét nghiệm
- ✅ Xem Dashboard quản lý
- ✅ Xem báo cáo tổng hợp
- ✅ Quản lý bảng giá
- ✅ Quản lý lịch hẹn
- ❌ Không có quyền quản lý hệ thống

### 3. **Staff** (Nhân viên)
- ✅ Xem danh sách bệnh nhân
- ✅ Thêm/sửa thông tin bệnh nhân
- ✅ Quản lý lịch hẹn
- ✅ Cập nhật tiến độ xét nghiệm
- ✅ Xem Dashboard cá nhân
- ❌ Không có quyền quản lý dịch vụ
- ❌ Không có quyền xem báo cáo tổng hợp
- ❌ Không có quyền quản lý bảng giá

### 4. **Customer** (Khách hàng)
- ✅ Xem thông tin cá nhân
- ✅ Đặt lịch xét nghiệm ADN
- ✅ Xem kết quả xét nghiệm của mình
- ✅ Yêu cầu kit xét nghiệm
- ✅ Xem lịch sử xét nghiệm
- ✅ Dashboard cá nhân
- ❌ Không thể xem thông tin bệnh nhân khác
- ❌ Không có quyền quản lý

### 5. **Guest** (Khách)
- ✅ Xem thông tin dịch vụ công khai
- ❌ Không thể truy cập dữ liệu cá nhân
- ❌ Không thể đặt lịch hẹn

## 🛡️ **Tính năng bảo mật đã triển khai:**

### **SessionManager**
- Quản lý phiên đăng nhập
- Kiểm tra quyền truy cập
- Lưu trữ thông tin user hiện tại

### **Permission System**
- `ViewPatients` - Xem danh sách bệnh nhân
- `ManagePatients` - Quản lý bệnh nhân
- `ViewReports` - Xem báo cáo
- `ManageServices` - Quản lý dịch vụ
- `ManageAppointments` - Quản lý lịch hẹn
- `ViewDashboard` - Xem Dashboard
- `ManagePricing` - Quản lý giá
- `ViewOwnData` - Xem dữ liệu cá nhân
- `BookAppointment` - Đặt lịch hẹn
- `ViewOwnResults` - Xem kết quả của mình
- `RequestKit` - Yêu cầu kit
- `ViewProgress` - Xem tiến độ
- `UpdateProgress` - Cập nhật tiến độ

## 📱 **UI được tùy chỉnh theo Role:**

### **PatientsPage**
- **Customer**: Chỉ xem được thông tin cá nhân
- **Staff**: Xem tất cả bệnh nhân, có thể thêm/sửa
- **Manager/Admin**: Toàn quyền + quick actions

### **DashboardPage**
- **Customer**: Dashboard cá nhân với thông tin xét nghiệm của mình
- **Staff**: Dashboard công việc với task hàng ngày
- **Manager/Admin**: Dashboard tổng quan với thống kê đầy đủ

### **TreatmentServicesPage**
- **Customer**: Chỉ xem dịch vụ để đặt lịch
- **Staff**: Xem tất cả dịch vụ
- **Manager/Admin**: Quản lý dịch vụ

## 🔒 **Các thông báo bảo mật:**
- "Bạn không có quyền truy cập chức năng này!"
- "Bạn không có quyền xem thông tin này!"
- "Vui lòng đăng nhập để tiếp tục!"

## 🧪 **Test Cases cho Role-based Access:**

### **Test với Customer:**
1. Đăng nhập với tài khoản customer
2. Kiểm tra chỉ thấy dữ liệu cá nhân
3. Thử truy cập chức năng quản lý → Bị từ chối
4. Xem dashboard chỉ có thông tin cá nhân

### **Test với Staff:**
1. Đăng nhập với tài khoản staff
2. Kiểm tra có thể quản lý bệnh nhân
3. Thử truy cập báo cáo tổng hợp → Bị từ chối
4. Xem dashboard có task công việc

### **Test với Manager/Admin:**
1. Đăng nhập với tài khoản manager/admin
2. Kiểm tra có toàn quyền truy cập
3. Xem dashboard tổng quan đầy đủ
4. Truy cập tất cả chức năng

## 📝 **Hướng dẫn sử dụng:**

1. **Login với các tài khoản test:**
   - Admin: `admin` / `hashedpassword123`
   - Manager: `manager1` / `hashedpassword123`
   - Staff: `staff1` / `hashedpassword123`
   - Customer: `customer1` / `hashedpassword123`

2. **Kiểm tra phân quyền:**
   - Mỗi role sẽ thấy giao diện khác nhau
   - Thử truy cập các chức năng để test permission
   - Quan sát các thông báo từ chối quyền truy cập

**Hệ thống Role-based Access Control đã được triển khai thành công! 🎉**

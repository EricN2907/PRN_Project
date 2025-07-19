using DNA.BussinessObject;

namespace DNA.WpfApp.Utils
{
    public static class SessionManager
    {
        private static User? _currentUser;

        public static User? CurrentUser
        {
            get => _currentUser;
            set => _currentUser = value;
        }

        public static string? CurrentUserRole => _currentUser?.UserType;

        public static string? CurrentUserName => _currentUser?.FullName;

        public static int? CurrentUserId => _currentUser?.UserId;

        public static bool IsAdmin => _currentUser?.UserType == "Admin";

        public static bool IsManager => _currentUser?.UserType == "Manager";

        public static bool IsStaff => _currentUser?.UserType == "Staff";

        public static bool IsCustomer => _currentUser?.UserType == "Customer";

        public static bool IsGuest => _currentUser == null;

        public static bool HasPermission(string permission)
        {
            if (_currentUser == null) return false;

            return _currentUser.UserType switch
            {
                "Admin" => true, // Admin có tất cả quyền
                "Manager" => permission switch
                {
                    "ViewPatients" => true,
                    "ManagePatients" => true,
                    "ViewReports" => true,
                    "ManageServices" => true,
                    "ManageAppointments" => true,
                    "ViewDashboard" => true,
                    "ManagePricing" => true,
                    _ => false
                },
                "Staff" => permission switch
                {
                    "ViewPatients" => true,
                    "ManagePatients" => true,
                    "ManageAppointments" => true,
                    "ViewProgress" => true,
                    "UpdateProgress" => true,
                    _ => false
                },
                "Customer" => permission switch
                {
                    "ViewOwnData" => true,
                    "BookAppointment" => true,
                    "ViewOwnResults" => true,
                    "RequestKit" => true,
                    _ => false
                },
                _ => false
            };
        }

        public static void SetCurrentUser(User user)
        {
            _currentUser = user;
        }

        public static void ClearSession()
        {
            _currentUser = null;
        }
    }
}

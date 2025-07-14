using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNA.BussinessObject;
using DNA.Repository;
namespace DNA.Service
{
    public class UserService : IUserService
    {
        public User Login(string username, string password)
        {
            using var db = new ApplicationDbContext();
            return db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}

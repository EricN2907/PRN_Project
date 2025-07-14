using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNA.BussinessObject;

namespace DNA.Service
{
    public interface IUserService
    {
        User Login(string username, string password);
    }
}

using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int userId);
        void AddUser(User user);
        void UpdateUser(User user);
        void RemoveUser(User user);
    }
}

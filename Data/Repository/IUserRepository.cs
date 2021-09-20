using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Repository
{
    interface IUserRepository
    {
        IEnumerable<User> GetUser();
        User GetUserById(int id);
        void AddUser(User customer);
        void UpdateUser(User user,int id);
        void DeleteUser(int id);
        void Save();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Repository
{
   public interface IUserRepository<T> where T : class
    {
        IEnumerable<T> GetUser();
        T GetUserById(int id);
        void AddUser(T customer);
        void UpdateUser(User user,int id);
        void UpdateProduct(Product prod, int id);
        void DeleteData(int? id);
        void changepassword(string str , int id);
        void Save();
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {

        private AquariumModel db;
        public UserRepository(AquariumModel db)
        {
            this.db = db;
        }

        public IEnumerable<User> GetUser()
        {
            return db.Users.ToList();
        }


        public void AddUser(User customer)
        {
            db.Users.Add(customer);
            Save();
        }

        public User GetUserById(int id)
        {
            if (id > 0)
            {
                var user = db.Users.Find(id);
                if (user != null)
                    return user;
                else
                    return null;
            }
            else
            {
                throw new ArgumentException("Id cannot be less than 0");
            }
        }



        public void UpdateUser(User user,int id)
        {
            User updatedUser = (from c in db.Users
                              where c.id == id
                              select c).FirstOrDefault();
            updatedUser.name = user.name;
            updatedUser.email = user.email;
            updatedUser.phone_Number = user.phone_Number;
            Save();

        }

        public void DeleteUser(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                Save();
            }
            else
                throw new ArgumentException("Cat is not found");
        }


        public User checkUser(User user)
        {
            return db.Users.Where(e => e.email == user.email && e.password == user.password).FirstOrDefault();
 
        }
        public void Save()
        {
            db.SaveChanges();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;


namespace Data.Repository
{
    public class UserRepository<T> : IUserRepository<T> where T : class
    {
        private AquariumModel context ;
        private IDbSet<T> dbEntity;

        public UserRepository()
        {
            // this.db = db;
            this.context = new AquariumModel();
            dbEntity = context.Set<T>();

        }
        public UserRepository(AquariumModel context)
        {
            // this.db = db;
            this.context = new AquariumModel();
            dbEntity = context.Set<T>();

        }


        public IEnumerable<T> GetUser()
        {
            return dbEntity.ToList();
        }


        public void AddUser(T data)
        {
            dbEntity.Add(data);
            Save();
        }

        public T GetUserById(int id)
        {
           // return dbEntity.Find(id);
            if (id > 0)
            {
                var user = dbEntity.Find(id);
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



        public void UpdateUser(User user, int id)
        {
            
            User updatedUser = (from c in context.Users
                                where c.id == id
                                select c).FirstOrDefault();
            updatedUser.name = user.name;
            updatedUser.email = user.email;
            updatedUser.phone_Number = user.phone_Number;
            Save();

        }

        public void UpdateProduct(Product prod, int id)
        {
            Product updatedProduct = (from c in context.Products
                                where c.Id == id
                                select c).FirstOrDefault();
            updatedProduct.Name = prod.Name;
            updatedProduct.Quantity = prod.Quantity;
            updatedProduct.Price = prod.Price;                       
            Save();

        }



        public void DeleteData(int? id)
        {
            var user = dbEntity.Find(id);
            if (user != null)
            {
               dbEntity.Remove(user);
                Save();
            }
            else
                throw new ArgumentException("Data is not found");
        }


        public User checkUser(User user)
        {
            return context.Users.Where(e => e.email == user.email && e.password == user.password).FirstOrDefault();

        }
        public void Save()
        {
            context.SaveChanges();
        }

        public void changepassword(string cPass, int id)
        {
            var user = context.Users.Find(id);
            user.password = cPass;
            Save();
        }

        public IEnumerable<ProductType> getProductType()
        {
            return context.ProductTypes.ToList();
        }

    }
}

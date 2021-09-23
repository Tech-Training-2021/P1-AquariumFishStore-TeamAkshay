using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using P1_AquariumFishStore_TeamAkshay.Models;

namespace P1_AquariumFishStore_TeamAkshay.Models
{
    public class Mapper
    {
        public static P1_AquariumFishStore_TeamAkshay.Models.User Map(Data.Entities.User user)
        {
            Password pass = new Password();

            return new P1_AquariumFishStore_TeamAkshay.Models.User()
            {
                UserId = user.id,
                Name = user.name,
                email = user.email,
                role = user.role.role1,
                gender=user.gender.gender1,
                password= pass.encodePassword(user.password),
                mobileNo=user.phone_Number

            };
        }

        public static Data.Entities.User Map(P1_AquariumFishStore_TeamAkshay.Models.User user)
        {
            return new Data.Entities.User()
            {
                name = user.Name,
                email = user.email,
                phone_Number = user.mobileNo

            };
        }



        public static Data.Entities.User Map(UserRegister user)
        {
            Password pass = new Password();

            return new Data.Entities.User()
            {

                name = user.Name,
                roleId=2,
                email = user.Email,
                genderId = user.Gender,
                phone_Number=user.mobileNo,
                password= pass.encodePassword(user.Password)

            };
        }

        public static Data.Entities.User Map(UserLogin user)
        {
            Password pass = new Password();

            return new Data.Entities.User()
            {
                email = user.Email,   
                password = pass.encodePassword(user.Password)

            };
        }

       
        public static IEnumerable<Product> Map(Data.Entities.Product product)
        {
            P1_AquariumFishStore_TeamAkshay.Models.Product xyz;
            List<Product> pro = new List<Product>();
            foreach (var p in product.LocationJunctions)
            {
                xyz = new P1_AquariumFishStore_TeamAkshay.Models.Product()
                {

                    Id = product.Id,
                    Price = product.Price,
                    Name = product.Name,
                    Location = p.LocationTable.Branch,
                    Quantity = product.Quantity,
                    ProductType = product.ProductType.Category,
                    locationId = (int)p.LocationId,

                };
                pro.Add(xyz);
            }
            return pro;

        }

        public static Data.Entities.Product Map(P1_AquariumFishStore_TeamAkshay.Models.Product prod)
        {
            return new Data.Entities.Product()
            {
                Name = prod.Name,
                Quantity = prod.Quantity,
                Price = prod.Price

            };
        }

        public static P1_AquariumFishStore_TeamAkshay.Models.category Map(Data.Entities.ProductType category)
        {
            return new P1_AquariumFishStore_TeamAkshay.Models.category()
            {
                Id= category.Id,
                Category=category.Category

            };
        }

        public static Data.Entities.ProductType Map(P1_AquariumFishStore_TeamAkshay.Models.category categ)
        {
            return new Data.Entities.ProductType()
            {
                Id =categ.Id,
                Category = categ.Category
            };
        }

        public static P1_AquariumFishStore_TeamAkshay.Models.OrderDetailModel Map(Data.Entities.OrderDetail order)
        {
            return new P1_AquariumFishStore_TeamAkshay.Models.OrderDetailModel()
            {
               OrderDetailId = order.OrderDetailId,
               OrderId = order.OrderId,
               ProductId = order.ProductId,
               Quantity= order.Quantity,
               UnitPrice = order.UnitPrice,
               Total=order.Total

            };
        }

        public static P1_AquariumFishStore_TeamAkshay.Models.location Map(Data.Entities.LocationTable loc)
        {
            return new P1_AquariumFishStore_TeamAkshay.Models.location()
            {
                Id = loc.Id,
                Branch = loc.Branch

            };
        }


        public static Data.Entities.LocationTable Map(P1_AquariumFishStore_TeamAkshay.Models.location loc)
        {
            return new Data.Entities.LocationTable()
            {
                Branch=loc.Branch
            };
        }

       

    }
}
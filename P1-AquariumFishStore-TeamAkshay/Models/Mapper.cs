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
            return new P1_AquariumFishStore_TeamAkshay.Models.User()
            {
                UserId = user.id,
                Name = user.name,
                email = user.email,
                role = user.role.role1,
                gender=user.gender.gender1,
                password=user.password,
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
            return new Data.Entities.User()
            {
                name = user.Name,
                roleId=2,
                email = user.Email,
                genderId = user.Gender,
                phone_Number=user.mobileNo,
                password=user.Password
                
            };
        }

        public static Data.Entities.User Map(UserLogin user)
        {
            return new Data.Entities.User()
            {
                email = user.Email,   
                password = user.Password

            };
        }

       
        public static P1_AquariumFishStore_TeamAkshay.Models.Product Map(Data.Entities.Product product)
        {
            return new P1_AquariumFishStore_TeamAkshay.Models.Product()
            {
               
                Id = product.Id,
                Price = product.Price,
                Name = product.Name,
                Quantity = product.Quantity,
                ProductType = product.ProductType.Category,
            
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

        public static P1_AquariumFishStore_TeamAkshay.Models.Orders Map(Data.Entities.OrderTable order)
        {
            return new P1_AquariumFishStore_TeamAkshay.Models.Orders()
            {
               Id = order.Id,
               Username = order.User.name,
               Productname= order.Product.Name,
               Location = order.LocationTable.Branch,
               Quantity= order.Quantity,
               TotalPrice = order.TotalPrice
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
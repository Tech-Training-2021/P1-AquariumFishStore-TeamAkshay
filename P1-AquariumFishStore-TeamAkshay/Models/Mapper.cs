using System;
using System.Collections.Generic;
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
    }
}
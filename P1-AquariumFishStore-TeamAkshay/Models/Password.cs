using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P1_AquariumFishStore_TeamAkshay.Models
{
    public class Password
    {
        public  string encodePassword(string password)
        {
            try
            {
                byte[] passByte = new byte[password.Length];
                passByte = System.Text.Encoding.UTF8.GetBytes(password);
                string encriptedPassword = Convert.ToBase64String(passByte);
                return encriptedPassword;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in encryption" + ex);
            }
        }
    }
}
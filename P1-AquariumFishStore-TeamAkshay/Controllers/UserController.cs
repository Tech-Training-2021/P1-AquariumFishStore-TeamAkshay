using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data.Entities;
using Data.Repository;
using P1_AquariumFishStore_TeamAkshay.Models;



namespace P1_AquariumFishStore_TeamAkshay.Controllers
{
    public class UserController : Controller
    {
        IUserRepository<Data.Entities.User> interfaceobj;

       
        public UserController()
        {
            this.interfaceobj = new UserRepository<Data.Entities.User>();
        }


        // GET: User
        public ActionResult Index()
        {
            var user = interfaceobj.GetUser();
            var data = new List<P1_AquariumFishStore_TeamAkshay.Models.User>();
            foreach (var c in user)
            {
                data.Add(Mapper.Map(c));
            }
            return View(data);

        }

        public ActionResult GetUserById(int id)
        {
            var user = interfaceobj.GetUserById(id);
            if(user!=null)
                return View(Mapper.Map(user));
            return RedirectToAction("Dashbaord","User");
        }



        public ActionResult userRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult userRegister(UserRegister user)
        {
            if (ModelState.IsValid)
            {
                interfaceobj.AddUser(Mapper.Map(user));
                return RedirectToAction("userLogin","User");
            }
            return View(user);
        }

        public ActionResult userLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult userLogin(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                UserRepository<Data.Entities.User> repo;
                repo = new UserRepository<Data.Entities.User>(new AquariumModel());
                
                var userData = repo.checkUser(Mapper.Map(user));
                if (userData != null)
                {
                    if (userData.roleId == 1)
                    {
                        Session["UserId"] = userData.id;
                        Session["UserName"] = userData.name;
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else
                    {
                        Session["UserId"] = userData.id;
                        Session["UserName"] = userData.name;
                        return RedirectToAction("Dashboard", "User");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username and/or Password");
                }
                
  
            }
            return View();
        }

        public ActionResult userLogout()
        {
            Session.Abandon();
            return RedirectToAction("userLogin", "User");

        }

        public ActionResult update(int id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var user = interfaceobj.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map(user));


        }

        [HttpPost]
        public ActionResult update(P1_AquariumFishStore_TeamAkshay.Models.User user)
        {
            int id = (int)Session["UserId"];
            interfaceobj.UpdateUser(Mapper.Map(user), id);
            return RedirectToAction("Dashboard", "User");
        }


       

        public ActionResult delete(int? id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            interfaceobj.DeleteData(id);
            Session.Abandon();
            return RedirectToAction("userLogin", "User");

        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

            [HttpPost]
        public ActionResult ChangePassword(changePassword reset , int id)
        {
            Password pass = new Password();

            var user = interfaceobj.GetUserById(id);
            string oldPass = user.password;            
            string encryptedPass = pass.encodePassword(reset.Oldpassword);
            string newEncPass = pass.encodePassword(reset.password);
            if(encryptedPass == oldPass)
            {
                try
                {
                    interfaceobj.changepassword(newEncPass,id);
                    ModelState.AddModelError("", "Password Updated Successfully.");
                    RedirectToAction("GetUserById", "User");
                }
                catch(Exception ex)
                {
                    throw new Exception("Error in Updating Password");   
                }
            }
            else
            {
                ModelState.AddModelError("","The Old Password is wrong.");
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }

       
    }
}
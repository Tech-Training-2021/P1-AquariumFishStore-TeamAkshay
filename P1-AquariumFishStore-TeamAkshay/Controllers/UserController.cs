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
            return RedirectToAction("index");
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
                return RedirectToAction("Index");
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
                        return RedirectToAction("Index", "Home");
                    }
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
            return RedirectToAction("index", "User");
        }


       

        public ActionResult delete(int? id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            interfaceobj.DeleteUser(id);
            Session.Abandon();
            return RedirectToAction("userLogin", "User");


        }






    }
}
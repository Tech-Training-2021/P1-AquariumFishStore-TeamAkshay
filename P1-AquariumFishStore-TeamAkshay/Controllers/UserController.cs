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
        UserRepository repo;
        public UserController()
        {
            repo = new UserRepository(new AquariumModel());
        }


        // GET: User
        public ActionResult Index()
        {
            var user = repo.GetUser();
            var data = new List<P1_AquariumFishStore_TeamAkshay.Models.User>();
            foreach (var c in user)
            {
                data.Add(Mapper.Map(c));
            }
            return View(data);

        }

        public ActionResult GetUserById(int id)
        {
            var user = repo.GetUserById(id);
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
                repo.AddUser(Mapper.Map(user));
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
                var userData = repo.checkUser(Mapper.Map(user));
                if (userData != null)
                {
                    Session["UserId"] = userData.id;
                    Session["UserName"] = userData.name;
                    return RedirectToAction("Index", "Home");

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
            var user = repo.GetUserById(id);
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
            repo.UpdateUser(Mapper.Map(user),id);
            return RedirectToAction("index","User");
        }

        public ActionResult delete(int id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            repo.DeleteUser(id);
            Session.Abandon();
            return RedirectToAction("userLogin", "User");


        }








    }
}
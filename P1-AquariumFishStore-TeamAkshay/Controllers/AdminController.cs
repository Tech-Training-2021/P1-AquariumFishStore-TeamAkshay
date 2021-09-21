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
    public class AdminController : Controller
    {
        // GET: Admin
        IUserRepository<Data.Entities.ProductType> category;
        IUserRepository<Data.Entities.Product> product;
        IUserRepository<Data.Entities.OrderTable> order;
        IUserRepository<Data.Entities.User> user;
        IUserRepository<Data.Entities.LocationTable> location;


        public AdminController()
        {
            this.category = new UserRepository<Data.Entities.ProductType>();
            this.product = new UserRepository<Data.Entities.Product>();
            this.order = new UserRepository<Data.Entities.OrderTable>();
            this.user = new UserRepository<Data.Entities.User>();
            this.location = new UserRepository<Data.Entities.LocationTable>();
        }
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Categories()
        {
            var cat = category.GetUser();
            var data = new List<P1_AquariumFishStore_TeamAkshay.Models.category>();
            foreach (var c in cat)
            {
                data.Add(Mapper.Map(c));
            }
            return View(data);
        }

        public ActionResult Products()
        {
            var prod = product.GetUser();
            var data = new List<P1_AquariumFishStore_TeamAkshay.Models.Product>();
            foreach (var c in prod)
            {
                data.Add(Mapper.Map(c));
            }
            return View(data);
        }

        public ActionResult OrderHistory()
        {
            var OHistory = order.GetUser();
            var data = new List<P1_AquariumFishStore_TeamAkshay.Models.Orders>();
            foreach (var c in OHistory)
            {
                data.Add(Mapper.Map(c));
            }
            return View(data);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(category categ)
        {
            if (ModelState.IsValid)
            {
                category.AddUser(Mapper.Map(categ));
                return RedirectToAction("Categories", "Admin");
            }
            return View(categ);
        }

        // User deatils.

        public ActionResult UserDetails()
        {
            var userD = user.GetUser();
            var data = new List<P1_AquariumFishStore_TeamAkshay.Models.User>();
            foreach (var c in userD)
            {
                data.Add(Mapper.Map(c));
            }
            return View(data);
        }

        
        public ActionResult deleteCustomer(int? id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            user.DeleteData(id);
            Session.Abandon();
            return RedirectToAction("UserDetails", "Admin");

        }

        public ActionResult deleteLocation(int? id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            location.DeleteData(id);
            Session.Abandon();
            return RedirectToAction("Locations", "Admin");

        }

        public ActionResult deleteCategory(int? id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            category.DeleteData(id);
            Session.Abandon();
            return RedirectToAction("Categories", "Admin");

        }

        public ActionResult Locations()
        {
            var loc = location.GetUser();
            var data = new List<P1_AquariumFishStore_TeamAkshay.Models.location>();
            foreach (var c in loc)
            {
                data.Add(Mapper.Map(c));
            }
            return View(data);
        }

        public ActionResult AddLocation()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult AddLocation(location loc)
        {
            if (ModelState.IsValid)
            {
                location.AddUser(Mapper.Map(loc));
                return RedirectToAction("Locations", "Admin");
            }
            return View(loc);
        }

    }
}



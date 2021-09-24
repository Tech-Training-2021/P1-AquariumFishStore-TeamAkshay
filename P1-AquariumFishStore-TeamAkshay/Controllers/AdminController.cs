using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data.Entities;
using Data.Repository;
using P1_AquariumFishStore_TeamAkshay.Models;
using Product = P1_AquariumFishStore_TeamAkshay.Models.Product;

namespace P1_AquariumFishStore_TeamAkshay.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        IUserRepository<Data.Entities.ProductType> category;
        IUserRepository<Data.Entities.Product> product;
        IUserRepository<Data.Entities.OrderDetail> order;
        IUserRepository<Data.Entities.User> user;
        IUserRepository<Data.Entities.LocationTable> location;


        public AdminController()
        {
            this.category = new UserRepository<Data.Entities.ProductType>();
            this.product = new UserRepository<Data.Entities.Product>();
            this.order = new UserRepository<Data.Entities.OrderDetail>();
            this.user = new UserRepository<Data.Entities.User>();
            this.location = new UserRepository<Data.Entities.LocationTable>();
        }
        public ActionResult Dashboard()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
            return View();
           
        }

        public ActionResult Categories()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
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
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
            var prod = product.GetUser();
            var data = new List<P1_AquariumFishStore_TeamAkshay.Models.Product>();
            foreach (var c in prod)
            {
                data.AddRange(Mapper.Map(c));
            }
            return View(data);
        }

        public ActionResult productUpdate(int id ,string loc)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
            Session["productId"] = id;
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var pro = product.GetUserById(id);
            P1_AquariumFishStore_TeamAkshay.Models.Product mainPro = new Models.Product();

            if (pro == null)
            {
                return HttpNotFound();
            }
            else
            {
                var proList = Mapper.Map(pro);
                foreach (var x in proList)
                {
                    if (x.Location == loc)
                    {
                        mainPro = x;
                        break;
                    }
                }
            }
            return View(mainPro);
        }

        [HttpPost]
        public ActionResult productUpdate(P1_AquariumFishStore_TeamAkshay.Models.Product upProduct)
        {
            int id = int.Parse(Session["productId"].ToString());
            product.UpdateProduct(Mapper.Map(upProduct),id);
            Session["productId"] = null;
            return  RedirectToAction("Products","Admin");
        }

        public ActionResult OrderHistory()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
            var OHistory = order.GetUser();
            var data = new List<P1_AquariumFishStore_TeamAkshay.Models.OrderDetailModel>();
            foreach (var c in OHistory)
            {
                data.Add(Mapper.Map(c));
            }
            return View(data);
        }

        public ActionResult AddCategory()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
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
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
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
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            user.DeleteData(id);
        
            return RedirectToAction("UserDetails", "Admin");

        }

        public ActionResult deleteLocation(int? id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            location.DeleteData(id);
            
            return RedirectToAction("Locations", "Admin");

        }

        public ActionResult deleteCategory(int? id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            category.DeleteData(id);
            
            return RedirectToAction("Categories", "Admin");

        }

        public ActionResult Locations()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
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
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
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

        public ActionResult productDelete(int id, int locId)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
            product.DeletePro(id, locId);
            return RedirectToAction("Products", "Admin");

        }

        public ActionResult AddProduct()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
            return View();

        }

    }
}



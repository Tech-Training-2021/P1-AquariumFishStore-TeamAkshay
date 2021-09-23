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
        IUserRepository<Data.Entities.Product> product;
        private Data.Entities.AquariumModel dataEntity;
        private List<ShoppingCartModel> listOfShoppingCart;



        public UserController()
        {
            this.interfaceobj = new UserRepository<Data.Entities.User>();
            this.product = new UserRepository<Data.Entities.Product>();
            dataEntity = new AquariumModel();
            listOfShoppingCart = new List<ShoppingCartModel>();

        }


        // GET: User
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
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
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
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
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
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
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            interfaceobj.DeleteData(id);
            Session.Abandon();
            return RedirectToAction("userLogin", "User");

        }

        public ActionResult Dashboard()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
            return View();
        }

        public ActionResult ChangePassword()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
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


        public ActionResult shopnow()
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
        [HttpPost]
        public JsonResult shopnow(int ItemId)
        {
            ShoppingCartModel objShoppingCartModel = new ShoppingCartModel();
            Data.Entities.Product objItem = dataEntity.Products.Single(model => model.Id == ItemId);
            if (Session["CartCounter"] != null)
            {
                listOfShoppingCart = Session["CartItem"] as List<ShoppingCartModel>;
            }
            if (listOfShoppingCart.Any(model => model.ProductId == ItemId))
            {
                objShoppingCartModel = listOfShoppingCart.Single(model => model.ProductId == ItemId);
                objShoppingCartModel.Quantity += 1;
                objShoppingCartModel.Total = objShoppingCartModel.Quantity * objShoppingCartModel.UnitPrice;
            }
            else
            {
                objShoppingCartModel.ProductId = ItemId;
                objShoppingCartModel.ProductName = objItem.Name;
                objShoppingCartModel.Quantity = 1;
                objShoppingCartModel.Total = objItem.Price;
                objShoppingCartModel.UnitPrice = objItem.Price;
                listOfShoppingCart.Add(objShoppingCartModel);
            }
            Session["CartCounter"] = listOfShoppingCart.Count;
            Session["CartItem"] = listOfShoppingCart;
            return Json(new { Success = true, Counter = listOfShoppingCart.Count }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Cart()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("userLogin", "User");
            }
            listOfShoppingCart = Session["CartItem"] as List<ShoppingCartModel>;
            return View(listOfShoppingCart);
        }

        [HttpPost]
        public ActionResult AddOrder()
        {
            int OrderId = 0;
            listOfShoppingCart = Session["CartItem"] as List<ShoppingCartModel>;
            Order orderObj = new Order()
            {
                OrderDate = DateTime.Now,
                OrderNumber = String.Format("{0:ddmmyyyHHmm}", DateTime.Now)
            };

            dataEntity.Orders.Add(orderObj);
            dataEntity.SaveChanges();
            OrderId = orderObj.OrderId;            
            foreach (var item in listOfShoppingCart)
            {
                OrderDetail OrderDetailObj = new OrderDetail();
                OrderDetailObj.Total = item.Total;
                OrderDetailObj.ProductId = item.ProductId;
                OrderDetailObj.OrderId = OrderId;
                OrderDetailObj.Quantity = (int)item.Quantity;
                OrderDetailObj.UnitPrice = item.UnitPrice;
                dataEntity.OrderDetails.Add(OrderDetailObj);
                dataEntity.SaveChanges();
            }
            Session["CartCounter"] = null;
            Session["CartItem"] = null;
            return RedirectToAction("Dashboard", "User");
        }


       
    }

   




}
    
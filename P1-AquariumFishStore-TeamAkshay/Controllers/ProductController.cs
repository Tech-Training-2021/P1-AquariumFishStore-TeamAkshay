using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data.Entities;
using Data.Repository;
using P1_AquariumFishStore_TeamAkshay.Models;
using System.Collections.Generic;


namespace P1_AquariumFishStore_TeamAkshay.Controllers
{
    public class ProductController : Controller
    {
        IUserRepository<Data.Entities.Product> interfaceobj;
        public ProductController()
        {
            this.interfaceobj = new UserRepository<Data.Entities.Product>();
        }

        // GET: Product
        public ActionResult Index()
        {
            var product = interfaceobj.GetUser();
            var data = new List<P1_AquariumFishStore_TeamAkshay.Models.Product>();
            foreach (var c in product)
            {
                data.Add(Mapper.Map(c));
            }
            return View(data);
        }
    }
}
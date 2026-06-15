using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sneaker.Models;

namespace Sneaker.Controllers
{
    public class ProductAPIController : Controller
    {
        // GET: ProductAPI
        public ActionResult ProductAPI()
        {
            WebAPIController api = new WebAPIController();
            return View(api.GetSanPhamList());
        }
    }
}
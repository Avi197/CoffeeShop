using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coffee3.Controllers
{
    public class GalleriesController : Controller
    {
        // GET: Galleries
        public ActionResult Galleries()
        {
            return View();
        }
    }
}
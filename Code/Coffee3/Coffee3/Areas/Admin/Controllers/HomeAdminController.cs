using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Coffee3.Areas.Admin.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class HomeAdminController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Coffee3.Models.Entities;
using Coffee3.Models.Function;

namespace Coffee3.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(adminaccount model, string ReturnUrl)
        {
            if (String.IsNullOrEmpty(model.username))
            {
                ModelState.AddModelError("", "Chưa nhập tên đăng nhập");
                return View("Index", model);
            }
            if (String.IsNullOrEmpty(model.passwordhash))
            {
                ModelState.AddModelError("", "Chưa nhập mật khẩu");
                return View("Index", model);
            }


            var acc = new adminaccountF().Login(model.username, model.passwordhash);


            if (acc == null)
            {
                ModelState.AddModelError("", "Người dùng không tồn tại");
                return View("Index", model);
            }
            else
            {
                Session["Login"] = acc;
                if (string.IsNullOrEmpty(ReturnUrl))
                {

                    return RedirectToAction("Index", "Admin/HomeAdmin");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }
            }

        }

    }
}

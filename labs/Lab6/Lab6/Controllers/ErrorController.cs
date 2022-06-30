using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab6.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            ViewBag.uri = Request.Url.ToString().Split(';')[1];
            ViewBag.method = Request.HttpMethod;
            Response.StatusCode = 404;
            return View();
        }
    }
}
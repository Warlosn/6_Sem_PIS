﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4a.Controllers
{
    public class MResearchController : Controller
    {
        // GET: 

        [HttpGet]
        public ActionResult M01()
        {
            return Content("GET:M01");
        }

        [HttpGet]
        public ActionResult M02()
        {
            return Content("GET:M02");
        }

        [HttpGet]
        public ActionResult M03()
        {
            return Content("GET:M03");
        }

        [HttpGet]
        public ActionResult MXX()
        {
            return Content("MXX");
        }
    }
}
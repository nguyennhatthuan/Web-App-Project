﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCinema.Models.DataAccess;

namespace WebCinema.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {

        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}
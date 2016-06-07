using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers;
using Web.Extension.Filters;

namespace Web.Areas.Common.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Common/Home/
        [LayoutAttribute]
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MESPDC.Areas.MESPDC.Controllers
{
    public class ProductTestController : Controller
    {
        //
        // GET: /MESPDC/ProductTest/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 产品检验
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductTest() 
        {
            return View();
        }

    }
}

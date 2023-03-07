using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TilausDBApp.Controllers
{
    public class TilastotController : Controller
    {
        // GET: Tilastot
        public ActionResult Index()
        {
            return View();
        }
    }
}
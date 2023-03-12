using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OBilet.CaseStudy.Controllers
{
    public class JourneyController : Controller
    {
        [HttpGet]
        public ActionResult Index(JourneyModel model)
        {
            return View(model.Load());
        }
    }
}
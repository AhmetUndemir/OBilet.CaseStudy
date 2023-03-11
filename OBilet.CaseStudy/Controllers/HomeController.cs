using OBilet.Business;
using OBilet.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OBilet.CaseStudy.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View(new IndexModel().Load());
		}
	}
}
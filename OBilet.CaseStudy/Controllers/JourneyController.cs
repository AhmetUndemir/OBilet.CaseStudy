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
		[Route("seferler/{originId}-{destinationId}/{date}")]
		public ActionResult Index(int originId, int destinationId, DateTime date)
		{
			return View(new JourneyModel { originId = originId, destinationId = destinationId, date = date }.Load());
		}

		[HttpPost]
		public ActionResult SearchJourney(JourneyModel model)
		{
			return RedirectToAction("Index", new { originId = model.originId, destinationId = model.destinationId, date = model.date });
		}
	}
}
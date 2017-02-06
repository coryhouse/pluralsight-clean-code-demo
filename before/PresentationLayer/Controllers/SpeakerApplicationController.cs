using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PresentationLayer.Models;
using BusinessLayer;
using DataAccessLayer;

namespace PresentationLayer.Controllers
{
	public class SpeakerApplicationController : Controller
	{
		//
		// GET: /SpeakerApplication/

		public ActionResult Index()
		{
			var model = new SpeakerApplicationModel();

			model.Sessions.Add(new SessionModel()
				{
					Number = 1
				});

			model.Certifications.Add("");
	
			return View(model);
		}

		//
		// POST: /SpeakerApplication/
		[HttpPost]
		public ActionResult Index(SpeakerApplicationModel model)
		{
			if (ModelState.IsValid)
			{
				var speaker = new Speaker()
				{
					FirstName = model.FirstName,
					LastName = model.LastName,
					Email = model.Email,
					Employer = model.Employer,
					Exp = model.YearsExperience,
					BlogURL = model.BlogURL,
					Browser = new BusinessLayer.WebBrowser(Request.Browser.Type, Request.Browser.MajorVersion),
					Certifications = new List<string>(),
					Sessions = new List<Session>()
				};

				foreach (var certification in model.Certifications)
				{
					speaker.Certifications.Add(certification);
				}

				foreach (var session in model.Sessions)
				{
					speaker.Sessions.Add(new BusinessLayer.Session(session.Name, session.Description));
				}

				try
				{
					speaker.Register(new SqlServerCompactRepository());  //HACK: Not using an IoC container to avoid causing confusion.
				}
				catch (BusinessLayer.Speaker.SpeakerDoesntMeetRequirementsException e)
				{
					return View("Sorry");
				}
				catch (BusinessLayer.Speaker.NoSessionsApprovedException e)
				{
					return View("Sorry");
				}

				return View("Congrats");
			}
			return View(model);
		}
	}
}

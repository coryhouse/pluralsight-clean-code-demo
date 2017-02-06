using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PresentationLayer.Models
{
	public class SpeakerApplicationModel
	{
		[Required]
		[Display(Name = "First name")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last name")]
		public string LastName { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email address")]
		public string Email { get; set; }

		[Required]
		[Display(Name = "Employer")]
		public string Employer { get; set; }

		[Required]
		[Display(Name = "Years Experience")]
		public int? YearsExperience { get; set; }

		[Display(Name = "Have a blog?")]
		public bool HasBlog { get; set; }

		[Display(Name = "What's the URL?")]
		public string BlogURL { get; set; }


		public int NumCerts { 
			get { return Certifications.Count();  } 
		}

		public int NumSessions {
			get { return Sessions.Count(); }
		}

		public List<string> Certifications { get; set; }
		public List<SessionModel> Sessions { get; set; }

		public SpeakerApplicationModel()
		{
			Sessions = new List<SessionModel>();
			Certifications = new List<string>();
		}

		public string Error { get; set; }
	}

	public class SessionModel
	{
		public int Number { get; set; }

		public string Name { get; set; }

		[AllowHtml]
		[DataType(DataType.Text)]
		public string Description { get; set; }
	}
}
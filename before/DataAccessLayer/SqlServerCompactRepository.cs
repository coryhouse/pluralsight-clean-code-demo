using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
	public class SqlServerCompactRepository : IRepository
	{
		public int SaveSpeaker(Speaker speaker)
		{
			//TODO: Save speaker to DB for now. For demo, just assume success and return 1.
			return 1;
		}
	}
}

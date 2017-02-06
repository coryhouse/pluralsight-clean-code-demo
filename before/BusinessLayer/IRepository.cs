using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
	public interface IRepository
	{
		int SaveSpeaker(Speaker speaker);
	}
}

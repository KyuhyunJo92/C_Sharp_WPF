using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopUpDemo
{
	public class GreetingBuilder
	{
		public string CreateGreeting(string userName)
		{
			return string.Format("Hallo, {0}!", userName);
		}
	}
}

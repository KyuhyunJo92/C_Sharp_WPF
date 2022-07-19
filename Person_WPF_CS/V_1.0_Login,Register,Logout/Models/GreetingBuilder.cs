
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_WPF_CS.Models
{
    public class GreetingBuilder
    {
        public string CreateGreeting(string ID)
        {
            return string.Format("Hallo, {0}!", ID);
        }
    }
}

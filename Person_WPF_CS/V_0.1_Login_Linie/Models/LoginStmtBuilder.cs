
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_WPF_CS.Models
{
    public class LoginStmtBuilder
    {
        public string CreateGreeting(string vorName)
        {
            return string.Format("Hallo, {0}!", vorName);
        }
    }
}

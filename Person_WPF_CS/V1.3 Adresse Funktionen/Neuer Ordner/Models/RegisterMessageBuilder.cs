using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_WPF_CS.Models
{
    class RegisterMessageBuilder
    {
        public string CreateRegisterBegruessen(string ID)
        {
            return string.Format("Herzlich Willkommen, {0}!", ID);
        }
    }
}

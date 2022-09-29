using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BootstrapBlazorApp.Shared.Model.Dtos
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

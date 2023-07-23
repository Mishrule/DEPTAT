using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DEPTAT.Application.Models
{
    public class LoginViewModel
    {
        [Required] public string UserId { get; set; }

        //[Required]
        //[DisplayName("Application Server")]
        //public string ApplicationServer { get; set; }

        //[Required] 
        //public int ClientId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")] public bool RememberMe { get; set; }
    }
}

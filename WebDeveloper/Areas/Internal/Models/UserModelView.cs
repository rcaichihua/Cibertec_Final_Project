using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDeveloper.Areas.Internal.Models
{
    public class UserModelView
    {
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [EmailAddress]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}
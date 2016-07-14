using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDeveloper.Model.DTO
{
    public class PersonModelView
    {
        public int BusinessEntityID { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Resource))]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "MiddleName", ResourceType = typeof(Resources.Resource))]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "LastName", ResourceType = typeof(Resources.Resource))]
        public string LastName { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}

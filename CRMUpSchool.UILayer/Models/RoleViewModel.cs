using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage="Please do not pass username as blank")]
        public string RoleName { get; set; }
    }
}

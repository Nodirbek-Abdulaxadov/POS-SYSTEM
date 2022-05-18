using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.ViewModels.Selling
{
    public class AddDepartmentViewModel
    {
        
        [Required]
        public string? Name { get; set; }
    }
}

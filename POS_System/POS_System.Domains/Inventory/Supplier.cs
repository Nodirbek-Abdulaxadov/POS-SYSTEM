using POS_System.ViewModels.Selling;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Domains.Inventory
{
    public class Supplier
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required]
        public string? CompanyName { get; set; }
        [Required]
        public string? Adress { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }

        public static explicit operator Supplier(AddSupplierViewModel v)
        {
            return new Supplier
            {
                Id = Guid.NewGuid(),
                CompanyName = v.CompanyName,
                Adress = v.Adress,
                PhoneNumber = v.PhoneNumber
            };
        }
    }
}

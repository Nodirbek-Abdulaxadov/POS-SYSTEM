using POS_System.ViewModels.Inventory;
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

        public static explicit operator Supplier(AddSupplierViewModel viewModel)
        {
            return new Supplier
            {
                Id = Guid.NewGuid(),
                CompanyName = viewModel.CompanyName,
                Adress = viewModel.Adress,
                PhoneNumber = viewModel.PhoneNumber,
            };
        }
    }
}

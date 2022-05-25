using POS_System.Domains.Selling;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.ViewModels.Selling
{
    public class AddProductViewModel
    {
        public string? Name { get; set; }
        //optional
        public string? Description { get; set; }
        [Required]
        public double IncomingPrice { get; set; }
        [Required]
        public double SellingPrice { get; set; }
        [Required]
        public string? ManufacturedDate { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public string? BarCode { get; set; }
        [Required]
        public double AmountAlert { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public Guid DepartmentId { get; set; }
        [Required]
        public Guid AdminId { get; set; }

        public static explicit operator Product(AddProductViewModel viewModel)
        {
            return new Product()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                IncomingPrice = viewModel.IncomingPrice,
                SellingPrice = viewModel.SellingPrice,
                ManufacturedDate = viewModel.ManufacturedDate,
                ExpirationDate = viewModel.ExpirationDate,
                Quantity = viewModel.Quantity,
                BarCode = viewModel.BarCode,
                AmountAlert = viewModel.AmountAlert,
                CategoryId = viewModel.CategoryId,
                DepartmentId = viewModel.DepartmentId,
                AdminId = viewModel.AdminId,
            };
        }
    }
}

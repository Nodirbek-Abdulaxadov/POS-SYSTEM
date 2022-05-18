using POS_System.ViewModels.Selling;
using System.ComponentModel.DataAnnotations;

namespace POS_System.Domains.Selling
{
    public class Product
    {
        [Key, Required]
        public Guid Id { get; set; }
        [Required]
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
        public string? ExpirationDate { get; set; }
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

        public static explicit operator Product(AddProductViewModel viewMOdel)
        {
            return new Product
            {
                Id = Guid.NewGuid(),
                Name = viewMOdel.Name,
                Description = viewMOdel.Description,
                IncomingPrice = viewMOdel.IncomingPrice,
                SellingPrice = viewMOdel.SellingPrice,
                ManufacturedDate = viewMOdel.ManufacturedDate,
                ExpirationDate = viewMOdel.ExpirationDate,
                Quantity = viewMOdel.Quantity,
                BarCode = viewMOdel.BarCode,
                AmountAlert = viewMOdel.AmountAlert,
                CategoryId = viewMOdel.CategoryId,
                DepartmentId = viewMOdel.DepartmentId,
                AdminId = viewMOdel.AdminId,
            };
        }
    }
}

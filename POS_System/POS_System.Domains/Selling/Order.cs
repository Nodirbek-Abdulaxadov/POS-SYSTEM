using POS_System.ViewModels.Selling;
using System.ComponentModel.DataAnnotations;

namespace POS_System.Domains.Selling
{
    public class Order
    {
        [Key, Required]
        public Guid Id { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public double TotalIncomingPrice { get; set; }
        [Required]
        public double TotalSellingPrice { get; set; }
        [Required]
        public string PaymentMehtod { get; set; }
        [Required]
        public bool HasLoan { get; set; }
        [Required]
        public Guid DepartmentId { get; set; }
        [Required]
        public Guid AdminId { get; set; }

        public static explicit operator Order(AddOrderViewModel viewModel)
        {
            return new Order
            {
                Id = Guid.NewGuid(),
                Date = viewModel.Date,
                TotalIncomingPrice = viewModel.TotalIncomingPrice,
                TotalSellingPrice = viewModel.TotalSellingPrice,
                PaymentMehtod = viewModel.PaymentMehtod,
                HasLoan = viewModel.HasLoan,
                DepartmentId = viewModel.DepartmentId,
                AdminId = viewModel.AdminId,
            };
        }
    }
}

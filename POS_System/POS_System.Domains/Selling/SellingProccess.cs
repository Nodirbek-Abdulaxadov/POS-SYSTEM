using POS_System.ViewModels.Selling;
using System.ComponentModel.DataAnnotations;

namespace POS_System.Domains.Selling
{
    public class SellingProccess
    {
        [Key, Required]
        public Guid Id { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public double ProccessIncomingPrice { get; set; }
        [Required]
        public double ProccessSellingPrice { get; set; }
        [Required]
        public Guid OrderId { get; set; }

        public static explicit operator SellingProccess(AddSellingProccessViewModel viewModel)
        {
            return new SellingProccess
            {
                Id = Guid.NewGuid(),
                ProductId = viewModel.ProductId,
                Quantity = viewModel.Quantity,
                Date = viewModel.Date,
                ProccessIncomingPrice = viewModel.ProccessIncomingPrice,
                ProccessSellingPrice = viewModel.ProccessSellingPrice,
                OrderId = viewModel.OrderId,
            };
        }
    }
}

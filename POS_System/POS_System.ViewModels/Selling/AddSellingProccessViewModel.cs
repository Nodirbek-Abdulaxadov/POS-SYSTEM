using POS_System.Domains.Selling;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.ViewModels.Selling
{
    public class AddSellingProccessViewModel
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double ProccessIncomingPrice { get; set; }
        [Required]
        public double ProccessSellingPrice { get; set; }
        [Required]
        public Guid OrderId { get; set; }

        public static explicit operator SellingProccess(AddSellingProccessViewModel viewModel)
        {
            return new SellingProccess()
            {
                ProductId = viewModel.ProductId,
                Quantity = viewModel.Quantity,
                //Date = viewModel.Date,
                ProccessIncomingPrice = viewModel.ProccessIncomingPrice,
                ProccessSellingPrice = viewModel.ProccessSellingPrice,
                OrderId = viewModel.OrderId
            };
        }
    }
}


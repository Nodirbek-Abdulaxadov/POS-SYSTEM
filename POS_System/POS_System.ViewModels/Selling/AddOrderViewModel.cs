using POS_System.Domains.Selling;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.ViewModels.Selling
{
    public class AddOrderViewModel
    {
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

        public static explicit operator Order(POS_System.ViewModels.Selling.AddOrderViewModel v)
        {
            return new Order()
            {
                Date = v.Date,
                TotalIncomingPrice = v.TotalIncomingPrice,
                TotalSellingPrice = v.TotalSellingPrice,
                AdminId = v.AdminId,
                DepartmentId = v.DepartmentId,
                HasLoan = v.HasLoan,
                Id = Guid.NewGuid(),
                PaymentMehtod = v.PaymentMehtod
            };
        }
    }
}

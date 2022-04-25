using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Domains.Selling
{
    public class Product
    {
        [Key, Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }        
        //optional
        public string Description { get; set; }
        [Required]
        public double IncomingPrice { get; set; }
        [Required]
        public double SellingPrice { get; set; }
        [Required]
        public string ManufacturedDate { get; set; }
        [Required]
        public string ExpirationDate { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public string BarCode { get; set; }
        [Required]
        public double AmountAlert { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public Guid AdminId { get; set; }
    }
}

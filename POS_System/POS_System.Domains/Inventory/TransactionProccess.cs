﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Domains.Inventory
{
    public class TransactionProccess
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        public Guid ProductId { get; set; }
    }
}

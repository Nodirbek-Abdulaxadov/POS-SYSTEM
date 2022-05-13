﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Domains.Admin
{
    public class AddLoanForInventoryViewModel
    {
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public double PaidPrice { get; set; }
        [Required]
        public double LeftPrice { get; set; }
        [Required]
        public bool IsPaid { get; set; }
        public Guid SupplierId { get; set; }
        public Guid TransactionId { get; set; }
        public Supplier Supplier { get; set; }

        public static explicit operator LoanForInventory(AddLoanForInventoryViewModel v)
        {
            return new LoanForInventory
            {
                Id == Guid.NewGuid(),

            };
        }
    }
}
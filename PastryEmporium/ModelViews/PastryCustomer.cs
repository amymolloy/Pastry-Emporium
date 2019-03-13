using PastryEmporium.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PastryEmporium.ModelViews
{
    public class PastryCustomer
    {
        [Display(Name = "Pastry ID")]
        public Pastry Pastry { get; set; }
        [Display(Name = "Customer ID")]
        public Customer Customer { get; set; }
    }
}

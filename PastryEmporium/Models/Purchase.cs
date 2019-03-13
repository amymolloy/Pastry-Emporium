using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PastryEmporium.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        [Display(Name = "Pastry ID")]
        public int PastryId { get; set; }
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }
    }
}

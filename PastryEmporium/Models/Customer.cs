using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PastryEmporium.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Address")]
        public string AddressLine1 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}

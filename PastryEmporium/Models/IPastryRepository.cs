using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryEmporium.Models
{
    public interface IPastryRepository
    {
        List<Pastry> GetPastries();
        Pastry GetPastryById(int? id);
        void AddNewPastry(Pastry pastry);
        void UpdatePastry(Pastry pastry);
        void RemovePastry(Pastry pastry);
    }
}

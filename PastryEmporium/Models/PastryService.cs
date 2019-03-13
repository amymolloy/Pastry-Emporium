using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryEmporium.Models
{
    public class PastryService : IPastryRepository
    {
        private readonly PastryEmporiumContext _context;

        public PastryService(PastryEmporiumContext context)
        {
            _context = context;
        }

        public void AddNewPastry(Pastry pastry)
        {
            _context.Add(pastry);
            _context.SaveChanges();
        }

        public List<Pastry> GetPastries()
        {
            return _context.Pastry.ToList();
        }

        public Pastry GetPastryById(int? id)
        {
            var pastry = _context.Pastry
                .FirstOrDefault(p => p.Id == id);
            return pastry;
        }

        public void RemovePastry(Pastry pastry)
        {
            _context.Pastry.Remove(pastry);
            _context.SaveChanges();
        }

        public void UpdatePastry(Pastry pastry)
        {
            _context.Update(pastry);
            _context.SaveChanges();
        }
    }
}

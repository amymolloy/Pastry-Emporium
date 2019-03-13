using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryEmporium.Models
{
    public class FeedbackService : IFeedbackRepository
    {
        private readonly PastryEmporiumContext _context;

        public FeedbackService(PastryEmporiumContext context)
        {
            _context = context;
        }

        public void AddNewFeedback(Feedback feedback)
        {
            _context.Add(feedback);
            _context.SaveChanges();
        }

        public List<Feedback> GetFeedback()
        {
            return _context.Feedback.ToList();
        }

        public Feedback GetFeedbackById(int? id)
        {
            var feedback = _context.Feedback
           .FirstOrDefault(f => f.Id == id);
            return feedback;
        }

        public void RemoveFeedback(Feedback feedback)
        {
            _context.Feedback.Remove(feedback);
            _context.SaveChanges();
        }
    }
}

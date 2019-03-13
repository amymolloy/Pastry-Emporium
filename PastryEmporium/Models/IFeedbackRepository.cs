using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryEmporium.Models
{
    public interface IFeedbackRepository
    {
        List<Feedback> GetFeedback();
        Feedback GetFeedbackById(int? id);
        void AddNewFeedback(Feedback feedback);
        void RemoveFeedback(Feedback feedback);
    }
}

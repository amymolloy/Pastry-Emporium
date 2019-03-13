using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PastryEmporium.Models;

namespace PastryEmporium.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        [Authorize]
        // GET: Feedback
        public IActionResult Index()
        {
            return View(_feedbackRepository.GetFeedback());
        }

        [Authorize]
        // GET: Feedback/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = _feedbackRepository.GetFeedbackById(id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // GET: Feedback/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Feedback/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email,Message,Contact")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _feedbackRepository.AddNewFeedback(feedback);
                return RedirectToAction(nameof(Index));
            }
            return View(feedback);
        }

        [Authorize]
        // GET: Feedback/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = _feedbackRepository.GetFeedbackById(id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // POST: Feedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteConfirmed(int id)
        {
            var feedback = _feedbackRepository.GetFeedbackById(id);
            _feedbackRepository.RemoveFeedback(feedback);
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackExists(int id)
        {
            return _feedbackRepository.GetFeedbackById(id) != null;
        }
    }
}

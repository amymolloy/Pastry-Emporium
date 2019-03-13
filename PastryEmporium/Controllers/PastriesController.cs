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
    public class PastriesController : Controller
    {
        private readonly IPastryRepository _pastryRepository;

        public PastriesController(IPastryRepository pastryRepository)
        {
            _pastryRepository = pastryRepository;
        }

        // GET: Pastries
        public IActionResult Index()
        {
            return View(_pastryRepository.GetPastries());
        }

        // GET: Pastries/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pastry = _pastryRepository.GetPastryById(id);
            if (pastry == null)
            {
                return NotFound();
            }

            return View(pastry);
        }

        [Authorize]
        // GET: Pastries/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: Pastries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Price,ImageUrl,ThumbnailUrl")] Pastry pastry)
        {
            if (ModelState.IsValid)
            {
                _pastryRepository.AddNewPastry(pastry);
                return RedirectToAction(nameof(Index));
            }
            return View(pastry);
        }

        [Authorize]
        // GET: Pastries/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pastry = _pastryRepository.GetPastryById(id);
            if (pastry == null)
            {
                return NotFound();
            }
            return View(pastry);
        }

        [Authorize]
        // POST: Pastries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,Price,ImageUrl,ThumbnailUrl")] Pastry pastry)
        {
            if (id != pastry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _pastryRepository.UpdatePastry(pastry);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PastryExists(pastry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pastry);
        }

        [Authorize]
        // GET: Pastries/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pastry = _pastryRepository.GetPastryById(id);
            if (pastry == null)
            {
                return NotFound();
            }

            return View(pastry);
        }

        [Authorize]
        // POST: Pastries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var pastry = _pastryRepository.GetPastryById(id);
            _pastryRepository.RemovePastry(pastry);
            return RedirectToAction(nameof(Index));
        }

        private bool PastryExists(int id)
        {
            return _pastryRepository.GetPastryById(id) != null;
        }
    }
}

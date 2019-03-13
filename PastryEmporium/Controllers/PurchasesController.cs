using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PastryEmporium.Models;
using PastryEmporium.ModelViews;

namespace PastryEmporium.Controllers
{
    [Authorize]
    public class PurchasesController : Controller
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IPastryRepository _pastryRepository;
        private readonly ICustomerRepository _customerRepository;

        public PurchasesController(IPurchaseRepository purchaseRepository,
        IPastryRepository pastryRepository, ICustomerRepository customerRepository)
        {
            _purchaseRepository = purchaseRepository;
            _customerRepository = customerRepository;
            _pastryRepository = pastryRepository;
        }

        // GET: Purchases
        public IActionResult Index()
        {
            return View(_purchaseRepository.GetPurchases());
        }

        // GET: Purchases/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = _purchaseRepository.GetPurchaseById(id);
            PastryCustomer pastryCustomer = new PastryCustomer
            {
                Pastry = _pastryRepository.GetPastryById(purchase.PastryId),
                Customer = _customerRepository.GetCustomerById(purchase.CustomerId)
            };

            if (purchase == null)
            {
                return NotFound();
            }

            return View(pastryCustomer);
        }

        // GET: Purchases/Create
        public IActionResult Create()
        {
            ViewData["PastryId"] = new SelectList(_pastryRepository.GetPastries(), "Id", "Name");
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetCustomers(), "Id", "Name");
            return View();
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,PastryId,CustomerId")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                _purchaseRepository.AddNewPurchase(purchase);
                return RedirectToAction(nameof(Index));
            }
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = _purchaseRepository.GetPurchaseById(id);
            if (purchase == null)
            {
                return NotFound();
            }
            ViewData["PastryId"] = new SelectList(_pastryRepository.GetPastries(), "Id", "Name", _pastryRepository.GetPastryById(purchase.PastryId));
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetCustomers(), "Id", "Name", _customerRepository.GetCustomerById(purchase.CustomerId));
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,PastryId,CustomerId")] Purchase purchase)
        {
            if (id != purchase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _purchaseRepository.UpdatePurchase(purchase);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseExists(purchase.Id))
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
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = _purchaseRepository.GetPurchaseById(id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var purchase = _purchaseRepository.GetPurchaseById(id);
            _purchaseRepository.RemovePurchase(purchase);
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseExists(int id)
        {
            return _purchaseRepository.GetPurchaseById(id) != null;
        }
    }
}

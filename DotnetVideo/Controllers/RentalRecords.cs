using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotnetVideo;
using DotnetVideo.Models;

namespace DotnetVideo.Controllers
{
    public class RentalRecords : Controller
    {
        private readonly videosdbContext _context;

        public RentalRecords(videosdbContext context)
        {
            _context = context;
        }

        // GET: RentalRecords
        public async Task<IActionResult> Index()
        {
            var videosdbContext = _context.RentalRecords.Include(r => r.CustomerModel).Include(r => r.MovieModel);
            return View(await videosdbContext.ToListAsync());
        }

        // GET: RentalRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRecordModel = await _context.RentalRecords
                .Include(r => r.CustomerModel)
                .Include(r => r.MovieModel)
                .SingleOrDefaultAsync(m => m.RentalId == id);
            if (rentalRecordModel == null)
            {
                return NotFound();
            }

            return View(rentalRecordModel);
        }

        // GET: RentalRecords/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieId");
            return View();
        }

        // POST: RentalRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalId,MovieId,CustomerId,RentalDate,ReturnDate,DueDate")] RentalRecordModel rentalRecordModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalRecordModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", rentalRecordModel.CustomerId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieId", rentalRecordModel.MovieId);
            return View(rentalRecordModel);
        }

        // GET: RentalRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRecordModel = await _context.RentalRecords.SingleOrDefaultAsync(m => m.RentalId == id);
            if (rentalRecordModel == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", rentalRecordModel.CustomerId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieId", rentalRecordModel.MovieId);
            return View(rentalRecordModel);
        }

        // POST: RentalRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalId,MovieId,CustomerId,RentalDate,ReturnDate,DueDate")] RentalRecordModel rentalRecordModel)
        {
            if (id != rentalRecordModel.RentalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalRecordModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalRecordModelExists(rentalRecordModel.RentalId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", rentalRecordModel.CustomerId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieId", rentalRecordModel.MovieId);
            return View(rentalRecordModel);
        }

        // GET: RentalRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRecordModel = await _context.RentalRecords
                .Include(r => r.CustomerModel)
                .Include(r => r.MovieModel)
                .SingleOrDefaultAsync(m => m.RentalId == id);
            if (rentalRecordModel == null)
            {
                return NotFound();
            }

            return View(rentalRecordModel);
        }

        // POST: RentalRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalRecordModel = await _context.RentalRecords.SingleOrDefaultAsync(m => m.RentalId == id);
            _context.RentalRecords.Remove(rentalRecordModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalRecordModelExists(int id)
        {
            return _context.RentalRecords.Any(e => e.RentalId == id);
        }
    }
}

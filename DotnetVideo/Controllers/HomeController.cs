using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetVideo.Models;
using DotnetVideo.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DotnetVideo.Controllers
{
    public class HomeController : Controller
    {
        private readonly videosdbContext _context;

        public HomeController(videosdbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        /*public IActionResult Seed()
        {
            var seedMovies = new List<MovieModel>(){
                new MovieModel 
                {
                       MovieName = "Titanic",
                       MovieDescription = "Lorem ipsum",
                       GenreId = 5
                },
                new MovieModel 
                {
                       MovieName = "Bill and Ted's Most Excellent Adventure",
                       MovieDescription = "Lorem ipsum",
                       GenreId = 4
                },
                new MovieModel 
                {
                       MovieName = "Mission Impossible",
                       MovieDescription = "Lorem ipsum",
                       GenreId = 3
                },
            };

              var seedGenre = new List<GenreModel>(){
                new GenreModel 
                {
                       GenreName = "Horror"
                },
                new GenreModel 
                {
                      GenreName = "Sci-Fi"
                },
                new GenreModel 
                {
                       GenreName = "Action"
                },
                new GenreModel 
                {
                       GenreName = "Comedy"
                },
                new GenreModel 
                {
                       GenreName = "Romance"
                },
                new GenreModel 
                {
                       GenreName = "Drama"
                },
            };

            var seedCustomers = new List<CustomerModel>(){
                new CustomerModel 
                {
                       CustomerName = "Brandyn",
                       CustomerPhoneNumber = "8675309",
                },
                new CustomerModel 
                {
                       CustomerName = "Jeremiah",
                       CustomerPhoneNumber = "8675309",
                },
                new CustomerModel 
                {
                       CustomerName = "Jake",
                       CustomerPhoneNumber = "8675309",
                },
                new CustomerModel 
                {
                       CustomerName = "Yana",
                       CustomerPhoneNumber = "8675309",
                },
                new CustomerModel 
                {
                       CustomerName = "Robby",
                       CustomerPhoneNumber = "8675309",
                },
            };

            seedMovies.ForEach(movie => _context.Movies.Add(movie));
            seedGenre.ForEach(genre => _context.Genres.Add(genre));
            seedCustomers.ForEach(customer => _context.Add(customer));

            _context.SaveChanges();

            return Ok();
        }*/

        public IActionResult Overdue()
        {
            var service = new VideoStoreServices(_context);
            return View(service.GetOverdueRecords());
        }

        public IActionResult Return()
        {
            var service = new VideoStoreServices(_context);
            return View(service.GetAllRentalRecordsCurrentlyRented());
        }

       public async Task<IActionResult> CheckIn(int? id)
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
            rentalRecordModel.ReturnDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        // POST: RentalRecord/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckIn(int id, [Bind("RentalId,MovieId,CustomerId,RentalDate,DueDate,ReturnDate")] RentalRecordModel rentalRecordModel)
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

        private bool RentalRecordModelExists(int id)
        {
            return _context.RentalRecords.Any(e => e.RentalId == id);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetVideo.Models;
using DotnetVideo.Services;

namespace DotnetVideo.Controllers
{
    public class RentalRecords : Controller
    {
        private readonly videosdbContext _context;

        public RentalRecords(videosdbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateRecord(int movie, int customer, DateTime rentaldate, DateTime duedate)
        {
            var newEntry = new RentalRecordModel{
                MovieId = movie,
                CustomerId = customer,
                RentalDate = rentaldate,
                DueDate = duedate
            };
            _context.RentalRecords.Add(newEntry);
            _context.SaveChanges();
            return Redirect("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var service = new VideoStoreServices(_context);
            return View(service.PopulateRentalForm());
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

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

        public IActionResult Index()
        {
            var service = new VideoStoreServices(_context);
            var currentMovies = service.GetAllMovies();
            return View(currentMovies);
        }

        public IActionResult Create()
        {
            return View();
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

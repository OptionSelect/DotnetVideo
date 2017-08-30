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
    public class Movies : Controller
    {
        private readonly videosdbContext _context;

        public Movies(videosdbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var service = new VideoStoreServices(_context);
            return View(service.GetAllMovies());
        }

        public IActionResult Create()
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

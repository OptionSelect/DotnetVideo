using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using DotnetVideo.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DotnetVideo.Services
{
    public class VideoStoreServices
    {
        private readonly videosdbContext _context;
        public VideoStoreServices(videosdbContext context)
        {
            _context = context;
            
        }

        public IEnumerable<MovieViewModel> GetAllMovies()
        {
            var currentMovies = _context.Movies;
            return currentMovies.Include(i => i.GenreModel).Select(s => new MovieViewModel(s));
        }

        public CheckoutViewModel PopulateRentalForm()
        {
            var customerInfo = _context.Customers;
            var movieInfo = _context.Movies;
            var newRecord = new CheckoutViewModel{
                Customers = customerInfo.ToList(),
                Movies = movieInfo.ToList()
            };
            return newRecord;
        }

        public IEnumerable<RentalRecordViewModel> GetAllRentalRecords()
        {
            var customerInfo = _context.Customers;
            var movieInfo = _context.Movies;
            var allRecords = _context.RentalRecords;
            return allRecords.Include(m => m.MovieModel).Include(c => c.CustomerModel).Select(s => new RentalRecordViewModel(s));
        }
    }
}
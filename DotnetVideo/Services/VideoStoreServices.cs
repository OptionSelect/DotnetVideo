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

        public RentalRecordModel GetAllRentalRecords()
        {
            var currentRentalRecords = _context.RentalRecords;
            return currentRentalRecords.Include(i => i.MovieModel).Include(j => j.CustomerModel).Select(s => new RentalRecordModel(s));
        }
    }
}
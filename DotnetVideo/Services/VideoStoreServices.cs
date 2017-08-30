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
    }
}
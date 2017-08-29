using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetVideo.Models
{
    public class MovieModel
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        
        [ForeignKey ("GenreId")]
        public int GenreId { get; set; }

        public GenreModel GenreModel {get; set;}
    }
}
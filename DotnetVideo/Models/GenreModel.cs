using System;
using System.ComponentModel.DataAnnotations;

namespace DotnetVideo.Models
{
    public class GenreModel
    {
        [Key]
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
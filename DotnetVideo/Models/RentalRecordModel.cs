using System;

namespace DotnetVideo.Models
{
    public class RentalRecordModel
    {
        public int RentalId { get; set; }
        public int MovieId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
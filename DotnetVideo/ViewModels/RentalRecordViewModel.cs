using System;

namespace DotnetVideo.Models
{
    public class RentalRecordViewModel
    {
        public int RentalId { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }

        public RentalRecordViewModel(){}
        public RentalRecordViewModel(RentalRecordModel record)
        {
            this.RentalId = record.RentalId;
            this.MovieId = record.MovieId;
            this.MovieName = record.MovieModel.MovieName;
            this.MovieDescription = record.MovieModel.MovieDescription;
            this.RentalDate = record.RentalDate;
            this.DueDate = record.DueDate;
            this.ReturnDate = record.ReturnDate;
            this.CustomerId = record.CustomerId;
            this.CustomerName = record.CustomerModel.CustomerName;
            this.CustomerPhoneNumber = record.CustomerModel.CustomerPhoneNumber;
        }
    }
}
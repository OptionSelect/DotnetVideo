using System;
using System.Collections.Generic;

namespace DotnetVideo.Models
{
    public class RentalRecordViewModel
    {
        public List<MovieModel> Movies { get; set; }
        public DateTime RentalDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(5);
        public List<CustomerModel> Customers { get; set; }

        public RentalRecordViewModel(){}
        public RentalRecordViewModel(RentalRecordModel rentalRecord)
        {
            this.Movies = new List<MovieModel>();
            this.Customers = new List<CustomerModel>();
        }
    }
}
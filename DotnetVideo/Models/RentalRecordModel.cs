using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetVideo.Models
{
    public class RentalRecordModel
    {
        [Key]
        public int RentalId { get; set; }
        [ForeignKey ("MovieId")]
        public int MovieId { get; set; }
        [ForeignKey ("CustomerId")]
        public int CustomerId { get; set; }
        public DateTime RentalDate { get; set; } = DateTime.Now;
        public DateTime ReturnDate { get; set; }
        public DateTime DueDate { get; set; }

        public MovieModel MovieModel {get; set;}
        public CustomerModel CustomerModel {get; set;}
        public RentalRecordModel(){}
        public RentalRecordModel(RentalRecordModel rentalrecordmodel)
        {
            this.CustomerId = rentalrecordmodel.CustomerId;
        }
    }
}
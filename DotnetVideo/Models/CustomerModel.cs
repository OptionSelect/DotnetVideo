using System;
using System.ComponentModel.DataAnnotations;

namespace DotnetVideo.Models
{
    public class CustomerModel
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
    }
}
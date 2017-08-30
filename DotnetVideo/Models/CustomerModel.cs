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

        public CustomerModel(){}
        public CustomerModel(CustomerModel customer)
        {
            this.CustomerName = customer.CustomerName;
            this.CustomerPhoneNumber = customer.CustomerPhoneNumber;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAdress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double ZipCode { get; set; }
        public DayOfWeek PickupDay { get; set; }
        public double Balance { get; set; }
        public double MonthlyCharge { get; set; }
        public bool PickupConfirmed { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("ApplicationUser")]

        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUDWebApi_Client.Models
{
    public class Employee
    {
        
        public decimal Employee_ID { get; set; }
        [Display(Name = "First Name")]
        public string First_Name { get; set; }
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }
        [Display(Name = "Salary")]
        public decimal Salary { get; set; }

    }
}
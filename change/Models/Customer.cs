using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace change.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "שם פרטי")]
        public string FirstName { get; set; }

        [Display(Name = "משפחה")]
        public string LastName { get; set; }

        [Display(Name = "טלפון")]
        public string Phone { get; set; }

        [Display(Name = "כתובת מייל")]
        [EmailAddress(ErrorMessage = "נא לכתוב כתובת מייל נכונה")]
        public string Email { get; set; }

        [Display(Name = "תמונה")]
        public byte[] Photo { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}

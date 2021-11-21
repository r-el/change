using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace change.Models
{
    // סך כל המטבעות
    public class SumCurrency
    {
        public SumCurrency() { DateTime = DateTime.Now; }

        [Key]
        public int ID { get; set; }

        [Timestamp]
        public byte[] DateTimeInDB { get; set; } // תאריך מבסיס הנתונים

        public DateTime DateTime { get; set; }   // תאריך

        public Currency Currency { get; set; }   // מטבע

        public CashRegister Cash { get; set; }   // קופה

        [Display(Name = "סכום")]
        public decimal Sum { get; set; }
    }
}

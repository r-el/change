using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace change.Models
{
    // Currency values are updated
    // From the Bank of Israel API

    public class CurrencyValueByDate
    {
        [Key]
        public int ID { get; set; }

        // תאריך עדכון
        public DateTime Last_Date { get; set; } = new DateTime();

        // סוג מטבע
        public Currency Currency { get; set; }

        [Display(Name = "יחידה")]
        public int Unit { get; set; }

        // ערך בשקלים
        public double Rate { get; set; }

        // הוספת/הפחתת אחוזים לשער החליפין
        public double BuyRate { get { return Rate * 1.01; } }  // כשבא קונא למכור
        public double SellRate { get { return Rate * 0.99; } } // כשבא קונה לקנות
    }
}

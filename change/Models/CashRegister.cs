using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace change.Models
{
    public class CashRegister
    {
        [Key]
        public int ID { get; set; }

        // id-מספר רנדומלי להגברת האבטחה, מתווסף ל
        public int RandomNumber { get; set; }

        public User User { get; set; }

        [Timestamp]
        public byte[] DateTimeInDB { get; set; }

        [Display(Name = "תאריך")] 
        public DateTime DateTime { get; set; }

        // תאריך בפורמט מקוצר
        public string DateString { get { return DateTime.ToShortDateString(); } }

        [Display(Name = "מצב קופה")] 
        public string StatusCash { get { if (IsClosing) return "קופה סגורה"; return "קופה פתוחה"; } }

        [Display(Name = "סגירת הקופה")]
        public bool IsClosing { get; set; } = false;

        [Display(Name = "זמן סגירה")]
        public byte[] DateTimeInClose { get; set; }
    }
}

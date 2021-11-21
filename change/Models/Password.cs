using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace change.Models
{
    // יש צורך בטבלא שתזכור את כל הסיסמאות שהיו בעבר
    // מכיוון שכל תקופה מסוימת
    // המשתמש צריך להחליף סיסמא לסיסמא חדשה שלא היתה בעבר
    public class Password
    {
        [Key]
        public int ID { get; set; }

        public User User { get; set; }

        [Display(Name = "סיסמא")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "כתוב לפחות שמונה תוים")]
        public string MyPassword { get; set; }

        [Display(Name = "תאריך תפוגה")]
        public DateTime ExpiryDate { get; set; }

        // האם זו הסיסמא הנוכחית
        public bool Current { get; set; } = true;
    }
}

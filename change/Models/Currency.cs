using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace change.Models
{
    public class Currency
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "שם מטבע")]
        public string Name { get; set; }

        [Display(Name = "קוד מטבע")]
        public string CurrencyCode { get; set; }

        [Display(Name = "מדינה")]
        public string Country { get; set; }

        [Display(Name = "שם מטבע ומדינה")]
        public string NameAndCountry { get { return Name + " " + Country; } }

        // רשימת מטבעות מעודכנים מאתר בנק ישראל
        public List<CurrencyValueByDate> Rates { get; set; }

        // הוספת מטבע חדש
        public void AddRate(int unit, double rate, DateTime date)
        {
            Rates.Add(new CurrencyValueByDate()
            {
                Currency = this,
                Unit = unit,
                Rate = rate,
                Last_Date = date
            });
        }
    }
}

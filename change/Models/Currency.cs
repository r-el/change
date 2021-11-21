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
    }
}

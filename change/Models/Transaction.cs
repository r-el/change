using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace change.Models
{
    public class Transaction
    {
        [Key]
        public int ID { get; set; }

        [Timestamp]
        public byte[] DateTimeInDB { get; set; }

        public DateTime DateTime { get { return DateTime.FromBinary(BitConverter.ToInt64(DateTimeInDB, 0)); } }

        public CashRegister CashRegister { get; set; }

        public Customer Customer { get; set; }

        public CurrencyValueByDate Rate { get; set; }

        public bool IsBuying { get; set; } // הקונה נותן שקלים וקונה דולרים

        [Display(Name = "שקלים")]
        public decimal NIS { get; set; }
        [Display(Name = "מטבע")]
        public decimal Coin { get; set; }

        // חשב את העסקה לאחר עמלה
        public decimal Calculate
        {
            set
            {
                if (IsBuying)
                    NIS = Coin * decimal.Parse((Rate.Rate * 1.01).ToString());
                else
                    NIS = Coin * decimal.Parse((Rate.Rate * 0.99).ToString());
            }
        }
    }
}

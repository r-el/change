using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace change.Models
{
    // שכבת נתונים
    public class DAL : DbContext
    {
        private static DAL Data;

        // חיבור פרטי. גישה לדטאבייס מוגבלת 
        private DAL() : base("data source=localhost\\SQLEXPRESS;"
                                + " initial catalog = Change;"
                                + " user id = sa; password = 1234;")
        {
            // תמחק ותיצור את מסד הנתונים מחדש אם המודלים השתנו
            Database.SetInitializer<DAL>(new DropCreateDatabaseIfModelChanges<DAL>());

            // אם אין נתונים בדטאבייס, תוסיף נתונים
            if (Currencies.Count() == 0) Seed();
        }

        // איפשור גישה לדטאבייס
        public static DAL Get
        {
            // תן גישה לדטאבייס
            // אם אין נתונים בדטאבייס תאתחל נתונים (ע"י Seed)
            get { if (Data == null) Data = new DAL(); return Data; }
        }

        // זריעה של נתונים לדטאבייס
        private void Seed()
        {
            Currency currency = new Currency()
            {
                Name = "Shekel",
                CurrencyCode = "ILS",
                Country = "Israel"
            };
            Currencies.Add(currency);
            Currency currency1 = new Currency()
            {
                Name = "Dollar",
                CurrencyCode = "USD",
                Country = "USA"
            };
            Currencies.Add(currency1);
            Currency currency2 = new Currency()
            {
                Name = "Dollar",
                CurrencyCode = "CAD",
                Country = "Canada"
            };
            Currencies.Add(currency2);
            //currency1.AddRate(1, 3.1, DateTime.Now);
            //currency2.AddRate(1, 2.47, DateTime.Now);
            SaveChanges();
        }

        // יצירת טבלאות
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyValueByDate> Rates { get; set; }
        public DbSet<CashRegister> Cashes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cashier> Cashiers { get; set; }
        //public DbSet<SumCurrency> SumCurrencies { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace change.Models
{
    public class User
    {
        // -------------------------- User Details -------------------------- //

        [Key]
        public int ID { get; set; }

        [Display(Name = "שם פרטי")]
        public string FirstName { get; set; }
        [Display(Name = "שם משפחה")]
        public string LastName { get; set; }
        [Display(Name = "שם משתמש")]
        public string FullName { get { return FirstName + " " + LastName; } }

        [Display(Name = "טלפון")]
        public string Phone { get; set; }
        [Display(Name = "כתובת מייל")]
        [EmailAddress(ErrorMessage = "נא הזן כתובת מייל תקינה")]
        public string Email { get; set; }

        [Display(Name = "תמונה")]
        public byte[] Photo { get; set; }

        [Display(Name = "האם מנהל?")]
        public bool IsManager { get; set; } = false;
        [Display(Name = "הרשאות")]
        public string Permissions { get { if (IsManager) return "מנהל"; return "משתמש"; } }

        [Display(Name = "האם פעיל?")]
        public bool IsActive { get; set; } = true;

        // -------------------------- User Passwords -------------------------- //

        public List<Password> Passwords { get; set; }

        public string AddPassword(string newPassword)
        {
            foreach (Password password in Passwords)
            {
                if (password.MyPassword == newPassword)
                    return "השתמשת בסיסמא זו בעבר. נסה סיסמא חדשה";
            }
            foreach (Password password in Passwords)
            {
                password.Current = false;
            }
            Passwords.Add(new Password { User = this, MyPassword = newPassword, Current = true, ExpiryDate = DateTime.Now.AddDays(180) });
            return "הסיסמא הוחלפה בהצלחה";
        }
    }
}

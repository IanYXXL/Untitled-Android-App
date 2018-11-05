using System;
using System.Collections.Generic;
using System.Text;

namespace Android1
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public double PhoneNum { get; set; }
        public string SkinColor { get; set; }
        public int Num_Tattoo { get; set; }
        public User() { }

        public User(string Email, string password ) {
            this.Email = Email;
            this.Password = password;
        }

        public User(string email, string password, string age, string address, string gender )
        {

        }
        public bool AttemptLogin()
        {
            FName = "Dave";
            LName = "Smith";
            Age = 20;
            Gender = "Male";
            ID = 12313123;
            Address1 = "384 Yonge St.";
            Address2 = "M5B 1S8";
            PhoneNum = 4169792603;
            Email = "talk@untitledtattoo";
            //dummy

            CurrentUser.FName = FName;
            try { CurrentUser.MName = MName; }
            catch { CurrentUser.MName = ""; }
            CurrentUser.LName = LName;
            CurrentUser.Points = 50;
            CurrentUser.ID = ID;
            CurrentUser.Email = Email;
            CurrentUser.Address1 = Address1;
            try {CurrentUser.Address1 = Address1;}
            catch { CurrentUser.Address2 = ""; }
            CurrentUser.Theme = "dark";
            try { CurrentUser.SkinColor = SkinColor; }
            catch { CurrentUser.SkinColor = ""; }
            CurrentUser.Gender = Gender;
            CurrentUser.Age = Age;
            CurrentUser.PhoneNum = PhoneNum;
            return true;
        }
        
    }
}

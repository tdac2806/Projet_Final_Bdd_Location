using System;

namespace LocationLibrary
{
    public class Client
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Password { get; private set; }
        public string BirthDate { get; set; }
        public string LicenceDate { get; set; }
        public bool IsAccompaniedDriving { get; set; }
        public string LicenceNumber { get; set; }

        public Client(string name, string lastname, string password, string birthdate, string licencedate, bool isaccompanieddriving, string licencenumber)
        {
            this.Name = name.ToUpper();
            this.LastName = lastname.ToUpper();
            this.Password = password;
            this.BirthDate = birthdate;
            this.LicenceDate = licencedate;
            this.IsAccompaniedDriving = isaccompanieddriving;
            this.LicenceNumber = licencenumber;
        }
    }
}
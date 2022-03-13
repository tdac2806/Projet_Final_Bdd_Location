using System.Collections.Generic;

namespace LocationLibrary
{
    internal class DataLayer : IDataLayer
    {
        public List<Client> Clients { get; private set; }
        public List<Vehicle> Vehicles { get; private set; }
        public List<Reservation> Reservations { get; private set; }

        public DataLayer()
        {
            this.Clients = new List<Client>();
            this.Vehicles = new List<Vehicle>();
            this.Reservations = new List<Reservation>();
            //Connect à la database...
        }
    }
}
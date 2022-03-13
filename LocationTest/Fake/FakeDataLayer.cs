using LocationLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocationTest.Fake
{
    class FakeDataLayer : IDataLayer
    {
        public List<Client> Clients { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<Reservation> Reservations { get; set; }

        public FakeDataLayer()
        {
            this.Clients = new List<Client>();
            this.Vehicles = new List<Vehicle>();
            this.Reservations = new List<Reservation>();
        }
    }
}

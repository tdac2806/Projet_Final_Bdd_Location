using System;

namespace LocationLibrary
{
    public class Reservation
    {
        public Client Client { get; private set; }
        public Vehicle Vehicle { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int PlannedKilometer { get; private set; }
        public int RealKilometer { get; set; }

        public Reservation(Client client, Vehicle vehicle, DateTime startDate, DateTime endDate, int plannedkilometer, int realkilometer)
        {
            this.Client = client;
            this.Vehicle = vehicle;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.PlannedKilometer = plannedkilometer;
            this.RealKilometer = realkilometer;
        }
    }
}
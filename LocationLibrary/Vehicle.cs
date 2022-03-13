using System;
using System.Collections.Generic;
using System.Text;

namespace LocationLibrary
{
    public class Vehicle
    {
        public string Plate { get; private set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int ReservationPrice { get; set; }
        public float KilometerRate { get; set; }
        public int TaxHorsePower { get; set; }
        public bool IsReserved { get; set; }


        public Vehicle(string brand, string model, string plate, string color, int reservationprice, float kilometerrate, int taxhorsepower, bool isreserved)
        {
            this.Plate = plate;
            this.Brand = brand;
            this.Color = color;
            this.Model = model;
            this.ReservationPrice = reservationprice;
            this.KilometerRate = kilometerrate;
            this.TaxHorsePower = taxhorsepower;
            this.IsReserved = isreserved;
        }
    }
}
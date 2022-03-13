using System;
using System.Collections.Generic;
using System.Linq;

namespace LocationLibrary
{
    public class Location
    {
        private IDataLayer _dataLayer;

        public Client Client { get; private set; }
        public Vehicle Vehicle { get; private set; }
        public Reservation Reservation { get; private set; }
        public List<Reservation> Reservations { get; private set; }
        public List<Vehicle> AvailableVehicles { get; private set; }
        public bool ReservationDone { get; private set; }
        public Location()
        {
            this._dataLayer = new DataLayer();
        }

        public Location(IDataLayer dataLayer)
        {
            this._dataLayer = dataLayer;
        }

        public bool CheckClientExists(string name, string lastname)
        {
            bool ClientExists = false;

            Client = this._dataLayer.Clients.SingleOrDefault(_ => _.Name.ToUpper() == name.ToUpper() && _.LastName.ToUpper() == lastname.ToUpper());
            if (Vehicle != null)
            {
                ClientExists = true;
            }
            return ClientExists;
        }

        public string ConnectUser(string firstname, string lastname, string password)
        {
            Client = this._dataLayer.Clients.SingleOrDefault(_ => _.Name.ToUpper() == firstname.ToUpper() && _.LastName.ToUpper() == lastname.ToUpper());
            if (Client == null)
            {
                return "Utilisateur inconnu";
            }
            else
            {
                if (Client.Password == password)
                {
                    return "Utilisateur connecté";
                }
                else
                {
                    return "Mot de passe incorrect";
                }
            }
        }
        public string CheckUserData(string name, string lastname, string password, string birthdate, string licencedate, string accompanieddriving, string licencenumber)
        {
            bool isaccompanieddriving = (accompanieddriving.ToLower() == "true" ? true : false);
            string ErrorMessage = "";

            if (string.IsNullOrEmpty(name))
            {
                if (!string.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage += " et ";
                ErrorMessage += "Prenom manquant";
            }
            if (string.IsNullOrEmpty(lastname))
            {
                if (!string.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage += " et ";
                ErrorMessage += "Nom manquant";
            }
            if (string.IsNullOrEmpty(password))
            {
                if (!string.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage += " et ";
                ErrorMessage += "Mot de passe manquant";
            }
            if (string.IsNullOrEmpty(birthdate))
            {
                if (!string.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage += " et ";
                ErrorMessage = "Date de naissance manquante";
            }
            if (string.IsNullOrEmpty(ErrorMessage))
            {
                this._dataLayer.Clients.Add(new Client(name, lastname, password, birthdate, licencedate, isaccompanieddriving, licencenumber));
                ErrorMessage = "Utilisateur Créé";
            }
            return ErrorMessage;
        }

        public string CheckVehicleData(string brand, string model, string plate, string color, string reservationprice, string kilometerrate, string taxhorsepower, string reserved)
        {
            bool isreserved = (reserved.ToLower() == "true" ? true : false);
            string ErrorMessage = "";

            if (string.IsNullOrEmpty(brand))
            {
                if (!string.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage += " et ";
                ErrorMessage += "Le véhicule n'a pas de marque";
            }
            if (string.IsNullOrEmpty(model))
            {
                if (!string.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage += " et ";
                ErrorMessage += "Le véhicule n'a pas de modele";
            }
            if (string.IsNullOrEmpty(plate))
            {
                if (!string.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage += " et ";
                ErrorMessage += "Le véhicule n'a pas de plaque d'immatriculation";
            }
            Vehicle = this._dataLayer.Vehicles.SingleOrDefault(_ => _.Plate.ToUpper() == plate.ToUpper());
            if (Vehicle != null)
            {
                if (!string.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage += " et ";
                ErrorMessage = "La plaque d'immatriculation n'est pas unique";
            }
            if (string.IsNullOrEmpty(color))
            {
                if (!string.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage += " et ";
                ErrorMessage += "Le véhicule n'a pas de couleur";
            }
            if (string.IsNullOrEmpty(reservationprice))
            {
                if (!string.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage += " et ";
                ErrorMessage += "Le véhicule n'a pas de prix de réservation";
            }
            if (string.IsNullOrEmpty(kilometerrate))
            {
                if (!string.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage += " et ";
                ErrorMessage = "Le véhicule n'a pas de prix au kilomètre";
            }
            if (string.IsNullOrEmpty(taxhorsepower))
            {
                if (!string.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage += " et ";
                ErrorMessage = "Le véhicule n'a pas de chevaux fiscaux";
            }
            if (string.IsNullOrEmpty(ErrorMessage))
            {
                this._dataLayer.Vehicles.Add(new Vehicle(brand, model, plate, color, int.Parse(reservationprice), float.Parse(kilometerrate), int.Parse(taxhorsepower), isreserved));
                ErrorMessage = "Vehicule Ajouté";
            }
            return ErrorMessage;
        }
        public bool CheckVehicleExists(string brand, string model, string plate, string color)
        {
            bool VehicleExists = false;

            Vehicle = this._dataLayer.Vehicles.SingleOrDefault(_ => _.Brand.ToUpper() == brand.ToUpper() && _.Model.ToUpper() == model.ToUpper() && _.Plate.ToUpper() == plate.ToUpper() && _.Color.ToUpper() == color.ToUpper());
            if (Vehicle != null)
            {
                VehicleExists = true;
            }
            return VehicleExists;
        }

        public string CheckReservations(DateTime start, DateTime end)
        {
            string ErrorMessage = "";
            Reservations = _dataLayer.Reservations.Where(_ => (_.StartDate >= start && _.EndDate <= end) || (_.StartDate <= start && _.EndDate >= end) || (_.StartDate <= end && _.EndDate >= end)).ToList();

            if (Reservations.Count == 0)
                ErrorMessage = "Il n'y a aucune reservation entre ces dates";

            return ErrorMessage;
        }

        public string CreateReservation(Client client, Vehicle vehicle, DateTime start, DateTime end, int plannedkilometer)
        {
            string ErrorMessage = "";
            DateTime? TmpBirthday = DateTime.Parse(client.BirthDate);
            DateTime? TmpLicenceDate = DateTime.Parse(client.LicenceDate);
            
            if (TmpLicenceDate.HasValue) 
            {
                if ((TmpBirthday > DateTime.Now.AddYears(-21) && vehicle.TaxHorsePower >= 8) ||
                    (TmpBirthday < DateTime.Now.AddYears(-21) && TmpBirthday > DateTime.Now.AddYears(-25) && vehicle.TaxHorsePower >= 13))
                    ErrorMessage += "Réservation refusée";
                else
                {
                    ErrorMessage += "Réservation autorisée";
                    ReservationDone = true;
                    Reservation = new Reservation(client, vehicle, start, end, plannedkilometer, 0);
                }
            }
            else {
                ErrorMessage = "Réservation refusée";
                ReservationDone = false;
            }
            return ErrorMessage;
        }

        public float CalculatePrice(Vehicle v, int PlannedKms, int RealKms)
        {
            float FinalPrice = 0;
            if (ReservationDone)
            {
                if (PlannedKms > RealKms)
                    FinalPrice = (float)(v.ReservationPrice + v.KilometerRate * RealKms);
                else
                    FinalPrice = (float)(v.ReservationPrice + v.KilometerRate * RealKms + ((RealKms - PlannedKms) * 0.05));
            }
            return FinalPrice;
        }

    }
}

using TechTalk.SpecFlow;
using FluentAssertions;
using LocationLibrary;
using LocationTest.Fake;
using System;
using System.Collections.Generic;

namespace LocationTest.Steps
{
    [Binding]
    public sealed class ReservationStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;

        private DateTime _startLocation;
        private DateTime _endLocation;
        private int _PlannedKilometer;
        private float _FinalPrice;
        private Vehicle _vehicle;
        private Client _client;
        private List<Reservation> _reservations;
        private string _lastErrorMessage;
        private Location _target;
        private FakeDataLayer _fakeDataLayer;

        public ReservationStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            this._fakeDataLayer = new FakeDataLayer();
            this._target = new Location(this._fakeDataLayer);
        }

        [Given(@"Init Client")]
        public void GivenInitClient(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                bool isaccompanieddriving = (row["Conduite Accompagnée"].ToLower() == "true" ? true : false);
                this._fakeDataLayer.Clients.Add(new Client(row["Prénom"], row["Nom"], row["Mot de passe"], row["Date de naissance"], row["Date obtention permis"], isaccompanieddriving, row["Numéro permis"]));
            }
        }

        [Given(@"Init Vehicule")]
        public void GivenInitVehicules(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                bool isreserved = (row["Reserver"].ToLower() == "true" ? true : false);
                this._fakeDataLayer.Vehicles.Add(new Vehicle(row["Marque"], row["Modèle"], row["Plaque d'immatriculation"], row["Couleur"], int.Parse(row["Prix de réservation"]), float.Parse(row["Prix au Km"]), int.Parse(row["Chevaux Fiscaux"]), isreserved));
            }
        }

        [Given(@"Init Reservation")]
        public void GivenLesReservationsSont(Table table)
        {
            foreach (TableRow row in table.Rows)
            {             
                bool ClientExists = this._target.CheckClientExists(row["Prénom"], row["Nom"]);

                bool VehicleExists = this._target.CheckVehicleExists(row["Marque"], row["Modèle"], row["Plaque d'immatriculation"], row["Couleur"]);

                if (string.IsNullOrEmpty(this._lastErrorMessage) && VehicleExists && ClientExists)
                {
                    Client client = this._target.Client;
                    Vehicle vehicle = this._target.Vehicle;

                    this._fakeDataLayer.Reservations.Add(new Reservation(client, vehicle, DateTime.Parse(row["Date de début"]), DateTime.Parse(row["Date de fin"]), int.Parse(row["Kms estimés"]), int.Parse(row["Kms réalisés"])));
                }
            }
        }

        [When(@"connexion de l'utilisateur '(.*)' '(.*)' '(.*)'")]
        public void WhenConnexionDeLUtilisateur(string name, string lastname, string password)
        {
            this._lastErrorMessage = this._target.ConnectUser(name, lastname, password);
            this._client = this._target.Client;
        }

        [Given(@"Debut de location : '(.*)' Fin de location : '(.*)'")]
        public void GivenDebutLocationFinLocation(string start, string end)
        {
            this._startLocation = DateTime.Parse(start);
            this._endLocation = DateTime.Parse(end);
        }

        [Given(@"l'utilisateur sélectionne le véhicule '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void GivenLutilisateurSelectionneLeVehicule(string brand, string model, string plate, string color)
        {
            bool VehicleExists = this._target.CheckVehicleExists(brand, model, plate, color);
            this._lastErrorMessage = (VehicleExists == true ? "Le véhicule existe" : "Le véhicule n'existe pas");
            this._vehicle = this._target.Vehicle;
        }

        [Given(@"l'utilisateur prévoie de faire '(.*)' kms")]
        public void GivenLUtilisateurPrevoieDeFaire(string kms)
        {
            this._PlannedKilometer = int.Parse(kms);
        }
        [Given(@"L'utilisateur rend la voiture avec '(.*)' kms")]
        public void GivenLUtilisateurRendLaVoitureAvec(string kms)
        {
            this._FinalPrice = this._target.CalculatePrice(_vehicle, _PlannedKilometer, int.Parse(kms));
        }


        [When(@"l'utilisateur veut connaitre les reservations")]
        public void WhenLutilisateurVeutConnaitreLesReservations()
        {
            this._lastErrorMessage = this._target.CheckReservations(this._startLocation, this._endLocation);
            this._reservations = this._target.Reservations;
        }

        [When(@"l'utilisateur valide")]
        public void WhenLutilisateurSouhaiteReserver()
        {
            this._lastErrorMessage = this._target.CreateReservation(this._client, this._vehicle, this._startLocation, this._endLocation, this._PlannedKilometer);
        }

        [Then(@"les véhicules disponibles sont")]
        public void ThenLesVehiculesDisponiblesSont(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                bool VehicleExists = this._target.CheckVehicleExists(row["Marque"], row["Modèle"], row["Plaque d'immatriculation"], row["Couleur"]);
                this._lastErrorMessage = (VehicleExists == true ? "Le véhicule existe" : "Le véhicule n'existe pas");
                Vehicle v = this._target.Vehicle;
                this._reservations.ForEach(delegate (Reservation r)
                {
                    if (r.Vehicle == v)
                    {
                        v = null;
                    }
                });
                row["Marque"].Should().Be(v.Brand);
                row["Modèle"].Should().Be(v.Model);
                row["Plaque d'immatriculation"].Should().Be(v.Plate);
                row["Couleur"].Should().Be(v.Color);
                int.Parse(row["Prix de réservation"]).Should().Be(v.ReservationPrice);
                float.Parse(row["Prix au Km"]).Should().Be(v.KilometerRate);
                int.Parse(row["Chevaux Fiscaux"]).Should().Be(v.TaxHorsePower);

            }
        }

        [Then(@"Resultat : '(.*)'")]
        public void ThenResultat(string errorMessage)
        {
            this._lastErrorMessage.Should().Be(errorMessage);
        }

        [Then(@"le prix final est '(.*)'")]
        public void ThenLePrixFinalEst(string Prix)
        {
            this._FinalPrice.Should().Be(float.Parse(Prix));
        }

        
    }
}

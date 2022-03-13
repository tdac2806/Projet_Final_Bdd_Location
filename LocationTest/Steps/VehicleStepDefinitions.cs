using TechTalk.SpecFlow;
using FluentAssertions;
using LocationLibrary;
using LocationTest.Fake;

namespace LocationTest.Steps
{
    [Binding]
    public sealed class VehicleStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;

        private string _selectedVehicleName;
        private string _lastErrorMessage;
        private Location _target;
        private FakeDataLayer _fakeDataLayer;

        public VehicleStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            this._fakeDataLayer = new FakeDataLayer();
            this._target = new Location(this._fakeDataLayer);
        }

        [Given(@"Init Vehicule bdd")]
        public void GivenInitBdd(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                bool isreserved = (row["Reserver"].ToLower() == "true" ? true : false);
                this._fakeDataLayer.Vehicles.Add(new Vehicle(row["Marque"], row["Modèle"], row["Plaque d'immatriculation"], row["Couleur"], int.Parse(row["Prix de réservation"]), float.Parse(row["Prix au Km"]), int.Parse(row["Chevaux Fiscaux"]), isreserved));
            }
        }

        [When(@"Creation d'un Vehicule : '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void WhenCreationDunVehicule(string brand, string model, string plate, string color, string reservationprice, string kilometerrate, string taxhorsepower, string reserved)
        {
            this._lastErrorMessage = this._target.CheckVehicleData(brand, model, plate, color, reservationprice, kilometerrate, taxhorsepower, reserved);
        }

        [When(@"Recherche d'un Vehicule : '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void WhenRechercheDunVehicule(string brand, string model, string plate, string color)
        {
            bool VehicleExists = this._target.CheckVehicleExists(brand, model, plate, color);

            this._lastErrorMessage = (VehicleExists == true ? "Le véhicule existe" : "Le véhicule n'existe pas");
        }

        [Then(@"Vehicule resultat : '(.*)'")]
        public void ThenResultat(string errorMessage)
        {
            this._lastErrorMessage.Should().Be(errorMessage);
        }
    }
}

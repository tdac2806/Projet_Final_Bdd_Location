using TechTalk.SpecFlow;
using FluentAssertions;
using LocationLibrary;
using LocationTest.Fake;
using System;

namespace LocationTest.Steps
{
    [Binding]
    public sealed class ClientStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;

        private string _firstname;
        private string _lastname;
        private string _password;
        private string _lastErrorMessage;
        private Location _target;
        private FakeDataLayer _fakeDataLayer;

        public ClientStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            this._fakeDataLayer = new FakeDataLayer();
            this._target = new Location(this._fakeDataLayer);
        }


        [Given(@"Init Client bdd")]
        public void GivenInitClientBdd(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                bool isaccompanieddriving = (row["Conduite Accompagnée"].ToLower() == "true" ? true : false);
                this._fakeDataLayer.Clients.Add(new Client(row["Prénom"], row["Nom"], row["Mot de passe"], row["Date de naissance"], row["Date obtention permis"], isaccompanieddriving, row["Numéro permis"]));
            }
        }

        [Given(@"le nom d'utilisateur est '(.*)' '(.*)'")]
        public void GivenLeNomDUtilisateurEst(string prenom, string nom)
        {
            this._firstname = prenom;
            this._lastname = nom;
        }

        [Given(@"le mot de passe est '(.*)'")]
        public void GivenLeMotDePasseEst(string password)
        {
            this._password = password;
        }

        [When(@"connexion de l'utilisateur")]
        public void WhenConnexionDeLUtilisateur()
        {
            this._lastErrorMessage = this._target.ConnectUser(this._firstname, this._lastname, this._password);
        }

        [When(@"Creation d'un client : '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void WhenUnUtilisateurEstCree(string name, string lastname, string password, string birthdate, string licencedate, string accompanieddriving, string licencenumber)
        {
            this._lastErrorMessage = this._target.CheckUserData(name, lastname, password, birthdate, licencedate, accompanieddriving, licencenumber);

        }

        [Then(@"Client resultat : '(.*)'")]
        public void ThenResultat(string errorMessage)
        {
            this._lastErrorMessage.Should().Be(errorMessage);
        }


    }
}

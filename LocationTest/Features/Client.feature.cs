﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.7.0.0
//      SpecFlow Generator Version:3.7.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace LocationTest.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.7.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("Client", SourceFile="Features\\Client.feature", SourceLine=0)]
    public partial class ClientFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "Client.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Client", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Prénom",
                        "Nom",
                        "Mot de passe",
                        "Date de naissance",
                        "Date obtention permis",
                        "Conduite Accompagnée",
                        "Numéro permis"});
            table1.AddRow(new string[] {
                        "Tristan",
                        "DA COSTA",
                        "azerty",
                        "2000-06-28",
                        "2020-02-03",
                        "true",
                        "911091204209"});
            table1.AddRow(new string[] {
                        "Eliott",
                        "DELANNAY",
                        "1234",
                        "2005-01-01",
                        "",
                        "false",
                        ""});
            table1.AddRow(new string[] {
                        "Aldrick",
                        "CLERET",
                        "5678",
                        "2000-01-31",
                        "",
                        "false",
                        "965412978369"});
#line 4
 testRunner.Given("Init Client bdd", ((string)(null)), table1, "Given ");
#line hidden
        }
        
        public virtual void ConnexionClient(string prenom, string nom, string password, string retour, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Prenom", prenom);
            argumentsOfScenario.Add("Nom", nom);
            argumentsOfScenario.Add("password", password);
            argumentsOfScenario.Add("Retour", retour);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Connexion Client", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 11
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 12
 testRunner.Given(string.Format("le nom d\'utilisateur est \'{0}\' \'{1}\'", prenom, nom), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 13
 testRunner.And(string.Format("le mot de passe est \'{0}\'", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 14
 testRunner.When("connexion de l\'utilisateur", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 15
 testRunner.Then(string.Format("Client resultat : \'{0}\'", retour), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Connexion Client, Tristan", SourceLine=17)]
        public virtual void ConnexionClient_Tristan()
        {
#line 11
this.ConnexionClient("Tristan", "Da Costa", "azerty", "Utilisateur connecté", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Connexion Client, Eliott", SourceLine=17)]
        public virtual void ConnexionClient_Eliott()
        {
#line 11
this.ConnexionClient("Eliott", "Delannay", "5678", "Mot de passe incorrect", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Connexion Client, John", SourceLine=17)]
        public virtual void ConnexionClient_John()
        {
#line 11
this.ConnexionClient("John", "Doe", "1234", "Utilisateur inconnu", ((string[])(null)));
#line hidden
        }
        
        public virtual void CreationClient(string prenom, string nom, string motDePasse, string dateDeNaissance, string dateObtentionPermis, string conduiteAccompagnee, string numeroPermis, string retour, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Prenom", prenom);
            argumentsOfScenario.Add("Nom", nom);
            argumentsOfScenario.Add("Mot de passe", motDePasse);
            argumentsOfScenario.Add("Date de naissance", dateDeNaissance);
            argumentsOfScenario.Add("Date obtention permis", dateObtentionPermis);
            argumentsOfScenario.Add("Conduite Accompagnée", conduiteAccompagnee);
            argumentsOfScenario.Add("Numéro permis", numeroPermis);
            argumentsOfScenario.Add("Retour", retour);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creation Client", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 22
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 23
 testRunner.When(string.Format("Creation d\'un client : \'{0}\' \'{1}\' \'{2}\' \'{3}\' \'{4}\' \'{5}\' \'{6}\'", prenom, nom, motDePasse, dateDeNaissance, dateObtentionPermis, conduiteAccompagnee, numeroPermis), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 24
 testRunner.Then(string.Format("Client resultat : \'{0}\'", retour), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Creation Client, Variant 0", SourceLine=26)]
        public virtual void CreationClient_Variant0()
        {
#line 22
this.CreationClient("Tristan", "DA COSTA", "azerty", "2000-06-28", "2020-02-03", "true", "911091204209", "Utilisateur Créé", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Creation Client, Variant 1", SourceLine=26)]
        public virtual void CreationClient_Variant1()
        {
#line 22
this.CreationClient("Eliott", "DELANNAY", "1234", "", "", "false", "", "Date de naissance manquante", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Creation Client, Variant 2", SourceLine=26)]
        public virtual void CreationClient_Variant2()
        {
#line 22
this.CreationClient("Aldrick", "CLERET", "", "2000-01-31", "", "false", "965412978369", "Mot de passe manquant", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Creation Client, Variant 3", SourceLine=26)]
        public virtual void CreationClient_Variant3()
        {
#line 22
this.CreationClient("", "DELANNAY", "1234", "2005-01-01", "", "false", "", "Prenom manquant", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Creation Client, Variant 4", SourceLine=26)]
        public virtual void CreationClient_Variant4()
        {
#line 22
this.CreationClient("Aldrick", "", "5678", "2000-01-31", "", "false", "965412978369", "Nom manquant", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Creation Client, Variant 5", SourceLine=26)]
        public virtual void CreationClient_Variant5()
        {
#line 22
this.CreationClient("", "", "5678", "2000-01-31", "", "false", "965412978369", "Prenom manquant et Nom manquant", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Creation Client, Variant 6", SourceLine=26)]
        public virtual void CreationClient_Variant6()
        {
#line 22
this.CreationClient("", "", "", "2000-01-31", "", "false", "965412978369", "Prenom manquant et Nom manquant et Mot de passe manquant", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion

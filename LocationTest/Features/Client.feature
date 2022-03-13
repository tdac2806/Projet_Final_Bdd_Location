Feature: Client

Background: 
	Given Init Client bdd
	| Prénom  | Nom      | Mot de passe | Date de naissance | Date obtention permis | Conduite Accompagnée | Numéro permis |
	| Tristan | DA COSTA | azerty       | 2000-06-28        | 2020-02-03            | true                 | 911091204209  |
	| Eliott  | DELANNAY | 1234         | 2005-01-01        |                       | false                |               |
	| Aldrick | CLERET   | 5678         | 2000-01-31        |                       | false                | 965412978369  |


Scenario: Connexion Client
	Given le nom d'utilisateur est '<Prenom>' '<Nom>'
	And le mot de passe est '<password>'
	When connexion de l'utilisateur
	Then Client resultat : '<Retour>'
	Examples: 
	| Prenom  | Nom      | password | Retour                  |
	| Tristan | Da Costa | azerty   | Utilisateur connecté    |
	| Eliott  | Delannay | 5678     | Mot de passe incorrect  |
	| John    | Doe      | 1234     | Utilisateur inconnu     |

Scenario: Creation Client
	When Creation d'un client : '<Prenom>' '<Nom>' '<Mot de passe>' '<Date de naissance>' '<Date obtention permis>' '<Conduite Accompagnée>' '<Numéro permis>'
	Then Client resultat : '<Retour>'
	Examples: 
	| Prenom  | Nom      | Mot de passe | Date de naissance | Date obtention permis | Conduite Accompagnée | Numéro permis | Retour                                                   |
	| Tristan | DA COSTA | azerty       | 2000-06-28        | 2020-02-03            | true                 | 911091204209  | Utilisateur Créé                                         |
	| Eliott  | DELANNAY | 1234         |                   |                       | false                |               | Date de naissance manquante                              |
	| Aldrick | CLERET   |              | 2000-01-31        |                       | false                | 965412978369  | Mot de passe manquant                                    |
	|         | DELANNAY | 1234         | 2005-01-01        |                       | false                |               | Prenom manquant                                          |
	| Aldrick |          | 5678         | 2000-01-31        |                       | false                | 965412978369  | Nom manquant                                             |
    |         |          | 5678         | 2000-01-31        |                       | false                | 965412978369  | Prenom manquant et Nom manquant                          |
	|         |          |              | 2000-01-31        |                       | false                | 965412978369  | Prenom manquant et Nom manquant et Mot de passe manquant |
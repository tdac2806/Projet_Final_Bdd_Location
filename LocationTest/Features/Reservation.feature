Feature: Reservation

Background:
	Given Init Client
	| Prénom  | Nom      | Mot de passe | Date de naissance | Date obtention permis | Conduite Accompagnée | Numéro permis |
	| Tristan | DA COSTA | azerty       | 2000-06-28        | 2020-02-03            | true                 | 911091204209  |
	| Eliott  | DELANNAY | 1234         | 2005-01-01        |                       | false                |               |
	| Aldrick | CLERET   | 5678         | 2000-01-31        |                       | false                | 965412978369  |
	| John    | Doe      | uiop         | 1976-01-31        | 1990-01-01            | false                | 156478964123  |
	And Init Vehicule
	| Marque     | Modèle  | Plaque d'immatriculation | Couleur | Prix de réservation | Prix au Km | Chevaux Fiscaux | Reserver |
	| Citroen    | C4      | AA-123-AA                | Gris    | 50                  | 0.12       | 7               | false    |
	| Volkswagen | Golf    | AA-456-AA                | Bleu    | 50                  | 0.15       | 6               | false    |
	| Hyundai    | Tucson  | AA-789-AA                | Noir    | 80                  | 0.25       | 8               | false    |
	| Ford       | Mustang | AB-123-AA                | Rouge   | 80                  | 0.25       | 21              | false    |
	| Audi       | R8      | AB-456-AA                | Noir    | 100                 | 1          | 50              | false    |
	| Koenigsegg | Agera R | AB-789-AA                | Blanc   | 200                 | 8          | 139             | false    |
	And Init Reservation
	| Prénom  | Nom      | Marque     | Modèle  | Plaque d'immatriculation | Couleur | Date de début | Date de fin | Kms estimés | Kms réalisés |
	| Tristan | DA COSTA | Volkswagen | Golf    | AA-456-AA                | Bleu    | 2022-03-05    | 2022-03-06  | 350         | 320          |
	| Tristan | DA COSTA | Hyundai    | Tucson  | AA-789-AA                | Noir    | 2022-03-07    | 2022-03-09  | 180         | 210          |
	| Aldrick | CLERET   | Citroen    | C4      | AA-123-AA                | Gris    | 2022-03-07    | 2022-03-11  | 580         | 560          |
	| John    | Doe      | Koenigsegg | Agera R | AB-789-AA                | Blanc   | 2022-03-11    | 2022-03-12  | 200         | 190          |
	| John    | Doe      | Audi       | R8      | AB-456-AA                | Noir    | 2022-03-12    | 2022-03-13  | 200         | 220          |


Scenario: Réservation d'un vehicule
	When connexion de l'utilisateur '<Prenom>' '<Nom>' '<Mot de passe>'
	Given Debut de location : '2022-03-10' Fin de location : '2022-03-11'
	When l'utilisateur veut connaitre les reservations
	Then les véhicules disponibles sont
	| Marque     | Modèle  | Plaque d'immatriculation | Couleur | Prix de réservation | Prix au Km | Chevaux Fiscaux |
	| Volkswagen | Golf    | AA-456-AA                | Bleu    | 50                  | 0.15       | 6               |
	| Hyundai    | Tucson  | AA-789-AA                | Noir    | 80                  | 0.25       | 8               |
	| Ford       | Mustang | AB-123-AA                | Rouge   | 80                  | 0.25       | 21              |
	Given l'utilisateur sélectionne le véhicule '<Marque>' '<Modèle>' '<Plaque d'immatriculation>' '<Couleur>'
	And l'utilisateur prévoie de faire '<Kms estimés>' kms
	When l'utilisateur valide
	Then Resultat : '<Retour>'
	Given L'utilisateur rend la voiture avec '<Kms Réalisés>' kms
	Then le prix final est '<Prix Total>'
	Examples: 
	| Prenom  | Nom      | Mot de passe | Marque     | Modèle  | Plaque d'immatriculation | Couleur | Kms estimés | Retour                | Kms Réalisés | Prix Total |
	| Tristan | DA COSTA | azerty       | Hyundai    | Tucson  | AA-789-AA                | Noir    | 180         | Réservation autorisée | 150          | 117.5      |
	| Tristan | DA COSTA | azerty       | Ford       | Mustang | AB-123-AA                | Rouge   | 180         | Réservation refusée   | 0            | 0          |
	| John    | Doe      | uiop         | Volkswagen | Golf    | AA-456-AA                | Bleu    | 200         | Réservation autorisée | 210          | 82         |
	| John    | Doe      | uiop         | Ford       | Mustang | AB-123-AA                | Rouge   | 200         | Réservation autorisée | 180          | 125        |



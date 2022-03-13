Feature: Vehicule

Background:
	Given Init Vehicule bdd
		| Marque     | Modèle  | Plaque d'immatriculation | Couleur | Prix de réservation | Prix au Km | Chevaux Fiscaux | Reserver |
		| Citroen    | C4      | AA-123-AA                | Gris    | 50                  | 0.12       | 7               | true     |
		| Volkswagen | Golf    | AA-456-AA                | Bleu    | 50                  | 0.15       | 6               | false    |
		| Hyundai    | Tucson  | AA-789-AA                | Noir    | 80                  | 0.25       | 8               | false    |
		| Ford       | Mustang | AB-123-AA                | Rouge   | 80                  | 0.25       | 21              | true     |
		| Audi       | R8      | AB-456-AA                | Noir    | 100                 | 1          | 50              | false    |
		| Koenigsegg | Agera R | AB-789-AA                | Blanc   | 200                 | 8          | 139             | false    |



Scenario: Creation Vehicule
	When Creation d'un Vehicule : '<Marque>' '<Modèle>' '<Plaque d'immatriculation>' '<Couleur>' '<Prix de réservation>' '<Prix au Km>' '<Chevaux Fiscaux>' '<Reserver>'
	Then Vehicule resultat : '<Retour>'
	Examples: 
| Marque     | Modèle  | Plaque d'immatriculation | Couleur | Prix de réservation | Prix au Km | Chevaux Fiscaux | Reserver | Retour                                          |
| Volkswagen | Golf    |                          | Bleu    | 50                  | 0.15       | 6               | false    | Le véhicule n'a pas de plaque d'immatriculation |
| Hyundai    | Tucson  | AA-789-AA                | Noir    | 80                  | 0.25       | 7               | false    | La plaque d'immatriculation n'est pas unique    |
| Ford       | Mustang | AC-123-AA                |         | 80                  | 0.25       | 21              | false    | Le véhicule n'a pas de couleur                  |
| Ford       | Mustang | AC-123-AA                | Rouge   | 80                  | 0.25       | 21              | false    | Vehicule Ajouté                                 |
|            | R8      | AC-456-AA                | Noir    | 100                 | 1          | 50              | false    | Le véhicule n'a pas de marque                   |
| Renault    |         | AC-789-AA                | Gris    | 30                  | 0.10       | 4               | false    | Le véhicule n'a pas de modele                   |
| Koenigsegg | Agera R | AD-123-AA                | Blanc   | 200                 |            | 139             | false    | Le véhicule n'a pas de prix au kilomètre        |
| Citroen    | C4      | AD-456-AA                | Gris    | 50                  | 0.12       |                 | false    | Le véhicule n'a pas de chevaux fiscaux          |
| Citroen    | C4      | AD-789-AA                | Gris    |                     | 0.12       | 7               | false    | Le véhicule n'a pas de prix de réservation      |



Scenario: Véhicule exists
	When Recherche d'un Vehicule : '<Marque>' '<Modèle>' '<Plaque d'immatriculation>' '<Couleur>'
	Then Vehicule resultat : '<Retour>'
	Examples: 
	| Marque     | Modèle | Plaque d'immatriculation | Couleur | Retour                   |
	| Renault    | Twingo | AZ-123-CD                | Gris    | Le véhicule n'existe pas |
	| Volkswagen | Golf   | AA-456-AA                | Bleu    | Le véhicule existe       |
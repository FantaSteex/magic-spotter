# Magic Spotter #

Master's degree project in Dot Net C#.

The goal is to create an application able to help a sniper in Arma 3 for writing down informations about its targets.

Using vocal recognition, the user will be able to add new targets and specify their distance, elevation, speed and additionnal comment. 
He will eventually be able to ask the application to give him informations about his targets : zeroing and adjustment, distance etc...

# How to use it #

As the vocal recognition is in french right now, the different states/process of the applications are explained in french. "Between double quotes" are the vocal commands.

Processus de base (état de base de l'application) -> 
	"Nouvelle cible"
	"Modifier"
	"J'engage l'ennemi"

"Nouvelle cible" ->
	"Distance" -> Entier de 0 à 2500 inclus
	"Elévation" -> float de -90.0 à 90.0
	"Vitesse" -> "Statique", "Recherche", "Patrouille" ou "Course"
	"Commentaire" -> Courte description de la cible

"Modifier" -> Entier correspondant à l'identifiant de la cible
	-> Processus équivalent à celui de "Nouvelle cible"

"J'engage l'ennemi" -> Entier correspondant à l'identifiant de la cible
	"Elimination confirmée" -> Retour au mode "J'engage l'ennemi"

"Annuler" -> Annule l'action courante et retourne au processus parent (par exemple : "Nouvelle cible"->"Distance"->"Annuler" ramène au processus "Nouvelle cible")
"Terminé" -> Annule l'action courante et retourne au processus de base
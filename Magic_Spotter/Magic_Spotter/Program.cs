using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Magic_Spotter {
	/// <summary>
	/// Main entry of the whole program
	/// </summary>
	static class Program {

		// Dictionary that gives a label for each process (label will be shown to the user)
		public static Dictionary<string, string> processToUI = new Dictionary<string, string>() {
			{ "", "Donnez un mot-clef : <<Nouvelle cible>>, <<Modifier>> ou <<J'engage l'ennemi>>"},
			{ "nouvelle cible", "Création d'une nouvelle cible. Dites <<Distance>>, <Elevation>>, <<Vitesse>> ou <<Commentaire>>.\nDites <<Terminé>> pour valider la création de la cible."},
			{ "distance", "Distance : donnez un nombre allant de 0 à 2500. <<Annuler>> pour annuler."},
			{ "elevation", "Elévation : donnez un nombre allant de -90.0 à 90.0. <<Annuler>> pour annuler."},
			{ "vitesse", "Vitesse : <<Statique>>, <<Recherche>>, <<Patrouille>> ou <<Course>>. <<Annuler>> pour annuler."},
			{ "commentaire", "Commentaire : donnez une courte description de la cible. <<Annuler>> pour annuler."},
			{ "engager ennemi", "Engagement de l'ennemi : donnez le numéro d'une cible. <<Annuler>> pour annuler."},
			{ "cible engagée", "Cible engagée : <<Elimination confirmée>>, <<Annuler>> pour changer de cible \nou <<Terminé>> pour arrêter d'engager les cibles"},
			{ "modifier", "Modifier une cible : donnez l'identifiant (nombre) d'une cible. <<Annuler>> pour annuler." },
			{ "modification", "Modification de la cible : <<Distance>>, <Elevation>>, <<Vitesse>> ou <<Commentaire>>. <<Annuler>> pour annuler." }
		};	
		static Dictionary<int, Target> targets = new Dictionary<int, Target>(); // Dictionary that contains every target instanciated in the application
		static SpeechRecognition speechRecognizer = new SpeechRecognition();    // SpeechRecognition engine used to recognized free text
		static KeywordsRecognition keywordsRecognizer = new KeywordsRecognition(true);  // KeywordsRecognition engine used to recognized specific keywords ("New target", "Distance" etc...)
		static Dictionary<int, Dictionary<int, double>> adjustmentsTable = Adjustments.adjustmentsTable;    // singleton instance of an adjustments table
		static Form1 form;	// Application's window
		static int currentTargetId = 0;	// Id of the target we are focusing for modification/engaging
		static string currentProcess = "", previousProcess = "";	// Current and previous process, handled by method updateProcess()

		/// <summary>
		/// Main entry of the application
		/// </summary>
		[STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			form = new Form1();	// Initialized the application's UI
			
			/***********************
			 * Events subscription *
			 ***********************/
			
			// Vocal recognition : start/stop events
			keywordsRecognizer.stopping += new EventHandler(OnKeywordsRecognizerStopping);
			keywordsRecognizer.starting += new EventHandler(OnKeywordsRecognizerStarting);
			speechRecognizer.stopping += new EventHandler(OnSpeechRecognizerStopping);
			speechRecognizer.starting += new EventHandler(OnSpeechRecognizerStarting);

			// Vocal recognition : recognized event
			keywordsRecognizer.recognized += new KeywordsRecognition.KeywordRecognizedEventHandler<KeywordRecognizedEventArgs>(OnKeywordsRecognizerRecognized);
			speechRecognizer.recognized += new SpeechRecognition.FreeSpeechRecognizedEventHandler<FreeSpeechRecognizedEventArgs>(OnFreeSpeechRecognizerRecognized);
			
			Application.Run(form);  // Starts the application
		}

		/// <summary>
		/// Creates a new target, adds it to the list and creates its graphical interface
		/// </summary>
		/// <param name="id">Integer value of the indentifier</param>
		/// <param name="f">Reference to the graphical interface, required to add components</param>
        static void addTarget(int id) {
			if (!targets.ContainsKey(id)) {	// If target isn't already instanciated
				targets.Add(id, new Target(id));    // Adds the target to the list of targets
				form.SetTargetUI(targets[id].getPanel());	// Displays the target on the form
			}
        }

		/*****************************************
		 * Speech recognition events description *
		 *****************************************/

		/// <summary>
		/// Keyword is recognized
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e">Recognized keyword will be able through e.GetText()</param>
		static void OnKeywordsRecognizerRecognized(object sender, KeywordRecognizedEventArgs e) {

			form.SetLabelRecognitionText(e.GetText());  // Updates lblRecognition's Text with recognized vocal's value
			int targetId = 0;
			if (currentProcess == "cible engagée") { // Target engaged
				if (e.GetText() == "Elimination confirmée" && currentTargetId != 0) {   // Eliminate the engaged target
					targets[currentTargetId].eliminate();
					currentTargetId = 0;
					updateProcess("engager ennemi", "");    // Return to engaging process, will wait another target's id
				} else if (e.GetText() == "Terminé") {  // Returns to waiting process
					disengageEnnemi(currentTargetId);
					currentTargetId = 0;
					updateProcess("", "");
				} else if (e.GetText() == "Annuler") {  // Returns to engaging process, will wait a target's id
					disengageEnnemi(currentTargetId);
					currentTargetId = 0;
					updateProcess("engager ennemi", "");
				}
			} else if (currentProcess == "modifier") {
				if (int.TryParse(e.GetText(), out targetId)) {  // Target's id given, want to modify it
					if (targets.ContainsKey(targetId)) {
						currentTargetId = targetId;
						updateProcess("modification");
					}
				} else if (e.GetText() == "Terminé" || e.GetText() == "Annuler") {  // Returns to waiting process
					updateProcess("", "");
				}
			} else if (currentProcess == "engager ennemi") {
				if (int.TryParse(e.GetText(), out targetId)) {  // Integer given by user, will be the target's id
					currentTargetId = targetId;
					engageEnnemi(currentTargetId);
				} else if (e.GetText() == "Terminé" || e.GetText() == "Annuler") {  // Returns to waiting process
					updateProcess("", "");
				}
			} else {
				switch (e.GetText()) {
					case "Nouvelle cible":  // New target
						if (currentTargetId == 0) {
							int newId = targets.Count() + 1;
							addTarget(newId);
							currentTargetId = newId;
							updateProcess("nouvelle cible", "");
						}
						break;
					case "Distance":    // Distance
						if (currentTargetId != 0 && (currentProcess == "nouvelle cible" || currentProcess == "modification")) {
							updateProcess("distance");
							keywordsRecognizer.stop();
						}
						break;
					case "Elévation":   // Elevation
						if (currentTargetId != 0 && (currentProcess == "nouvelle cible" || currentProcess == "modification")) {
							updateProcess("elevation");
							keywordsRecognizer.stop();
						}
						break;
					case "Vitesse":
						if (currentTargetId != 0 && (currentProcess == "nouvelle cible" || currentProcess == "modification")) {
							updateProcess("vitesse");
						}
						break;
					case "Statique":
					case "Patrouille":
					case "Recherche":
					case "Course":    // A speed is given by the user
						if (currentTargetId != 0 && currentProcess == "vitesse") {
							Debug.WriteLine("Target {0} speed : {1}", currentTargetId, targets[currentTargetId].GetSpeed());
							targets[currentTargetId].SetSpeed(new Speed(e.GetText()));
							updateProcess(previousProcess, "");
							Debug.WriteLine("Target {0} speed set : {1}", currentTargetId, targets[currentTargetId].GetSpeed());
						}
						break;
					case "Commentaire": // Comment
						if (currentTargetId != 0 && (currentProcess == "nouvelle cible" || currentProcess == "modification")) {
							updateProcess("commentaire");
							keywordsRecognizer.stop();
						}
						break;
					case "Terminé":
					case "Annuler":// Cancels process
						updateProcess("");
						currentTargetId = 0;
						break;
					case "J'engage l'ennemi":   // Engaging ennemi
						if (currentTargetId == 0 && currentProcess == "" && targets.Count > 0) {
							updateProcess("engager ennemi");
						}
						break;
					case "Modifier":    // Modify a target
						if (currentTargetId == 0 && currentProcess == "" && targets.Count > 0) {
							updateProcess("modifier");
						}
						break;
				}
			}
		}

		/// <summary>
		/// Speech is recognized
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e">Recognized speech will be able through e.GetText()</param>
		static void OnFreeSpeechRecognizerRecognized(object sender, FreeSpeechRecognizedEventArgs e) {
			form.SetLabelRecognitionText(e.GetText());
			string reco = e.GetText().ToLower();
			if(reco == "annuler" || reco == "annulé" || reco == "annulés" || reco == "annulées") {
				updateProcess(previousProcess, "");
				speechRecognizer.stop();
			} else if(reco == "terminé" || reco == "terminer" || reco == "terminés" || reco == "terminée" || reco == "terminées") {
				updateProcess("", "");
				speechRecognizer.stop();
				currentTargetId = 0;
			} else {
				switch (currentProcess) {
					case "distance":
						int distance = 0;
						if (int.TryParse(e.GetText(), out distance)) {
							if (distance >= 0 && distance <= 2500) {
								targets[currentTargetId].SetDistance(distance);
							}
							updateProcess(previousProcess, "");
							speechRecognizer.stop();
						}
						break;
					case "elevation":
						float elevation = 0;
						if (float.TryParse(e.GetText(), out elevation)) {
							if (elevation >= -90 && elevation <= 90) {
								targets[currentTargetId].SetElevation(elevation);
							}
							updateProcess(previousProcess, "");
							speechRecognizer.stop();
						}
						break;
					case "commentaire":
						targets[currentTargetId].SetComment(e.GetText());
						updateProcess(previousProcess, "");
						speechRecognizer.stop();
						break;
				}
			}
			
		}

		/// <summary>
		/// Engage the target of id in parameter
		/// </summary>
		/// <param name="targetId">Id of the target to engage</param>
		static void engageEnnemi(int targetId) {
			if(targets.ContainsKey(targetId)) {
				currentTargetId = targetId;
				targets[targetId].engage(true);	// Engages target
				updateProcess("cible engagée");
			}
			
		}

		/// <summary>
		/// Disengage the target of id in parameter
		/// </summary>
		/// <param name="targetId">Id of the target to disengage</param>
		static void disengageEnnemi(int targetId) {
			if (targets.ContainsKey(targetId)) {
				currentTargetId = 0;
				targets[targetId].engage(false);	// Disengage target
			}
		}

		/// <summary>
		/// PreviousProcess takes the value of currentProcess and currentProcess takes the value of the string in parameter
		/// </summary>
		/// <param name="p">New process' value</param>
		static void updateProcess(string p) {
			previousProcess = currentProcess;	// Keeps track of the previous process to get back to it with keyword "Annuler"
			currentProcess = p;
			form.SetLabelProcessText(processToUI[p]);	// Updates UI with the new process' label
		}

		/// <summary>
		/// Updates both the current and previous process with the values in parameter
		/// </summary>
		/// <param name="current">New value for the current process</param>
		/// <param name="previous">New value for the previous process</param>
		static void updateProcess(string current, string previous) {
			previousProcess = previous;
			currentProcess = current;
			form.SetLabelProcessText(processToUI[current]);	// Updates UI with the new process' label
		}

		/****************************************
		 * Speech start/stop events description *
		 ****************************************/

							/// <summary>
							/// Starts the speechRecognizer. Triggered on keywordsRecognizer stopping event.
							/// </summary>
							/// <param name="sender"></param>
							/// <param name="e"></param>
							static void OnKeywordsRecognizerStopping(object sender, EventArgs e) {
			speechRecognizer.start();
		}

		// Keyword start()
		static void OnKeywordsRecognizerStarting(object sender, EventArgs e) { }

		/// <summary>
		/// Starts the keywordRecognizer. Triggered on speechRecognizer stopping event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		static void OnSpeechRecognizerStopping(object sender, EventArgs e) {
			keywordsRecognizer.start();
		}

		// Speech start()
		static void OnSpeechRecognizerStarting(object sender, EventArgs e) { }

	}
}
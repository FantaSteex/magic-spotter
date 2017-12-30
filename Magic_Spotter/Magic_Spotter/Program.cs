﻿using System;
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


		static Dictionary<int, Target> targets = new Dictionary<int, Target>(); // Dictionary that contains every target instanciated in the application
		static SpeechRecognition speechRecognizer = new SpeechRecognition();    // SpeechRecognition engine used to recognized free text
		static KeywordsRecognition keywordsRecognizer = new KeywordsRecognition(true);  // KeywordsRecognition engine used to recognized specific keywords ("New target", "Distance" etc...)
		static Dictionary<int, Dictionary<int, double>> adjustmentsTable = Adjustments.adjustmentsTable;    // singleton instance of an adjustments table
		static Form1 form;
		static int currentTargetId = 0;
		static string currentProcess = "", previousProcess = "";

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			form = new Form1();
			/*
                10 min de démo sur ordi perso
                Exposer ce qu'on a fait, comment etc pendant 5 min
                5 max de démo
            */

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
			

			Application.Run(form);  // Starts the application²
		}

		/// <summary>
		/// Creates a new target, adds it to the list and creates its graphical interface
		/// </summary>
		/// <param name="id">Integer value of the indentifier</param>
		/// <param name="f">Reference to the graphical interface, required to add components</param>
        static void addTarget(int id) {
			if (targets.ContainsKey(id)) {
				Debug.WriteLine("------ Error : target {0} already exists", id);
			} else {
				targets.Add(id, new Target(id));    // Adds the target to the list of targets
				form.SetTargetUI(targets[id].getPanel());
				//form.getFlpMain().Controls.Add(targets[id].getPanel());    // Adds target's UI to the application's UI
			}
        }
		

		/****************************************
		 * Speech start/stop events description *
		 ****************************************/

		// Keyword stop()
		static void OnKeywordsRecognizerStopping(object sender, EventArgs e) {
			Debug.WriteLine("Keywords stopping triggered");
			speechRecognizer.start();
		}

		// Keyword start()
		static void OnKeywordsRecognizerStarting(object sender, EventArgs e) {
			Debug.WriteLine("Keywords starting triggered");
		}

		// Speech stop()
		static void OnSpeechRecognizerStopping(object sender, EventArgs e) {
			Debug.WriteLine("Speech stopping triggered");
			keywordsRecognizer.start();
		}
		
		// Speech start()
		static void OnSpeechRecognizerStarting(object sender, EventArgs e) {
			Debug.WriteLine("Speech starting triggered");
		}

		// Keyword recognized
		static void OnKeywordsRecognizerRecognized(object sender, KeywordRecognizedEventArgs e) {
			Debug.WriteLine("keyword Recognized in program : " + e.GetText());
			Debug.WriteLine("Process {0} target {1}", currentProcess, currentTargetId);
			form.SetLabelRecognitionText(e.GetText());
			int targetId = 0;
			if (currentProcess == "engager ennemi") {
				Debug.WriteLine("Engager ennemi");
				if (int.TryParse(e.GetText(), out targetId)) {
					Debug.WriteLine("Target engaged : " + targetId);
					currentTargetId = targetId;
					engageEnnemi(currentTargetId);
				} else {
					Debug.WriteLine("Nope : " + e.GetText());
					if (e.GetText() == "Elimination confirmée" && currentTargetId != 0) {
						targets[currentTargetId].eliminate();
					} else if (e.GetText() == "Terminé") {
						currentTargetId = 0;
						updateProcess("", "");
					}
				}

			} else if (int.TryParse(e.GetText(), out targetId) && currentProcess == "") {
				if(targets.ContainsKey(targetId)) {
					currentTargetId = targetId;
					updateProcess("nouvelle cible", "");
				}
			} else {
				switch (e.GetText()) {
					case "Nouvelle cible":
						if (currentTargetId == 0) {
							int newId = targets.Count() + 1;
							addTarget(newId);
							currentTargetId = newId;
							updateProcess("nouvelle cible", "");
						}
						break;
					case "Distance":
						if (currentTargetId != 0 && currentProcess == "nouvelle cible") {
							updateProcess("distance");
							keywordsRecognizer.stop();
						}
						break;
					case "Elévation":
						if (currentTargetId != 0 && currentProcess == "nouvelle cible") {
							updateProcess("elevation");
							keywordsRecognizer.stop();
						}
						break;
					case "Vitesse":
						if (currentTargetId != 0 && currentProcess == "nouvelle cible") {
							updateProcess("vitesse");
						}
						break;
					case "Statique": case "Patrouille": case "Recherche": case "Course":    // A speed is given by the user
						if (currentTargetId != 0 && currentProcess == "vitesse") {
							Debug.WriteLine("Target {0} speed : {1}", currentTargetId, targets[currentTargetId].GetSpeed());
							targets[currentTargetId].SetSpeed(new Speed(e.GetText()));
							updateProcess(previousProcess, "");
							Debug.WriteLine("Target {0} speed set : {1}", currentTargetId, targets[currentTargetId].GetSpeed());
						}
						break;
					case "Commentaire":
						if (currentTargetId != 0 && currentProcess == "nouvelle cible") {
							updateProcess("commentaire");
							keywordsRecognizer.stop();
						}
						break;
					case "Terminé":
						updateProcess("");
						currentTargetId = 0;
						break;
					case "J'engage l'ennemi":
						if (currentTargetId == 0 && currentProcess == "") {
							updateProcess("engager ennemi");
						}
						break;
				}
			}
		}
		
		// Speech recognized
		static void OnFreeSpeechRecognizerRecognized(object sender, FreeSpeechRecognizedEventArgs e) {
			Debug.WriteLine("speech Recognized in program : " + e.GetText());
			form.SetLabelRecognitionText(e.GetText());

			switch(currentProcess) {
				case "distance":
					int distance = 0;
					if (int.TryParse(e.GetText(), out distance)) {
						if (distance >= 0 && distance <= 2500) {
							Debug.WriteLine("Target {0} distance : {1}", currentTargetId, targets[currentTargetId].GetDistance());
							targets[currentTargetId].SetDistance(distance);
							Debug.WriteLine("Target {0} distance set : {1}", currentTargetId, targets[currentTargetId].GetDistance());
						}
						updateProcess(previousProcess, "");
						speechRecognizer.stop();
					}
					break;
				case "elevation":
					float elevation = 0;
					if (float.TryParse(e.GetText(), out elevation)) {
						if (elevation >= -90 && elevation <= 90) {
							Debug.WriteLine("Target {0} elevation : {1}", currentTargetId, targets[currentTargetId].GetElevation());
							targets[currentTargetId].SetElevation(elevation);
							Debug.WriteLine("Target {0} elevation set : {1}", currentTargetId, targets[currentTargetId].GetElevation());
						}
						updateProcess(previousProcess, "");
						speechRecognizer.stop();
					}
					break;
				case "commentaire":
					Debug.WriteLine("Target {0} comment : {1}", currentTargetId, targets[currentTargetId].GetComment());
					targets[currentTargetId].SetComment(e.GetText());
					Debug.WriteLine("Target {0} comment set : {1}", currentTargetId, targets[currentTargetId].GetComment());
					updateProcess(previousProcess, "");
					speechRecognizer.stop();
					break;
				case "engager ennemi":

					break;

			}
		}

		static void engageEnnemi(int targetId) {
			if(targets.ContainsKey(targetId)) {
				Debug.WriteLine("Engaging ennemi {0} : {1} {2}", targetId, targets[targetId].realDistance(), targets[targetId].GetElevation());
			} else {
				Debug.WriteLine("Can't engage ennemi {0}", targetId);
			}
			
		}

		static void updateProcess(string p) {
			previousProcess = currentProcess;
			currentProcess = p;
			form.SetLabelProcessText(p);
		}

		static void updateProcess(string current, string previous) {
			previousProcess = previous;
			currentProcess = current;
			form.SetLabelProcessText(current);
		}

	}
}
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


		static Dictionary<int, Target> targets = new Dictionary<int, Target>(); // Dictionary that contains every target instanciated in the application
		static SpeechRecognition speechRecognizer = new SpeechRecognition();    // SpeechRecognition engine used to recognized free text
		static KeywordsRecognition keywordsRecognizer = new KeywordsRecognition(true);  // KeywordsRecognition engine used to recognized specific keywords ("New target", "Distance" etc...)
		static Dictionary<int, Dictionary<int, double>> adjustmentsTable = Adjustments.adjustmentsTable;    // singleton instance of an adjustments table
		

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = new Form1();	// Graphical Interface

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
        static void addTarget(int id, Form1 f) {
			if (targets.ContainsKey(id)) {
				Debug.WriteLine("------ Error : target {0} already exists", id);
			} else {
				targets.Add(id, new Target(id));    // Adds the target to the list of targets
				f.getFlpMain().Controls.Add(targets[id].getPanel());    // Adds target's UI to the application's UI
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
			if(e.GetText() == "Terminé") {
				keywordsRecognizer.stop();
			}
		}

		// Speech recognized
		static void OnFreeSpeechRecognizerRecognized(object sender, FreeSpeechRecognizedEventArgs e) {
			Debug.WriteLine("speech Recognized in program : " + e.GetText());
			if (e.GetText() == "terminer" || e.GetText() == "Terminer" || e.GetText() == "terminé" || e.GetText() == "Terminé") {
				speechRecognizer.stop();
			}
		}


	}
}
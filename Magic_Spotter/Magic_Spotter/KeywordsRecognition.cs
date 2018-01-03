using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Spotter {
	/// <summary>
	/// This class inherits Recognition and handles a keywords recognition engine. It contains an attribute which is a list of Word and is only capable of recognizing these words. It is used for recognizing the application's keywords that will start and stop the different process : "New target", "Distance", "Shooting at the enemy" etc...
	/// </summary>
	class KeywordsRecognition : Recognition {

		// A list of Word that contains every word the class can recognize
		private Choices texts;

		// Event triggered when a keyword is recognized
		public event KeywordRecognizedEventHandler<KeywordRecognizedEventArgs> recognized = delegate { };  
		public delegate void KeywordRecognizedEventHandler<KeywordRecognizedEventArgs>(object sender, KeywordRecognizedEventArgs args);
		
		/// <summary>
		/// Instanciates an empty list of Word, sets the parameters for the speechEngine and loads the grammar.
		/// </summary>
		/// <param name="run">Boolean that determines wether the recognition will begin on instanciation or not. If True the recognition will start on instanciation.</param>
		public KeywordsRecognition(Boolean run = false) : base(run) {
			this.texts = new Choices();
			this.speechRecognitionEngine = createSpeechEngine("fr-FR");
			this.speechRecognitionEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
			loadGrammarAndCommands();
			this.speechRecognitionEngine.SetInputToDefaultAudioDevice();

			if (run)
				start();
		}

		
		
		/// <summary>
		/// Method called when a word is recognized by the speechRecognitionEngine.
		/// </summary>
		/// <param name="sender">Probably the speechEngine, but I'm not sure. Anyway, it doesn't matter.</param>
		/// <param name="e">SpeechRecognizedEventArgs that will contain the recognized text</param>
		private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e) {
			// Found on https://msdn.microsoft.com/fr-fr/library/system.speech.recognition.speechrecognizer.speechrecognized(v=vs.110).aspx
			//Debug.WriteLine("Keyword recognized : " + e.Result.Text);
			recognized(this, new KeywordRecognizedEventArgs(e.Result.Text));
			
		}
		

		/// <summary>
		/// Adds the keywords to the grammar.
		/// </summary>
		private void loadGrammarAndCommands() {
			// Loads the keywords for the grammar
			try {
				texts.Add("Nouvelle cible");
				texts.Add("Distance");
				texts.Add("Elévation");
				texts.Add("Vitesse");
				texts.Add("Commentaire");
				texts.Add("Annuler");
				texts.Add("Terminé");
				texts.Add("J'engage l'ennemi");
				texts.Add("Statique");
				texts.Add("Recherche");
				texts.Add("Patrouille");
				texts.Add("Course");
				texts.Add("Distance");
				texts.Add("Elimination confirmée");
				texts.Add("Modifier");

				// Allows the keywords grammar to recognize integers from 1 to 100. Easier to handle and provides a better recognition quality
				for (int i = 1; i <= 100; i++)
					texts.Add(i.ToString());

				Grammar wordsList = new Grammar(new GrammarBuilder(texts));
				wordsList.Name = "Dictation par défaut";
				wordsList.Enabled = true;
				speechRecognitionEngine.LoadGrammar(wordsList);
			} catch (Exception ex) {
				throw ex;
			}
		}

	}

	/// <summary>
	/// New type of event that will allow us to pass recognized text (here the string text) to other methods that will handle the event (e.g : Program.OnKeywordsRecognizerRecognized will be able to get the recognized text
	/// </summary>
	public class KeywordRecognizedEventArgs : EventArgs {

		private readonly string text;

		public KeywordRecognizedEventArgs(string t) {
			this.text = t;
		}

		public string GetText() { return this.text;}
	}
	

}

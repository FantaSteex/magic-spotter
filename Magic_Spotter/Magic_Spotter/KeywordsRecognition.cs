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
		private List<Word> words;

		/// <summary>
		/// Instanciates an empty list of Word, sets the parameters for the speechEngine and loads the grammar.
		/// </summary>
		/// <param name="run">Boolean that determines wether the recognition will begin on instanciation or not. If True the recognition will start on instanciation.</param>
		public KeywordsRecognition(Boolean run = false) : base(run) {
			this.words = new List<Word>();
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
			if (e.Result.Text == "Elévation") {
				Debug.WriteLine("Stopping KR : " + e.Result.Text);
				stop();
			}
			Debug.WriteLine("Keyword recognized : " + e.Result.Text);
		}

		/// <summary>
		/// Adds the keywords to the grammar.
		/// </summary>
		private void loadGrammarAndCommands() {
			Debug.WriteLine("Keywords loadGrammar");
			try {
				Choices texts = new Choices();
				words.Add(new Word("Distance"));
				words.Add(new Word("Mètre"));
				words.Add(new Word("Elévation"));
				words.Add(new Word("1"));
				words.Add(new Word("866"));
				words.Add(new Word("2222"));
				words.Add(new Word("Nouvelle cible"));
				texts.Add("Distance");
				texts.Add("Mètre");
				texts.Add("Elévation");
				texts.Add("1");
				texts.Add("866");
				texts.Add("2222");
				texts.Add("Nouvelle cible");

				Grammar wordsList = new Grammar(new GrammarBuilder(texts));
				wordsList.Name = "Dictation par défaut";
				wordsList.Enabled = true;
				speechRecognitionEngine.LoadGrammar(wordsList);
			} catch (Exception ex) {
				throw ex;
			}
		}

	}
}

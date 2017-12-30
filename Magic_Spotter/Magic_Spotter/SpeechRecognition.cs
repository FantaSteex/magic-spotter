using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.AudioFormat;
using System.Speech.Recognition.SrgsGrammar;
//using System.Speech.Recognition.DictationGrammar;
using System.Speech.Synthesis;
using System.Speech.Synthesis.TtsEngine;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

// https://www.codeproject.com/Articles/380027/Csharp-Speech-to-Text



namespace Magic_Spotter {
	/// <summary>
	/// This class handles a continuous speech recognition engine working in french language. Used for numbers (distance, elevation) and target's comments
	/// </summary>
	class SpeechRecognition : Recognition {

		private static List<string> antiDictionary = new List<string>() {
			"le",
			"la",
			"les",
			"de",
			"des",
			"à",
			"a",
			"en",
			"si",
			"du",
			"au"
		};  // Antidictionary that contains every value we want to remove from a string to clean it and keep only important words

		public event FreeSpeechRecognizedEventHandler<FreeSpeechRecognizedEventArgs> recognized = delegate { };  // Event triggered when a keyword is recognized

		public delegate void FreeSpeechRecognizedEventHandler<FreeSpeechRecognizedEventArgs>(object sender, FreeSpeechRecognizedEventArgs args);

		/// <summary>
		/// Instanciates an empty list of Word, sets the parameters for the speechEngine and loads the grammar.
		/// </summary>
		/// <param name="run">Boolean that determines wether the recognition will begin on instanciation or not. If True the recognition will start on instanciation.</param>
		public SpeechRecognition(Boolean run = false) : base(run) {
			this.speechRecognitionEngine = createSpeechEngine("fr-FR");
			this.speechRecognitionEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
			loadGrammarAndCommands();
			this.speechRecognitionEngine.SetInputToDefaultAudioDevice();

			if (run)
				start();
		}

		/// <summary>
		/// Method called when a word is recognized by the keywordsRecognitionEngine.
		/// </summary>
		/// <param name="sender">Probably the keywordsEngine, but I'm not sure. Anyway, it doesn't matter.</param>
		/// <param name="e">KeywordsRecognizedEventArgs that will contain the recognized text</param>
		private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e) {
			//Debug.WriteLine("Speech recognized : " + e.Result.Text);
			recognized(this, new FreeSpeechRecognizedEventArgs(e.Result.Text));
		}

		/// <summary>
		/// Initializes a DictationGrammar that will allow the user to dictate free text to the application
		/// </summary>
		private void loadGrammarAndCommands() {
			//Debug.WriteLine("Speech loadGrammar");
			try {
				DictationGrammar wordsList = new DictationGrammar();
				wordsList.Name = "Dictation par défaut";
				wordsList.Enabled = true;
				speechRecognitionEngine.LoadGrammar(wordsList);
			} catch (Exception ex) {
				throw ex;
			}
		}
		
		/// <summary>
		/// Cleans the string using an antidictionary : every word contained in the antidictionary will be removed from the string
		/// </summary>
		/// <param name="str">String you want to clean</param>
		/// <returns>String cleaned</returns>
		protected static string strCleaner(string str) {
			str = strKeepOnlyText(str);
			string[] splitString = str.Split(' ');
			//Debug.WriteLine("Split string : " + str);
			foreach (string s in splitString) {
				//Debug.WriteLine(s);
			}
			return str;
		}
	}

	public class FreeSpeechRecognizedEventArgs : EventArgs {

		private readonly string text;

		public FreeSpeechRecognizedEventArgs(string t) {
			this.text = t;
		}

		public string GetText() { return this.text; }
	}
}

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

namespace Magic_Spotter {
	/// <summary>
	/// Mother class of the speech and keywords recognition
	/// </summary>
	class Recognition {

		protected SpeechRecognitionEngine speechRecognitionEngine { get; set; }		// Engin that makes the vocal recognition
		protected Boolean running { get; set; }	// Determines wether the recognition is running or not
		public event EventHandler stopping = delegate { };	// Event triggered when recognition is stopped
		public event EventHandler starting = delegate { };	// Event triggered when recognition starts

		public Recognition(Boolean run = false) {
			this.running = run;
		}

		/// <summary>
		/// Starts the recognition, sets the running value to True and raises the starting Event
		/// </summary>
		public void start() {
			this.speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
			this.running = true;
			this.starting(this, new EventArgs());
		}

		/// <summary>
		/// Stops the recognition, sets the running value to False and raises the stopping Event
		/// </summary>
		public void stop() {
			this.speechRecognitionEngine.RecognizeAsyncStop();
			this.running = false;
			this.stopping(this, new EventArgs());
		}

		/// <summary>
		/// Creates the speech engine according the the language in parameters
		/// </summary>
		/// <param name="preferredCulture">String representing a language ("fr-FR", "en-EN", "de-DE"...)</param>
		/// <returns>SpeechRecognitionEngine</returns>
		protected SpeechRecognitionEngine createSpeechEngine(string preferredCulture) {
			foreach (RecognizerInfo config in SpeechRecognitionEngine.InstalledRecognizers()) {
				if (config.Culture.ToString() == preferredCulture) {
					this.speechRecognitionEngine = new SpeechRecognitionEngine(config);
					break;
				}
			}

			// if the desired culture is not installed, then load default
			if (speechRecognitionEngine == null) {
				this.speechRecognitionEngine = new SpeechRecognitionEngine();
			}

			return speechRecognitionEngine;
		}


		/// <summary>
		/// Cleans the string removing its punctuation
		/// </summary>
		/// <param name="str">String to clean</param>
		/// <returns>String cleaned</returns>
		protected static string strKeepOnlyText(string str) {
			char[] charsToRemove = new char[] { ',', '.', ';' };
			foreach (var c in charsToRemove) {
				str = str.Replace(c.ToString(), "");
			}
			return str;
		}
	}
}

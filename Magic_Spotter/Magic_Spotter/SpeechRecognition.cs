using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.AudioFormat;
using System.Speech.Recognition.SrgsGrammar;
using System.Speech.Synthesis;
using System.Speech.Synthesis.TtsEngine;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

// https://www.codeproject.com/Articles/380027/Csharp-Speech-to-Text

namespace Magic_Spotter { 
    class SpeechRecognition {

		private SpeechRecognitionEngine speechRecognitionEngine { get; set; }
		private List<Word> words;

		public SpeechRecognition() {
			this.words = new List<Word>();
			this.speechRecognitionEngine = createSpeechEngine("fr-FR");
			//this.speechRecognitionEngine.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>();
			this.speechRecognitionEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

			loadGrammarAndCommands();
			this.speechRecognitionEngine.SetInputToDefaultAudioDevice();
			this.speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
		}



		// https://msdn.microsoft.com/fr-fr/library/system.speech.recognition.speechrecognizer.speechrecognized(v=vs.110).aspx
		static void recognizer_SpeechRecognized(object sender,SpeechRecognizedEventArgs e) {
			Debug.WriteLine("Speech recognized : " + e.Result.Text);
		}



		private SpeechRecognitionEngine createSpeechEngine(string preferredCulture) {
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

		private void loadGrammarAndCommands() {
			try {
				Choices texts = new Choices();
				words.Add(new Word("Distance"));
				words.Add(new Word("Mètre"));
				words.Add(new Word("Elévation"));
				words.Add(new Word("Engager"));
				words.Add(new Word("Nouvelle cible"));
				texts.Add("Distance");
				texts.Add("Mètre");
				texts.Add("Elévation");
				texts.Add("Engager");
				texts.Add("Nouvelle cible");
				Grammar wordsList = new Grammar(new GrammarBuilder(texts));
				speechRecognitionEngine.LoadGrammar(wordsList);
			} catch (Exception ex) {
				throw ex;
			}
		}

		private string getKnownTextOrExecute(string command) {
			try {
				var cmd = words.Where(c => c.text == command).First();

				return cmd.text;
			} catch (Exception) {
				return command;
			}
		}

	}
}

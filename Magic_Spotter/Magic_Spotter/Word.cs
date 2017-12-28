using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Spotter {
	/// <summary>
	/// Represents a word. Was usefull at first thought, but know seems kinda useless.
	/// </summary>
	class Word {

		public string text { get; set; }          // the word to be recognized by the engine

		public Word(string text) {
			this.text = text;
		}
		
	}
}

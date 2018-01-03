using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Spotter {
	/// <summary>
	/// Represents a speed. To a name corresponds a specific speed value
	/// </summary>
    class Speed {

        private string name { get; set; }	// Name of the speed ("Statique", "Recherche", "Patrouille" or "Course")
        private double speed { get; set; }	// Value (in km/h) linked to the speed

        public Speed(string name) {
            adjustSpeed(name);
        }

		/// <summary>
		/// Updates the value of the speed according to the name in parameter
		/// </summary>
		/// <param name="name">String corresponding to a speed name (static, search, patrol or run)</param>
        public void adjustSpeed(string name) {
			// N.B : For now, the speed is not used in the application because the horizontal adjustments formula depending of target's speed isn't known and implemented by the developper. Will be added in future versions.
            this.name = name;
            switch (name.ToLower()) {
                case "Statique":
                    this.speed = 0;
                    break;
                case "Recherche":
                    this.speed = 3.5;
                    break;
                case "Patrouille":
                    this.speed = 8.0;
                    break;
                case "Course":
                    this.speed = 13.5;
                    break;
                default:
                    this.speed = 0;
                    break;
            }
        }

        public double GetValue() {
            return this.speed;
        }

        public string GetName() {
            return this.name;
        }
    }
}

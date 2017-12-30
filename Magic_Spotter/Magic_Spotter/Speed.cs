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
        private string name { get; set; }
        private double speed { get; set; }

        public Speed(string name) {
            adjustSpeed(name);
        }

		/// <summary>
		/// Updates the value of the speed according to the name in parameter
		/// </summary>
		/// <param name="name">String corresponding to a speed name (static, search, patrol or run)</param>
        public void adjustSpeed(string name) {
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

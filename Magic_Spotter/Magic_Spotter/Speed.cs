using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Spotter {
    class Speed {
        private string name { get; set; }
        private double speed { get; set; }

        public Speed(string name) {
            adjustSpeed(name);
        }

        public void adjustSpeed(string name) {
            this.name = name;
            switch (name.ToLower()) {
                case "static":
                    this.speed = 0;
                    break;
                case "search":
                    this.speed = 3.5;
                    break;
                case "patrol":
                    this.speed = 8.0;
                    break;
                case "run":
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

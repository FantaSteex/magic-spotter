using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Spotter {
	/// <summary>
	/// Represents the zeroing for a given distance. 
	/// </summary>
    class Zeroing {
        private int lower { get; set; }	// Lower value of the zero 
        private int upper { get; set; }	// Upper value of the zero
        
        public Zeroing(int distance) {
			zero(distance);
        }


		/// <summary>
		/// Sets the lower and upper zero. If the distance is 850, lower zero will be 800 and upper 900
		/// </summary>
		/// <param name="distance"></param>
		public void zero(int distance) {
			int round = (int)((distance + 50) / 100) * 100;

			/* 
             * distance = 1222, lower = 1200, upper = 1300 
             * distance = 1200, lower = 1200, upper = 1300
             */
			if (round < distance) {
				this.lower = round;
				this.upper = round + 100;
			} else if (round > distance) {
				this.lower = round - 100;
				this.upper = round;
			} else {    // ==
				this.upper = round;
				this.lower = round;
			}
		}

        /// <summary>
        /// Calculates the horizontal adjustement depending on distance and speed. 
        /// </summary>
        /// <param name="distance">Integer representing the distance to the target in meters (between 0 and 2500)</param>
        /// <param name="speed">Instance of the class Speed that represents the speed of the target with two attributes : name and value (ex : </param>
        /// <returns></returns>
        public double calculateX(bool lower, int distance, Speed speed) {
            // TODO facultatif : calcul en fonction de la distance, du temps de vol et de la vitesse de la cible
            return 0;
        }

        public double calculateY(bool lower, int distance) {
            /*
             * dist 560 : lower 500 upper 600. Calcul entre 500+50 et 500+100, puis entre 600+0 et 600-50
             * dist 650 : lower 600 upper 700. 600+50 et 700-50
             * dist 730 : lower 700 upper 800. Calcul entre 700+0 et 700+50, puis entre 800-50 et 800-100
             * dist 800 : lower 800 upper 800. 800+0 et 800+0
             * 
             * 
             * 560 : 550 + 10
             * 10 = 0.2% de 50
             * 
             * 2050 -1.5   et 2100 -2.75
             * 
             * 
             * 
             * 2075 -2.125
             * 
             * 550 -0.7
             * 600 -1
             */


            // TODO : calcul en fonction de la distance
            /*
                Différence entre le zéro et la distance
                Récupérer les données dans l'objet de stockage des ajustements
                accroissement -> cf McKayTheBoss 
            */
            if (lower) {

            } else {

            }
            return 0;
        }

		public int GetLower() {
			return this.lower;
		}

		public int GetUpper() {
			return this.upper;
		}
	}
}

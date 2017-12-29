using System;
using System.Collections.Generic;
using System.Diagnostics;
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

			if(distance < 300 || distance > 2400) {
				this.upper = distance;
				this.lower = distance;
			} else {
				// distance = 1222, lower = 1200, upper = 1300 
				// distance = 1200, lower = 1200, upper = 1300
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
		}

        /// <summary>
        /// Calculates the horizontal adjustement depending on distance and speed. 
        /// </summary>
        /// <param name="distance">Integer representing the distance to the target in meters (between 0 and 2500)</param>
        /// <param name="speed">Instance of the class Speed that represents the speed of the target with two attributes : name and value (ex : </param>
        /// <returns></returns>
        public double calculateX(bool useLowerZero, int distance, Speed speed) {
            // TODO facultatif : calcul en fonction de la distance, du temps de vol et de la vitesse de la cible
            return 0;
        }

        public double calculateY(bool useLowerZero, int distance) {
			Debug.WriteLine("calculating Y : {0} {1}", useLowerZero, distance);
			/*
				distance = 1268, lower = 1200, upper = 1300
				1200 +50 et 1200 + 100
					Diff = 1268 - 1250 = 18
					Accroissement tableau : [1200][100] - [1200][50] = -1.7 - -0.9 = -0.8
					Accroissement distance : règle de 3 = -0.8 * 18 / 50 = -0.288
					Ajustement : -0.9 + -0.288 = -1.188

				distance = 1228, lower = 1200, upper = 1300
				1200 +0 et 1200 + 50
					Diff = 1228 - 1200 = 28
					Accroissement tableau : [1200][50] - [1200][0] = -0.9 - -0.2 = -0.7
					Accroissement distance : règle de 3 = -0.7 * 28 / 50 = -0.392
					Ajustement : -0.2 + -0.392 = -0.592

				distance = 1268, lower = 1200, upper = 1300
				1300 - 0 et 1300 - 50
					Diff = 1300 - 1268 = 32
					Accroissement tableau : [1300][50] - [1300][0] = 0.5 - -0.2 = 0.7
					Accroissement distance : règle de 3 = 0.7 * 32 / 50 = 0.448
					Ajustement : -0.2 + 0.448 = 0.248

				distance = 1238, lower = 1200, upper = 1300
				1300 - 50 et 1300 - 100
					Diff = 1250 - 1238 = 12
					Accroissement tableau : [1300][100] - [1300][50] = 1.5 - 0.5 = 1
					Accroissement distance : règle de 3 = 1 * 12 / 50 = 0.24
					Ajustement : 0.5 + 0.24 = 0.74
            */

			int difference = 0;
			double arrayIncrease = 0,
				distanceIncrease = 0,
				adjustment = 0;

			if (useLowerZero) {
				Debug.WriteLine("Lower : {0}", this.lower);
				if (distance - this.lower + 50 > 0) {    // Between lower+50 and lower+100
					difference = distance - this.lower - 50;
					arrayIncrease = Adjustments.adjustmentsTable[this.lower][100] - Adjustments.adjustmentsTable[this.lower][50];
					distanceIncrease = arrayIncrease * difference / 50;
					adjustment = Adjustments.adjustmentsTable[this.lower][50] + distanceIncrease;
				} else {    // Between lower and lower+50
					difference = distance - this.lower;
					arrayIncrease = Adjustments.adjustmentsTable[this.lower][50] - Adjustments.adjustmentsTable[this.lower][0];
					distanceIncrease = arrayIncrease * difference / 50;
					adjustment = Adjustments.adjustmentsTable[this.lower][0] + distanceIncrease;
				}
				Debug.WriteLine("Difference : {0}, arrayIncrease : {1}, distanceIncrease : {2}, adjustment : {3}", difference, arrayIncrease, distanceIncrease, adjustment);
			} else {
				Debug.WriteLine("Upper : {0}", this.upper);
				if (this.upper - 50 - distance > 0) {    // Between upper-50 and upper-100
					difference = this.upper - 50 - distance;
					arrayIncrease = Adjustments.adjustmentsTable[this.upper][-100] - Adjustments.adjustmentsTable[this.upper][-50];
					distanceIncrease = arrayIncrease * difference / 50;
					adjustment = Adjustments.adjustmentsTable[this.upper][-50] + distanceIncrease;
				} else {    // Between upper and upper-50
					difference = this.upper - distance;
					arrayIncrease = Adjustments.adjustmentsTable[this.upper][-50] - Adjustments.adjustmentsTable[this.upper][0];
					distanceIncrease = arrayIncrease * difference / 50;
					adjustment = Adjustments.adjustmentsTable[this.upper][0] + distanceIncrease;
				}
				Debug.WriteLine("Difference : {0}, arrayIncrease : {1}, distanceIncrease : {2}, adjustment : {3}", difference, arrayIncrease, distanceIncrease, adjustment);
			}

            return adjustment;
        }

		

		public int GetLower() {
			return this.lower;
		}

		public int GetUpper() {
			return this.upper;
		}
	}
}

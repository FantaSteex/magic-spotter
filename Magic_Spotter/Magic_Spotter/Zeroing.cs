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
        private int distance { get; set; }	// Distance we build the zeroing around
		private Speed speed { get; set; }	// Speed we build the zeroing around

        public Zeroing(int distance, Speed speed) {
			this.distance = distance;
			this.speed = speed;
			zero(distance);
        }


		/// <summary>
		/// Sets the lower and upper zero. If the distance is 850, lower zero will be 800 and upper 900
		/// </summary>
		/// <param name="distance"></param>
		public void zero(int distance) {
			int round = (int)((distance + 50) / 100) * 100;

			if (distance < 300) {
				this.upper = 300;
				this.lower = 300;
			} else if (distance > 2400) {
				this.upper = 2400;
				this.lower = 2400;
			} else {
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
		/// Calculates the horizontal adjustment depending on speed and distance
		/// </summary>
		/// <param name="useLowerZero"></param>
		/// <returns></returns>
        public double calculateX(bool useLowerZero) {
            // TODO : on future versions, create and implement the formula for horizontal adjustment depending on target's speed
            return 0;
        }

		/// <summary>
		/// Calculates the vertical adjustement depending on distance
		/// </summary>
		/// <param name="useLowerZero">Determines wether we calculate according to the lower zero (True) or the upper one (False)</param>
		/// <returns></returns>
        public double calculateY(bool useLowerZero) {

			/*
				Bellow are 4 example for a better understanding of the algorithm

				distance = 1268, lower = 1200, upper = 1300
				Between 1200 +50 and 1200 + 100
					Difference = 1268 - 1250 = 18
					arrayIncrease : [1200][100] - [1200][50] = -1.7 - -0.9 = -0.8
					distanceIncrease : -0.8 * 18 / 50 = -0.288
					Ajustement : -0.9 + -0.288 = -1.188

				distance = 1228, lower = 1200, upper = 1300
				Between 1200 +0 et 1200 + 50
					Diff = 1228 - 1200 = 28
					arrayIncrease : [1200][50] - [1200][0] = -0.9 - -0.2 = -0.7
					distanceIncrease : -0.7 * 28 / 50 = -0.392
					Ajustement : -0.2 + -0.392 = -0.592

				distance = 1268, lower = 1200, upper = 1300
				Between 1300 - 0 et 1300 - 50
					Diff = 1300 - 1268 = 32
					arrayIncrease : [1300][50] - [1300][0] = 0.5 - -0.2 = 0.7
					distanceIncrease : 0.7 * 32 / 50 = 0.448
					Ajustement : -0.2 + 0.448 = 0.248

				distance = 1238, lower = 1200, upper = 1300
				Between 1300 - 50 et 1300 - 100
					Diff = 1250 - 1238 = 12
					arrayIncrease : [1300][100] - [1300][50] = 1.5 - 0.5 = 1
					distanceIncrease : 1 * 12 / 50 = 0.24
					Ajustement : 0.5 + 0.24 = 0.74
            */

			int difference = 0;		// Difference between the distance and the zeroing value
			double arrayIncrease = 0,	// Increasing value represented by the array
				distanceIncrease = 0,	// Increasing value represented by the distance
				adjustment = 0;	// Value of the vertical adjustment

			if (useLowerZero) {
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
			} else {
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magic_Spotter {
	/// <summary>
	/// Target with parameters such as distance, elevation, speed... It contains a TargetUI that is its graphical interface
	/// </summary>
    class Target {

        private int id { get; set; }	// Indentifier of the target, from 1 to n
        private bool alive { get; set; }	// Determines if the target is alive or not
        private int distance { get; set; }	// Distance between the user and the target
        private float elevation { get; set; }	// Difference of elevation between the user and the target : an angle going from -90.0 to 90.0
        private Speed speed { get; set; }	// Movement speed of the target
        private string comment { get; set; }	// Optional comment that allows the user to quickly identify the target
        private Zeroing zeroing { get; set; }	// Zeroing used to shoot at the target
        private TargetUI targetInterface { get; set; }	// Graphical interface's part representing the target on the application

        /****************
	     * Constructors *
	     ****************/

        public Target(int id) {
            this.id = id;
            this.alive = true;
            this.distance = 500;
            this.elevation = 0;
            this.speed = new Speed("Statique");
            this.comment = "";
            this.zeroing = new Zeroing(500, this.speed);
            this.targetInterface = new TargetUI(this);
        }


        /***********
         * Methods *
         ***********/

        /// <summary>
        /// Calculates the real distance to the target, according to measured distance and measured elevation.
        /// </summary>
        /// <returns>Returns an integer</returns>
        public int realDistance() {
			int realDistance = (int)(this.distance * Math.Cos(this.elevation * Math.PI / 180));
			return realDistance;
        }

        /// <summary>
        /// Checks if target is alive
        /// </summary>
        /// <returns>Returns a boolean</returns>
        public bool isAlive() {
            return this.alive;
        }

        /// <summary>
        /// Eliminates the target, so that isAlive() will return false
        /// </summary>
        public void eliminate() {
            this.alive = false;
			this.targetInterface.SetEliminated(true);
			engage(false);
        }

		/// <summary>
		/// Engages the target by coloring its zeroing labels in red (or black if we disengage)
		/// </summary>
		/// <param name="engaging">True for engaging (colors labels in red), false for disengaging (colors labels in black)</param>
		public void engage(bool engaging) {
			if(engaging)
				this.targetInterface.SetZeroingColor(System.Drawing.Color.Red);
			else
				this.targetInterface.SetZeroingColor(System.Drawing.Color.Black);
		}

		public void highlight() {

		}

        /***********
         * Getters *
         ***********/

        public int GetId() { return this.id; }
        public int GetDistance() { return this.distance; }
        public float GetElevation() { return this.elevation; }
        public Speed GetSpeed() { return this.speed; }
        public string GetComment() { return this.comment; }
        public Zeroing getZeroing() { return this.zeroing; }
        public Panel getPanel() { return this.targetInterface.getPanel(); }

        /***********
         * Setters *
         ***********/

        public void SetDistance(int distance) {
            this.distance = distance;
			this.zeroing = new Zeroing(realDistance(), this.speed);
			this.targetInterface.SetDistance(distance);
			this.targetInterface.SetRealDistance(realDistance());
			this.targetInterface.SetZeroing(this.zeroing);
		}

        public void SetElevation(float elevation) {
            this.elevation = elevation;
			this.targetInterface.SetElevation(elevation);
			this.targetInterface.SetRealDistance(realDistance());
			this.zeroing = new Zeroing(realDistance(), this.speed);
			this.targetInterface.SetZeroing(this.zeroing);
		}

        public void SetSpeed(Speed speed) {
            this.speed = speed;
			this.targetInterface.SetSpeed(speed);
        }

        public void SetComment(string comment) {
            this.comment = comment;
			this.targetInterface.SetComment(comment);
        }

        public void SetZeroing(Zeroing zeroing) {
            this.zeroing = zeroing;
        }


    }
}

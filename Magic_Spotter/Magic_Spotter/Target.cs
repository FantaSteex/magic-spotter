using System;
using System.Collections.Generic;
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
            this.distance = 0;
            this.elevation = 0;
            this.speed = new Speed("static");
            this.comment = "";
            this.zeroing = new Zeroing(0);
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
            return (int)(this.distance * Math.Cos(this.elevation * Math.PI / 180));
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
        }

        public void SetElevation(float elevation) {
            this.elevation = elevation;
        }

        public void SetSpeed(Speed speed) {
            this.speed = speed;
        }

        public void SetComment(string comment) {
            this.comment = comment;
        }

        public void SetZeroing(Zeroing zeroing) {
            this.zeroing = zeroing;
        }


    }
}

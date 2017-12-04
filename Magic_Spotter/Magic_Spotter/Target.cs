using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Spotter {
    class Target {

        private int id { get; set; }
        private bool alive { get; set; }
        private int distance { get; set; }
        private float elevation { get; set; }
        private Speed speed { get; set; }
        private string comment { get; set; }
        private Zeroing zeroing { get; set; }

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
            this.zeroing = new Zeroing(0);   // TODO : modify according to zeroing constructor
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

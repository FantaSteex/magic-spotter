using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magic_Spotter {
    class Target {

        private int id { get; set; }
        private bool alive { get; set; }
        private int distance { get; set; }
        private float elevation { get; set; }
        private Speed speed { get; set; }
        private string comment { get; set; }
        private Zeroing zeroing { get; set; }
        private TargetUI targetInterface { get; set; }

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
            this.targetInterface = new TargetUI(this.id);
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

        /// <summary>
        /// Generates the User Interface of the target : panel, splitcontainer etc...
        /// </summary>
        public void generateUI() {
            Form1.panels["pnlTarget" + this.id] = new System.Windows.Forms.Panel();
            Form1.panels["pnlTarget" + this.id].Controls.Add(new System.Windows.Forms.SplitContainer());/*
            spcZero1 = new System.Windows.Forms.SplitContainer();
            lblZero1LowY = new System.Windows.Forms.Label();
            lblZero1LowX = new System.Windows.Forms.Label();
            lblZeroLow1 = new System.Windows.Forms.Label();
            lblZero1UpY = new System.Windows.Forms.Label();
            lblZero1UpX = new System.Windows.Forms.Label();
            lblZeroUp1 = new System.Windows.Forms.Label();
            txtComment1 = new System.Windows.Forms.TextBox();
            txtSpeed1 = new System.Windows.Forms.TextBox();
            txtRealDistance1 = new System.Windows.Forms.TextBox();
            txtElevation1 = new System.Windows.Forms.TextBox();
            txtDistance1 = new System.Windows.Forms.TextBox();
            lblZero1 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            lblElevation1 = new System.Windows.Forms.Label();
            lblComment1 = new System.Windows.Forms.Label();
            lblSpeed1 = new System.Windows.Forms.Label();
            lblRealDistance1 = new System.Windows.Forms.Label();
            lblName1 = new System.Windows.Forms.Label();*/
        }

        // TODO : Method return target Panel 

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

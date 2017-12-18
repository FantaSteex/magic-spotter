using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magic_Spotter {
    class TargetUI {

        private Panel panel { get; set; }
        private SplitContainer spcZero { get; set; }
        private Label lblZeroLowX { get; set; }
        private Label lblZeroLowY { get; set; }
        private Label lblZeroLow { get; set; }
        private Label lblZeroUpX { get; set; }
        private Label lblZeroUpY { get; set; }
        private Label lblZeroUp { get; set; }
        private TextBox txtComment { get; set; }
        private TextBox txtSpeed { get; set; }
        private TextBox txtRealDistance { get; set; }
        private TextBox txtElevation { get; set; }
        private TextBox txtDistance { get; set; }
        private Label lblZero { get; set; }
        private Label lblElevation { get; set; }
        private Label lblComment { get; set; }
        private Label lblSpeed { get; set; }
        private Label lblRealDistance { get; set; }
        private Label lblDistance { get; set; }
        private Label lblName { get; set; }


        public TargetUI(int id) {
            this.panel = new Panel();
            this.spcZero = new SplitContainer();
            this.lblZeroLow = new Label();
            this.lblZeroLowY = new Label();
            this.lblZeroLowX = new Label();
            this.lblZeroUpY = new Label();
            this.lblZeroUpX = new Label();
            this.lblZeroUp = new Label();

            this.txtComment = new TextBox();
            this.txtSpeed = new TextBox();
            this.txtRealDistance = new TextBox();
            this.txtElevation = new TextBox();
            this.txtDistance = new TextBox();

            this.lblZero = new Label();
            this.lblElevation = new Label();
            this.lblComment = new Label();
            this.lblSpeed = new Label();
            this.lblRealDistance = new Label();
            this.lblDistance = new Label();
            this.lblName = new Label();
            
            // Panel
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.spcZero);
            this.panel.Controls.Add(this.txtComment);
            this.panel.Controls.Add(this.txtSpeed);
            this.panel.Controls.Add(this.txtRealDistance);
            this.panel.Controls.Add(this.txtElevation);
            this.panel.Controls.Add(this.txtDistance);
            this.panel.Controls.Add(this.lblZero);
            this.panel.Controls.Add(this.lblElevation);
            this.panel.Controls.Add(this.lblComment);
            this.panel.Controls.Add(this.lblSpeed);
            this.panel.Controls.Add(this.lblRealDistance);
            this.panel.Controls.Add(this.lblDistance);
            this.panel.Controls.Add(this.lblName);
            this.panel.Location = new System.Drawing.Point(3, 3);
            this.panel.Name = "panel" + id;
            this.panel.Size = new System.Drawing.Size(730, 118);
            this.panel.TabIndex = 0;

            // SpcZero
            this.spcZero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spcZero.Location = new System.Drawing.Point(350, 45);
            this.spcZero.Name = "spcZero" + id;

            // spcZero1.Panel1            
            this.spcZero.Panel1.Controls.Add(this.lblZeroLowY);
            this.spcZero.Panel1.Controls.Add(this.lblZeroLowX);
            this.spcZero.Panel1.Controls.Add(this.lblZeroLow);
            
            // spcZero1.Panel2
            this.spcZero.Panel2.Controls.Add(this.lblZeroUpY);
            this.spcZero.Panel2.Controls.Add(this.lblZeroUpX);
            this.spcZero.Panel2.Controls.Add(this.lblZeroUp);
            this.spcZero.Size = new System.Drawing.Size(360, 68);
            this.spcZero.SplitterDistance = 180;
            this.spcZero.TabIndex = 16;
            // 
            // lblZeroLow1
            // 
            this.lblZeroLow.AutoSize = true;
            this.lblZeroLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroLow.Location = new System.Drawing.Point(40, 0);
            this.lblZeroLow.Name = "lblZeroLow" + id;
            this.lblZeroLow.Size = new System.Drawing.Size(70, 24);
            this.lblZeroLow.TabIndex = 14;
            this.lblZeroLow.Text = "2300 m";
            // 
            // lblZero1LowX
            // 
            this.lblZeroLowX.AutoSize = true;
            this.lblZeroLowX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroLowX.ForeColor = System.Drawing.Color.Red;
            this.lblZeroLowX.Location = new System.Drawing.Point(5, 29);
            this.lblZeroLowX.Name = "lblZero" + id + "LowX";
            this.lblZeroLowX.Size = new System.Drawing.Size(70, 24);
            this.lblZeroLowX.TabIndex = 15;
            this.lblZeroLowX.Text = "X : 0";
            // lblZero1LowY
            // 
            this.lblZeroLowY.AutoSize = true;
            this.lblZeroLowY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroLowY.ForeColor = System.Drawing.Color.Red;
            this.lblZeroLowY.Location = new System.Drawing.Point(80, 29);
            this.lblZeroLowY.Name = "lblZero" + id + "LowY";
            this.lblZeroLowY.Size = new System.Drawing.Size(70, 24);
            this.lblZeroLowY.TabIndex = 16;
            this.lblZeroLowY.Text = "Y : -0,73";
            // 
            // lblZeroUp1
            // 
            this.lblZeroUp.AutoSize = true;
            this.lblZeroUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroUp.Location = new System.Drawing.Point(40, 0);
            this.lblZeroUp.Name = "lblZeroUp" + id;
            this.lblZeroUp.Size = new System.Drawing.Size(70, 24);
            this.lblZeroUp.TabIndex = 15;
            this.lblZeroUp.Text = "2400 m";
            // 
            // lblZero1UpX
            // 
            this.lblZeroUpX.AutoSize = true;
            this.lblZeroUpX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroUpX.ForeColor = System.Drawing.Color.Red;
            this.lblZeroUpX.Location = new System.Drawing.Point(5, 29);
            this.lblZeroUpX.Name = "lblZero" + id + "UpX";
            this.lblZeroUpX.Size = new System.Drawing.Size(70, 24);
            this.lblZeroUpX.TabIndex = 17;
            this.lblZeroUpX.Text = "X : 0";
            // 
            // lblZero1UpY
            // 
            this.lblZeroUpY.AutoSize = true;
            this.lblZeroUpY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroUpY.ForeColor = System.Drawing.Color.Red;
            this.lblZeroUpY.Location = new System.Drawing.Point(80, 29);
            this.lblZeroUpY.Name = "lblZero" + id + "UpY";
            this.lblZeroUpY.Size = new System.Drawing.Size(70, 24);
            this.lblZeroUpY.TabIndex = 18;
            this.lblZeroUpY.Text = "Y : 1,58";
            // 
            // txtComment1
            // 
            this.txtComment.Location = new System.Drawing.Point(167, 62);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment" + id;
            this.txtComment.Size = new System.Drawing.Size(173, 51);
            this.txtComment.TabIndex = 13;
            this.txtComment.Text = "Marksman on the last top of south tower. Binoculars and m14 with supressor";
            // 
            // txtSpeed1
            // 
            this.txtSpeed.Location = new System.Drawing.Point(58, 62);
            this.txtSpeed.Name = "txtSpeed" + id;
            this.txtSpeed.Size = new System.Drawing.Size(44, 20);
            this.txtSpeed.TabIndex = 12;
            this.txtSpeed.Text = "Static";
            // 
            // txtRealDistance1
            // 
            this.txtRealDistance.Location = new System.Drawing.Point(294, 35);
            this.txtRealDistance.Name = "txtRealDistance" + id;
            this.txtRealDistance.Size = new System.Drawing.Size(46, 20);
            this.txtRealDistance.TabIndex = 11;
            this.txtRealDistance.Text = "2317 m";
            // 
            // txtElevation1
            // 
            this.txtElevation.Location = new System.Drawing.Point(167, 35);
            this.txtElevation.Name = "txtElevation" + id;
            this.txtElevation.Size = new System.Drawing.Size(43, 20);
            this.txtElevation.TabIndex = 10;
            this.txtElevation.Text = "-7.49";
            // 
            // txtDistance1
            // 
            this.txtDistance.Location = new System.Drawing.Point(58, 35);
            this.txtDistance.Name = "txtDistance" + id;
            this.txtDistance.Size = new System.Drawing.Size(44, 20);
            this.txtDistance.TabIndex = 9;
            this.txtDistance.Text = "2353 m";
            // 
            // lblZero1
            // 
            this.lblZero.AutoSize = true;
            this.lblZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZero.Location = new System.Drawing.Point(724, 18);
            this.lblZero.Name = "lblZero" + id;
            this.lblZero.Size = new System.Drawing.Size(83, 24);
            this.lblZero.TabIndex = 7;
            this.lblZero.Text = "Zeroing";
            // 
            // lblElevation1
            // 
            this.lblElevation.AutoSize = true;
            this.lblElevation.Location = new System.Drawing.Point(108, 38);
            this.lblElevation.Name = "lblElevation" + id;
            this.lblElevation.Size = new System.Drawing.Size(60, 13);
            this.lblElevation.TabIndex = 5;
            this.lblElevation.Text = "Elevation : ";
            // 
            // lblComment1
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(108, 65);
            this.lblComment.Name = "lblComment" + id;
            this.lblComment.Size = new System.Drawing.Size(60, 13);
            this.lblComment.TabIndex = 4;
            this.lblComment.Text = "Comment : ";
            // 
            // lblSpeed1
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(8, 65);
            this.lblSpeed.Name = "lblSpeed" + id;
            this.lblSpeed.Size = new System.Drawing.Size(47, 13);
            this.lblSpeed.TabIndex = 2;
            this.lblSpeed.Text = "Speed  :";
            // 
            // lblRealDistance1
            // 
            this.lblRealDistance.AutoSize = true;
            this.lblRealDistance.Location = new System.Drawing.Point(216, 38);
            this.lblRealDistance.Name = "lblRealDistance" + id;
            this.lblRealDistance.Size = new System.Drawing.Size(81, 13);
            this.lblRealDistance.TabIndex = 1;
            this.lblRealDistance.Text = "Real distance : ";
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(3, 38);
            this.lblDistance.Name = "lblDistance" + id;
            this.lblDistance.Size = new System.Drawing.Size(58, 13);
            this.lblDistance.TabIndex = 6;
            this.lblDistance.Text = "Distance : ";
            // 
            // lblName1
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(302, -1);
            this.lblName.Name = "lblName" + id;
            this.lblName.Size = new System.Drawing.Size(123, 31);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Target " + id;
            /*
            Form1.panels["pnlTarget" + this.id].Controls.Add(new System.Windows.Forms.SplitContainer());

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

        public Panel getPanel()
        {
            return this.panel;
        }


    }
}

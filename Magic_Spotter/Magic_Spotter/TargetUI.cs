﻿using System.Windows.Forms;

namespace Magic_Spotter {
	/// <summary>
	/// Graphical interface of the target. Generates a template that is common to every target, adds to it the target's properties and adds it to the application's interface
	/// </summary>
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
		private Label lblEliminated { get; set; }

        public TargetUI(Target t) {
			
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
			this.lblEliminated = new Label();

			// panel1 : Panel that contains the whole target 1's interface
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
			this.panel.Controls.Add(this.lblEliminated);
            this.panel.Location = new System.Drawing.Point(3, 3);
            this.panel.Name = "panel" + t.GetId();
            this.panel.Size = new System.Drawing.Size(730, 118);
            this.panel.TabIndex = 0;

            // SpcZero1 : split container that will contain the both Zeroing parts (lower on the left side, upper on the right side)
            this.spcZero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spcZero.Location = new System.Drawing.Point(350, 45);
            this.spcZero.Name = "spcZero" + t.GetId();

            // spcZero1.Panel1 : lower zero on the left part
            this.spcZero.Panel1.Controls.Add(this.lblZeroLowY);
            this.spcZero.Panel1.Controls.Add(this.lblZeroLowX);
            this.spcZero.Panel1.Controls.Add(this.lblZeroLow);
            
            // spcZero1.Panel2 : upper zero on the right part
            this.spcZero.Panel2.Controls.Add(this.lblZeroUpY);
            this.spcZero.Panel2.Controls.Add(this.lblZeroUpX);
            this.spcZero.Panel2.Controls.Add(this.lblZeroUp);
            this.spcZero.Size = new System.Drawing.Size(360, 68);
            this.spcZero.SplitterDistance = 180;
            this.spcZero.TabIndex = 16;
            
            // lblZeroLow1 : label showing the value of the lower zero
            this.lblZeroLow.AutoSize = true;
            this.lblZeroLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroLow.Location = new System.Drawing.Point(40, 0);
            this.lblZeroLow.Name = "lblZeroLow" + t.GetId();
            this.lblZeroLow.Size = new System.Drawing.Size(70, 24);
            this.lblZeroLow.TabIndex = 14;
            this.lblZeroLow.Text = t.getZeroing().GetLower() + " m";	// 1500 m

            // lblZero1LowX : label showing the value of the lower zero's horizontal adjustment
            this.lblZeroLowX.AutoSize = true;
            this.lblZeroLowX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroLowX.ForeColor = System.Drawing.Color.Black;
            this.lblZeroLowX.Location = new System.Drawing.Point(5, 29);
            this.lblZeroLowX.Name = "lblZero" + t.GetId() + "LowX";
            this.lblZeroLowX.Size = new System.Drawing.Size(70, 24);
            this.lblZeroLowX.TabIndex = 15;
            this.lblZeroLowX.Text = "X : " + t.getZeroing().calculateX(true);	// X : -0.65

            // lblZero1LowY : label showing the value of the lower zero's vertical adjustment
            this.lblZeroLowY.AutoSize = true;
            this.lblZeroLowY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroLowY.ForeColor = System.Drawing.Color.Black;
            this.lblZeroLowY.Location = new System.Drawing.Point(80, 29);
            this.lblZeroLowY.Name = "lblZero" + t.GetId() + "LowY";
            this.lblZeroLowY.Size = new System.Drawing.Size(70, 24);
            this.lblZeroLowY.TabIndex = 16;
            this.lblZeroLowY.Text = "Y : " + t.getZeroing().calculateY(true);	// Y : 1.25

            // lblZeroUp1 : label showing the value of the upper zero
            this.lblZeroUp.AutoSize = true;
            this.lblZeroUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroUp.Location = new System.Drawing.Point(40, 0);
            this.lblZeroUp.Name = "lblZeroUp" + t.GetId();
            this.lblZeroUp.Size = new System.Drawing.Size(70, 24);
            this.lblZeroUp.TabIndex = 15;
            this.lblZeroUp.Text = t.getZeroing().GetUpper() + " m";	// 1600 m

            // lblZero1UpX : label showing the value of the upper zero's horizontal adjusment
            this.lblZeroUpX.AutoSize = true;
            this.lblZeroUpX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroUpX.ForeColor = System.Drawing.Color.Black;
            this.lblZeroUpX.Location = new System.Drawing.Point(5, 29);
            this.lblZeroUpX.Name = "lblZero" + t.GetId() + "UpX";
            this.lblZeroUpX.Size = new System.Drawing.Size(70, 24);
            this.lblZeroUpX.TabIndex = 17;
            this.lblZeroUpX.Text = "X : " + t.getZeroing().calculateX(false);	// X : 0.3

            // lblZero1UpY : label showing the value of the upper zero's vertical adjusment
            this.lblZeroUpY.AutoSize = true;
            this.lblZeroUpY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroUpY.ForeColor = System.Drawing.Color.Black;
            this.lblZeroUpY.Location = new System.Drawing.Point(80, 29);
            this.lblZeroUpY.Name = "lblZero" + t.GetId() + "UpY";
            this.lblZeroUpY.Size = new System.Drawing.Size(70, 24);
            this.lblZeroUpY.TabIndex = 18;
            this.lblZeroUpY.Text = "Y : " + t.getZeroing().calculateY(true);	// Y : -2.42

            // txtComment1 : textbox of the target's comment
            this.txtComment.Location = new System.Drawing.Point(167, 62);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment" + t.GetId();
            this.txtComment.Size = new System.Drawing.Size(173, 51);
            this.txtComment.TabIndex = 13;
            this.txtComment.Text = t.GetComment();
			this.txtComment.ReadOnly = true;

			// txtSpeed1 : textbox of the target's speed
			this.txtSpeed.Location = new System.Drawing.Point(40, 62);
            this.txtSpeed.Name = "txtSpeed" + t.GetId();
            this.txtSpeed.Size = new System.Drawing.Size(62, 20);
            this.txtSpeed.TabIndex = 12;
            this.txtSpeed.Text = t.GetSpeed().GetName();
			this.txtSpeed.ReadOnly = true;

			// txtRealDistance1 : textbox of the target's real distance
			this.txtRealDistance.Location = new System.Drawing.Point(294, 35);
            this.txtRealDistance.Name = "txtRealDistance" + t.GetId();
            this.txtRealDistance.Size = new System.Drawing.Size(46, 20);
            this.txtRealDistance.TabIndex = 11;
            this.txtRealDistance.Text = t.realDistance() + " m";
			this.txtRealDistance.ReadOnly = true;

			// txtElevation1 : textbox of the target's elevation
			this.txtElevation.Location = new System.Drawing.Point(167, 35);
            this.txtElevation.Name = "txtElevation" + t.GetId();
            this.txtElevation.Size = new System.Drawing.Size(43, 20);
            this.txtElevation.TabIndex = 10;
            this.txtElevation.Text = t.GetElevation().ToString();
			this.txtElevation.ReadOnly = true;

			// txtDistance1 : textbox of the target's measured distance
			this.txtDistance.Location = new System.Drawing.Point(58, 35);
            this.txtDistance.Name = "txtDistance" + t.GetId();
            this.txtDistance.Size = new System.Drawing.Size(44, 20);
            this.txtDistance.TabIndex = 9;
            this.txtDistance.Text = t.GetDistance() + " m";
			this.txtDistance.ReadOnly = true;

			// lblZero1 : label of the zeroing part's title
			this.lblZero.AutoSize = true;
            this.lblZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZero.Location = new System.Drawing.Point(724, 18);
            this.lblZero.Name = "lblZero" + t.GetId();
            this.lblZero.Size = new System.Drawing.Size(83, 24);
            this.lblZero.TabIndex = 7;
            this.lblZero.Text = "Zeroing";

            // lblElevation1 : label of the elevation
            this.lblElevation.AutoSize = true;
            this.lblElevation.Location = new System.Drawing.Point(108, 38);
            this.lblElevation.Name = "lblElevation" + t.GetId();
            this.lblElevation.Size = new System.Drawing.Size(60, 13);
            this.lblElevation.TabIndex = 5;
            this.lblElevation.Text = "Elevation : ";

            // lblComment1 : label of the comment
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(108, 65);
            this.lblComment.Name = "lblComment" + t.GetId();
            this.lblComment.Size = new System.Drawing.Size(60, 13);
            this.lblComment.TabIndex = 4;
            this.lblComment.Text = "Comment : ";

            // lblSpeed1 : label of the speed
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(0, 65);
            this.lblSpeed.Name = "lblSpeed" + t.GetId();
            this.lblSpeed.Size = new System.Drawing.Size(30, 13);
            this.lblSpeed.TabIndex = 2;
            this.lblSpeed.Text = "Speed :";

            // lblRealDistance1 : label of the real distance
            this.lblRealDistance.AutoSize = true;
            this.lblRealDistance.Location = new System.Drawing.Point(216, 38);
            this.lblRealDistance.Name = "lblRealDistance" + t.GetId();
            this.lblRealDistance.Size = new System.Drawing.Size(81, 13);
            this.lblRealDistance.TabIndex = 1;
            this.lblRealDistance.Text = "Real distance : ";

            // lblDistance : label of the distance
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(3, 38);
            this.lblDistance.Name = "lblDistance" + t.GetId();
            this.lblDistance.Size = new System.Drawing.Size(58, 13);
            this.lblDistance.TabIndex = 6;
            this.lblDistance.Text = "Distance : ";

            // lblName1 : label of the target's name
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(302, -1);
            this.lblName.Name = "lblName" + t.GetId();
            this.lblName.Size = new System.Drawing.Size(123, 31);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Target " + t.GetId();

			// lblEliminated1 : shown only when target is eliminated
			this.lblEliminated.AutoSize = true;
			this.lblEliminated.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEliminated.ForeColor = System.Drawing.Color.Red;
			this.lblEliminated.Location = new System.Drawing.Point(450, -1);
			this.lblEliminated.Name = "lblEliminated" + t.GetId();
			this.lblEliminated.Size = new System.Drawing.Size(123, 31);
			this.lblEliminated.TabIndex = 0;
			this.lblEliminated.Text = "Eliminated";
			this.lblEliminated.Visible = false;
			
		}

		public Panel getPanel() {
            return this.panel;
        }

		/*********************
		 * Thread-safe calls *
		 *********************/

		/*
			The following part is about Thread-safe calls. Since the vocal recognition is made in a thread and the Form1 is handle in another, it is mandatory to
			use those Thread-safe calls to modify the UI from a recognition event. The recognition methods are calling stuff like SetDistance or SetRealDistance 
			on a target's TargetUI and the UI updating is handled here.
		*/
		
		// Set distance
		delegate void SetDistanceCallback(int distance);
		public void SetDistance(int distance) {
			if (txtDistance.InvokeRequired) {
				SetDistanceCallback d = new SetDistanceCallback(SetDistance);
				txtDistance.Invoke(d, new object[] {
					distance
				});
			} else {
				txtDistance.Text = distance + " m";
			}
		}

		// Set realDistance
		delegate void SetRealDistanceCallback(int realDistance);
		public void SetRealDistance(int realDistance) {
			if (txtRealDistance.InvokeRequired) {
				SetRealDistanceCallback d = new SetRealDistanceCallback(SetRealDistance);
				txtRealDistance.Invoke(d, new object[] {
					realDistance
				});
			} else {
				txtRealDistance.Text = realDistance + " m";
			}
		}

		// Set elevation
		delegate void SetElevationCallback(float elevation);
		public void SetElevation(float elevation) {
			if (txtElevation.InvokeRequired) {
				SetElevationCallback d = new SetElevationCallback(SetElevation);
				txtDistance.Invoke(d, new object[] {
					elevation
				});
			} else {
				txtElevation.Text = elevation.ToString();
			}
		}

		// Set speed
		delegate void SetSpeedCallback(Speed speed);
		public void SetSpeed(Speed speed) {
			if (txtSpeed.InvokeRequired) {
				SetSpeedCallback d = new SetSpeedCallback(SetSpeed);
				txtSpeed.Invoke(d, new object[] {
					speed
				});
			} else {
				txtSpeed.Text = speed.GetName();
			}
		}

		// Set comment
		delegate void SetCommentCallback(string comment);
		public void SetComment(string comment) {
			if (txtComment.InvokeRequired) {
				SetCommentCallback d = new SetCommentCallback(SetComment);
				txtComment.Invoke(d, new object[] {
					comment
				});
			} else {
				txtComment.Text = comment;
			}
		}

		//Set zeroing
		delegate void SetZeroingCallback(Zeroing zero);
		public void SetZeroing(Zeroing zero) {
			if (lblZeroLow.InvokeRequired) {
				SetZeroingCallback d = new SetZeroingCallback(SetZeroing);
				lblZeroLow.Invoke(d, new object[] {
					zero
				});
			} else {
				lblZeroLow.Text = zero.GetLower().ToString();
			}

			if (lblZeroUp.InvokeRequired) {
				SetZeroingCallback d = new SetZeroingCallback(SetZeroing);
				lblZeroUp.Invoke(d, new object[] {
					zero
				});
			} else {
				lblZeroUp.Text = zero.GetUpper().ToString();
			}

			if (lblZeroLowY.InvokeRequired) {
				SetZeroingCallback d = new SetZeroingCallback(SetZeroing);
				lblZeroLowY.Invoke(d, new object[] {
					zero
				});
			} else {
				lblZeroLowY.Text = "Y : " + zero.calculateY(true);
			}

			if (lblZeroUpY.InvokeRequired) {
				SetZeroingCallback d = new SetZeroingCallback(SetZeroing);
				lblZeroUpY.Invoke(d, new object[] {
					zero
				});
			} else {
				lblZeroUpY.Text = "Y : " + zero.calculateY(false);
			}

		}

		// Set Zeroing color highlight
		delegate void SetZeroingColorCallback(System.Drawing.Color color);
		public void SetZeroingColor(System.Drawing.Color color) {
			if (lblZeroLow.InvokeRequired) {
				SetZeroingColorCallback d = new SetZeroingColorCallback(SetZeroingColor);
				lblZeroLow.Invoke(d, new object[] {
					color
				});
			} else {
				lblZeroLow.ForeColor = color;
			}

			if (lblZeroLowX.InvokeRequired) {
				SetZeroingColorCallback d = new SetZeroingColorCallback(SetZeroingColor);
				lblZeroLowX.Invoke(d, new object[] {
					color
				});
			} else {
				lblZeroLowX.ForeColor = color;
			}

			if (lblZeroLowY.InvokeRequired) {
				SetZeroingColorCallback d = new SetZeroingColorCallback(SetZeroingColor);
				lblZeroLowY.Invoke(d, new object[] {
					color
				});
			} else {
				lblZeroLowY.ForeColor = color;
			}

			if (lblZeroUp.InvokeRequired) {
				SetZeroingColorCallback d = new SetZeroingColorCallback(SetZeroingColor);
				lblZeroUp.Invoke(d, new object[] {
					color
				});
			} else {
				lblZeroUp.ForeColor = color;
			}

			if (lblZeroUpX.InvokeRequired) {
				SetZeroingColorCallback d = new SetZeroingColorCallback(SetZeroingColor);
				lblZeroUpX.Invoke(d, new object[] {
					color
				});
			} else {
				lblZeroUpX.ForeColor = color;
			}

			if (lblZeroUpY.InvokeRequired) {
				SetZeroingColorCallback d = new SetZeroingColorCallback(SetZeroingColor);
				lblZeroUpY.Invoke(d, new object[] {
					color
				});
			} else {
				lblZeroUpY.ForeColor = color;
			}
		}

		// Set eliminated visibility
		delegate void SetEliminatedCallback(bool elim);
		public void SetEliminated(bool elim) {
			if (lblEliminated.InvokeRequired) {
				SetEliminatedCallback d = new SetEliminatedCallback(SetEliminated);
				lblEliminated.Invoke(d, new object[] {
					elim
				});
			} else {
				lblEliminated.Visible= elim;
			}
		}
	}
}

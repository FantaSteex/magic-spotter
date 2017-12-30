namespace Magic_Spotter {
    partial class Form1 {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent() {
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.panRecap = new System.Windows.Forms.Panel();
			this.panVocRec = new System.Windows.Forms.Panel();
			this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
			this.panRecognition = new System.Windows.Forms.Panel();
			this.lblRecap = new System.Windows.Forms.Label();
			this.lblRecognition = new System.Windows.Forms.Label();
			this.panRecap.SuspendLayout();
			this.panRecognition.SuspendLayout();
			this.SuspendLayout();
			// 
			// panRecap
			// 
			this.panRecap.Controls.Add(this.lblRecap);
			this.panRecap.Location = new System.Drawing.Point(0, 0);
			this.panRecap.Name = "panRecap";
			this.panRecap.Size = new System.Drawing.Size(734, 32);
			this.panRecap.TabIndex = 0;
			this.panRecap.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// panVocRec
			// 
			this.panVocRec.Location = new System.Drawing.Point(0, 533);
			this.panVocRec.Name = "panVocRec";
			this.panVocRec.Size = new System.Drawing.Size(1013, 32);
			this.panVocRec.TabIndex = 1;
			// 
			// flpMain
			// 
			this.flpMain.AutoScroll = true;
			this.flpMain.Location = new System.Drawing.Point(0, 31);
			this.flpMain.Name = "flpMain";
			this.flpMain.Size = new System.Drawing.Size(734, 452);
			this.flpMain.TabIndex = 2;
			this.flpMain.Paint += new System.Windows.Forms.PaintEventHandler(this.flpMain_Paint);
			// 
			// panRecognition
			// 
			this.panRecognition.Controls.Add(this.lblRecognition);
			this.panRecognition.Location = new System.Drawing.Point(0, 482);
			this.panRecognition.Name = "panRecognition";
			this.panRecognition.Size = new System.Drawing.Size(734, 29);
			this.panRecognition.TabIndex = 1;
			// 
			// lblRecap
			// 
			this.lblRecap.AutoSize = true;
			this.lblRecap.Location = new System.Drawing.Point(12, 9);
			this.lblRecap.Name = "lblRecap";
			this.lblRecap.Size = new System.Drawing.Size(254, 13);
			this.lblRecap.TabIndex = 0;
			this.lblRecap.Text = "Current state of the application will be displayed here";
			// 
			// lblRecognition
			// 
			this.lblRecognition.AutoSize = true;
			this.lblRecognition.Location = new System.Drawing.Point(12, 7);
			this.lblRecognition.Name = "lblRecognition";
			this.lblRecognition.Size = new System.Drawing.Size(307, 13);
			this.lblRecognition.TabIndex = 1;
			this.lblRecognition.Text = "Recognized words / keywords will be displayed here in real time";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(734, 511);
			this.Controls.Add(this.panRecognition);
			this.Controls.Add(this.flpMain);
			this.Controls.Add(this.panVocRec);
			this.Controls.Add(this.panRecap);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panRecap.ResumeLayout(false);
			this.panRecap.PerformLayout();
			this.panRecognition.ResumeLayout(false);
			this.panRecognition.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panRecap;
        private System.Windows.Forms.Panel panVocRec;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
		private System.Windows.Forms.Label lblRecap;
		private System.Windows.Forms.Panel panRecognition;
		private System.Windows.Forms.Label lblRecognition;
	}
}


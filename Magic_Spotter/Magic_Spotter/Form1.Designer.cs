﻿namespace Magic_Spotter {
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
			this.lblProcess = new System.Windows.Forms.Label();
			this.panVocRec = new System.Windows.Forms.Panel();
			this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
			this.panRecognition = new System.Windows.Forms.Panel();
			this.lblRecognition = new System.Windows.Forms.Label();
			this.lblProcessTitle = new System.Windows.Forms.Label();
			this.lblRecognitionTitle = new System.Windows.Forms.Label();
			this.panRecap.SuspendLayout();
			this.panRecognition.SuspendLayout();
			this.SuspendLayout();
			// 
			// panRecap
			// 
			this.panRecap.Controls.Add(this.lblProcessTitle);
			this.panRecap.Controls.Add(this.lblProcess);
			this.panRecap.Location = new System.Drawing.Point(0, 0);
			this.panRecap.Name = "panRecap";
			this.panRecap.Size = new System.Drawing.Size(746, 32);
			this.panRecap.TabIndex = 0;
			this.panRecap.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// lblProcess
			// 
			this.lblProcess.AutoSize = true;
			this.lblProcess.Location = new System.Drawing.Point(171, 9);
			this.lblProcess.Name = "lblProcess";
			this.lblProcess.Size = new System.Drawing.Size(216, 13);
			this.lblProcess.TabIndex = 0;
			this.lblProcess.Text = "L\'état courant de l\'application sera affiché ici";
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
			this.flpMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.flpMain.Size = new System.Drawing.Size(746, 445);
			this.flpMain.TabIndex = 2;
			this.flpMain.Paint += new System.Windows.Forms.PaintEventHandler(this.flpMain_Paint);
			// 
			// panRecognition
			// 
			this.panRecognition.Controls.Add(this.lblRecognitionTitle);
			this.panRecognition.Controls.Add(this.lblRecognition);
			this.panRecognition.Location = new System.Drawing.Point(0, 482);
			this.panRecognition.Name = "panRecognition";
			this.panRecognition.Size = new System.Drawing.Size(746, 29);
			this.panRecognition.TabIndex = 1;
			// 
			// lblRecognition
			// 
			this.lblRecognition.AutoSize = true;
			this.lblRecognition.Location = new System.Drawing.Point(207, 9);
			this.lblRecognition.Name = "lblRecognition";
			this.lblRecognition.Size = new System.Drawing.Size(229, 13);
			this.lblRecognition.TabIndex = 1;
			this.lblRecognition.Text = "Les mots / phrases reconnus seront affichés ici";
			this.lblRecognition.Click += new System.EventHandler(this.lblRecognition_Click);
			// 
			// lblProcessTitle
			// 
			this.lblProcessTitle.AutoSize = true;
			this.lblProcessTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.lblProcessTitle.Location = new System.Drawing.Point(12, 4);
			this.lblProcessTitle.Name = "lblProcessTitle";
			this.lblProcessTitle.Size = new System.Drawing.Size(153, 20);
			this.lblProcessTitle.TabIndex = 1;
			this.lblProcessTitle.Text = "Processus courant : ";
			// 
			// lblRecognitionTitle
			// 
			this.lblRecognitionTitle.AutoSize = true;
			this.lblRecognitionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.lblRecognitionTitle.Location = new System.Drawing.Point(12, 4);
			this.lblRecognitionTitle.Name = "lblRecognitionTitle";
			this.lblRecognitionTitle.Size = new System.Drawing.Size(189, 20);
			this.lblRecognitionTitle.TabIndex = 2;
			this.lblRecognitionTitle.Text = "Reconnaissance vocale : ";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(737, 511);
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
		private System.Windows.Forms.Label lblProcess;
		private System.Windows.Forms.Panel panRecognition;
		private System.Windows.Forms.Label lblRecognition;
		private System.Windows.Forms.Label lblProcessTitle;
		private System.Windows.Forms.Label lblRecognitionTitle;
	}
}


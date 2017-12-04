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
            this.pnlTarget1 = new System.Windows.Forms.Panel();
            this.lblName1 = new System.Windows.Forms.Label();
            this.lblRealDistance1 = new System.Windows.Forms.Label();
            this.lblSpeed1 = new System.Windows.Forms.Label();
            this.lblComment1 = new System.Windows.Forms.Label();
            this.lblElevation1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblZero1 = new System.Windows.Forms.Label();
            this.txtDistance1 = new System.Windows.Forms.TextBox();
            this.txtElevation1 = new System.Windows.Forms.TextBox();
            this.txtRealDistance1 = new System.Windows.Forms.TextBox();
            this.txtSpeed1 = new System.Windows.Forms.TextBox();
            this.txtComment1 = new System.Windows.Forms.TextBox();
            this.lblZeroLow1 = new System.Windows.Forms.Label();
            this.lblZeroUp1 = new System.Windows.Forms.Label();
            this.spcZero1 = new System.Windows.Forms.SplitContainer();
            this.lblZero1LowX = new System.Windows.Forms.Label();
            this.lblZero1LowY = new System.Windows.Forms.Label();
            this.lblZero1UpX = new System.Windows.Forms.Label();
            this.lblZero1UpY = new System.Windows.Forms.Label();
            this.flpMain.SuspendLayout();
            this.pnlTarget1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcZero1)).BeginInit();
            this.spcZero1.Panel1.SuspendLayout();
            this.spcZero1.Panel2.SuspendLayout();
            this.spcZero1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panRecap
            // 
            this.panRecap.Location = new System.Drawing.Point(0, 0);
            this.panRecap.Name = "panRecap";
            this.panRecap.Size = new System.Drawing.Size(1013, 32);
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
            this.flpMain.Controls.Add(this.pnlTarget1);
            this.flpMain.Location = new System.Drawing.Point(0, 31);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(1013, 504);
            this.flpMain.TabIndex = 2;
            // 
            // pnlTarget1
            // 
            this.pnlTarget1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTarget1.Controls.Add(this.spcZero1);
            this.pnlTarget1.Controls.Add(this.txtComment1);
            this.pnlTarget1.Controls.Add(this.txtSpeed1);
            this.pnlTarget1.Controls.Add(this.txtRealDistance1);
            this.pnlTarget1.Controls.Add(this.txtElevation1);
            this.pnlTarget1.Controls.Add(this.txtDistance1);
            this.pnlTarget1.Controls.Add(this.lblZero1);
            this.pnlTarget1.Controls.Add(this.label7);
            this.pnlTarget1.Controls.Add(this.lblElevation1);
            this.pnlTarget1.Controls.Add(this.lblComment1);
            this.pnlTarget1.Controls.Add(this.lblSpeed1);
            this.pnlTarget1.Controls.Add(this.lblRealDistance1);
            this.pnlTarget1.Controls.Add(this.lblName1);
            this.pnlTarget1.Location = new System.Drawing.Point(3, 3);
            this.pnlTarget1.Name = "pnlTarget1";
            this.pnlTarget1.Size = new System.Drawing.Size(1010, 118);
            this.pnlTarget1.TabIndex = 0;
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName1.Location = new System.Drawing.Point(467, -1);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(123, 31);
            this.lblName1.TabIndex = 0;
            this.lblName1.Text = "Target 1";
            this.lblName1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblRealDistance1
            // 
            this.lblRealDistance1.AutoSize = true;
            this.lblRealDistance1.Location = new System.Drawing.Point(344, 38);
            this.lblRealDistance1.Name = "lblRealDistance1";
            this.lblRealDistance1.Size = new System.Drawing.Size(81, 13);
            this.lblRealDistance1.TabIndex = 1;
            this.lblRealDistance1.Text = "Real distance : ";
            // 
            // lblSpeed1
            // 
            this.lblSpeed1.AutoSize = true;
            this.lblSpeed1.Location = new System.Drawing.Point(10, 65);
            this.lblSpeed1.Name = "lblSpeed1";
            this.lblSpeed1.Size = new System.Drawing.Size(47, 13);
            this.lblSpeed1.TabIndex = 2;
            this.lblSpeed1.Text = "Speed  :";
            // 
            // lblComment1
            // 
            this.lblComment1.AutoSize = true;
            this.lblComment1.Location = new System.Drawing.Point(164, 65);
            this.lblComment1.Name = "lblComment1";
            this.lblComment1.Size = new System.Drawing.Size(60, 13);
            this.lblComment1.TabIndex = 4;
            this.lblComment1.Text = "Comment : ";
            // 
            // lblElevation1
            // 
            this.lblElevation1.AutoSize = true;
            this.lblElevation1.Location = new System.Drawing.Point(164, 38);
            this.lblElevation1.Name = "lblElevation1";
            this.lblElevation1.Size = new System.Drawing.Size(60, 13);
            this.lblElevation1.TabIndex = 5;
            this.lblElevation1.Text = "Elevation : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Distance : ";
            // 
            // lblZero1
            // 
            this.lblZero1.AutoSize = true;
            this.lblZero1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZero1.Location = new System.Drawing.Point(724, 18);
            this.lblZero1.Name = "lblZero1";
            this.lblZero1.Size = new System.Drawing.Size(83, 24);
            this.lblZero1.TabIndex = 7;
            this.lblZero1.Text = "Zeroing";
            // 
            // txtDistance1
            // 
            this.txtDistance1.Location = new System.Drawing.Point(58, 35);
            this.txtDistance1.Name = "txtDistance1";
            this.txtDistance1.Size = new System.Drawing.Size(89, 20);
            this.txtDistance1.TabIndex = 9;
            this.txtDistance1.Text = "2353 m";
            // 
            // txtElevation1
            // 
            this.txtElevation1.Location = new System.Drawing.Point(222, 35);
            this.txtElevation1.Name = "txtElevation1";
            this.txtElevation1.Size = new System.Drawing.Size(104, 20);
            this.txtElevation1.TabIndex = 10;
            this.txtElevation1.Text = "-7.49";
            // 
            // txtRealDistance1
            // 
            this.txtRealDistance1.Location = new System.Drawing.Point(422, 35);
            this.txtRealDistance1.Name = "txtRealDistance1";
            this.txtRealDistance1.Size = new System.Drawing.Size(98, 20);
            this.txtRealDistance1.TabIndex = 11;
            this.txtRealDistance1.Text = "2317 m";
            // 
            // txtSpeed1
            // 
            this.txtSpeed1.Location = new System.Drawing.Point(58, 62);
            this.txtSpeed1.Name = "txtSpeed1";
            this.txtSpeed1.Size = new System.Drawing.Size(89, 20);
            this.txtSpeed1.TabIndex = 12;
            this.txtSpeed1.Text = "Static";
            // 
            // txtComment1
            // 
            this.txtComment1.Location = new System.Drawing.Point(222, 62);
            this.txtComment1.Multiline = true;
            this.txtComment1.Name = "txtComment1";
            this.txtComment1.Size = new System.Drawing.Size(298, 51);
            this.txtComment1.TabIndex = 13;
            this.txtComment1.Text = "Marksman on the last top of south tower. Binoculars and m14 with supressor";
            // 
            // lblZeroLow1
            // 
            this.lblZeroLow1.AutoSize = true;
            this.lblZeroLow1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroLow1.Location = new System.Drawing.Point(69, 0);
            this.lblZeroLow1.Name = "lblZeroLow1";
            this.lblZeroLow1.Size = new System.Drawing.Size(77, 24);
            this.lblZeroLow1.TabIndex = 14;
            this.lblZeroLow1.Text = "2300 m";
            // 
            // lblZeroUp1
            // 
            this.lblZeroUp1.AutoSize = true;
            this.lblZeroUp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroUp1.Location = new System.Drawing.Point(74, 0);
            this.lblZeroUp1.Name = "lblZeroUp1";
            this.lblZeroUp1.Size = new System.Drawing.Size(77, 24);
            this.lblZeroUp1.TabIndex = 15;
            this.lblZeroUp1.Text = "2400 m";
            // 
            // spcZero1
            // 
            this.spcZero1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spcZero1.Location = new System.Drawing.Point(529, 45);
            this.spcZero1.Name = "spcZero1";
            // 
            // spcZero1.Panel1
            // 
            this.spcZero1.Panel1.Controls.Add(this.lblZero1LowY);
            this.spcZero1.Panel1.Controls.Add(this.lblZero1LowX);
            this.spcZero1.Panel1.Controls.Add(this.lblZeroLow1);
            // 
            // spcZero1.Panel2
            // 
            this.spcZero1.Panel2.Controls.Add(this.lblZero1UpY);
            this.spcZero1.Panel2.Controls.Add(this.lblZero1UpX);
            this.spcZero1.Panel2.Controls.Add(this.lblZeroUp1);
            this.spcZero1.Size = new System.Drawing.Size(472, 68);
            this.spcZero1.SplitterDistance = 236;
            this.spcZero1.TabIndex = 16;
            // 
            // lblZero1LowX
            // 
            this.lblZero1LowX.AutoSize = true;
            this.lblZero1LowX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZero1LowX.ForeColor = System.Drawing.Color.Red;
            this.lblZero1LowX.Location = new System.Drawing.Point(17, 29);
            this.lblZero1LowX.Name = "lblZero1LowX";
            this.lblZero1LowX.Size = new System.Drawing.Size(54, 24);
            this.lblZero1LowX.TabIndex = 15;
            this.lblZero1LowX.Text = "X : 0";
            // 
            // lblZero1LowY
            // 
            this.lblZero1LowY.AutoSize = true;
            this.lblZero1LowY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZero1LowY.ForeColor = System.Drawing.Color.Red;
            this.lblZero1LowY.Location = new System.Drawing.Point(132, 29);
            this.lblZero1LowY.Name = "lblZero1LowY";
            this.lblZero1LowY.Size = new System.Drawing.Size(87, 24);
            this.lblZero1LowY.TabIndex = 16;
            this.lblZero1LowY.Text = "Y : -0,73";
            // 
            // lblZero1UpX
            // 
            this.lblZero1UpX.AutoSize = true;
            this.lblZero1UpX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZero1UpX.ForeColor = System.Drawing.Color.Red;
            this.lblZero1UpX.Location = new System.Drawing.Point(23, 29);
            this.lblZero1UpX.Name = "lblZero1UpX";
            this.lblZero1UpX.Size = new System.Drawing.Size(54, 24);
            this.lblZero1UpX.TabIndex = 17;
            this.lblZero1UpX.Text = "X : 0";
            // 
            // lblZero1UpY
            // 
            this.lblZero1UpY.AutoSize = true;
            this.lblZero1UpY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZero1UpY.ForeColor = System.Drawing.Color.Red;
            this.lblZero1UpY.Location = new System.Drawing.Point(134, 29);
            this.lblZero1UpY.Name = "lblZero1UpY";
            this.lblZero1UpY.Size = new System.Drawing.Size(80, 24);
            this.lblZero1UpY.TabIndex = 18;
            this.lblZero1UpY.Text = "Y : 1,58";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 564);
            this.Controls.Add(this.flpMain);
            this.Controls.Add(this.panVocRec);
            this.Controls.Add(this.panRecap);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flpMain.ResumeLayout(false);
            this.pnlTarget1.ResumeLayout(false);
            this.pnlTarget1.PerformLayout();
            this.spcZero1.Panel1.ResumeLayout(false);
            this.spcZero1.Panel1.PerformLayout();
            this.spcZero1.Panel2.ResumeLayout(false);
            this.spcZero1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcZero1)).EndInit();
            this.spcZero1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panRecap;
        private System.Windows.Forms.Panel panVocRec;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.Panel pnlTarget1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblElevation1;
        private System.Windows.Forms.Label lblComment1;
        private System.Windows.Forms.Label lblSpeed1;
        private System.Windows.Forms.Label lblRealDistance1;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Label lblZero1;
        private System.Windows.Forms.TextBox txtComment1;
        private System.Windows.Forms.TextBox txtSpeed1;
        private System.Windows.Forms.TextBox txtRealDistance1;
        private System.Windows.Forms.TextBox txtElevation1;
        private System.Windows.Forms.TextBox txtDistance1;
        private System.Windows.Forms.SplitContainer spcZero1;
        private System.Windows.Forms.Label lblZeroLow1;
        private System.Windows.Forms.Label lblZeroUp1;
        private System.Windows.Forms.Label lblZero1LowY;
        private System.Windows.Forms.Label lblZero1LowX;
        private System.Windows.Forms.Label lblZero1UpY;
        private System.Windows.Forms.Label lblZero1UpX;
    }
}


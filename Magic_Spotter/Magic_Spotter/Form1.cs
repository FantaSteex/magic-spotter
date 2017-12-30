using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magic_Spotter {
	public partial class Form1 : Form {

		public static Dictionary<string, Panel> panels = new Dictionary<string, Panel>();

		public Form1() {
			InitializeComponent();

		}

		private void Form1_Load(object sender, EventArgs e) {
			
		}

		private void panel1_Paint(object sender, PaintEventArgs e) {

		}

		private void flpMain_Paint(object sender, PaintEventArgs e) {

		}

		public FlowLayoutPanel getFlpMain() {
			return flpMain;
		}

		// lblRecognition
		delegate void SetLabelRecognitionTextCallback(string text);
		public void SetLabelRecognitionText(string text) {
			if (lblRecognition.InvokeRequired) {
				SetLabelRecognitionTextCallback d = new SetLabelRecognitionTextCallback(SetLabelRecognitionText);
				this.Invoke(d, new object[] {
					text
				});
			} else {
				this.lblRecognition.Text = text;
			}
		}

		// lblProcess
		delegate void SetLabelProcessTextCallback(string text);
		public void SetLabelProcessText(string text) {
			if (lblProcess.InvokeRequired) {
				SetLabelProcessTextCallback d = new SetLabelProcessTextCallback(SetLabelProcessText);
				this.Invoke(d, new object[] {
					text
				});
			} else {
				this.lblProcess.Text = text;
			}
		}

		// Adding TargetUI's panel
		delegate void SetTargetUICallback(Panel p);
		public void SetTargetUI(Panel p) {
			if (flpMain.InvokeRequired) {
				SetTargetUICallback d = new SetTargetUICallback(SetTargetUI);
				this.Invoke(d, new object[] {
					p
				});
			} else {
				this.flpMain.Controls.Add(p);
			}
		}

		private void lblRecognition_Click(object sender, EventArgs e) {

		}
	}
}
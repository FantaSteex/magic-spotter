using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Magic_Spotter {
    static class Program {


        static Dictionary<int, Target> targets = new Dictionary<int, Target>();

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Form1 form = new Form1();

            Dictionary<int, Dictionary<int, double>> adjustmentsTable = Adjustments.adjustmentsTable;
            Debug.WriteLine(Adjustments.adjustmentsTable[300][-50]);



            addTarget(1, form);
            addTarget(2, form);
            addTarget(3, form);
            addTarget(4, form);
            addTarget(5, form);

			/*
                10 min de démo sur ordi perso
                Exposer ce qu'on a fait, comment etc pendant 5 min
                5 max de démo
            */

			SpeechRecognition sr = new SpeechRecognition();
			

			Application.Run(form);
        }

        static void addTarget(int id, Form1 f) {
            if(targets.ContainsKey(id)) {
                Debug.WriteLine("------ Error : target {0} already exists", id);
            } else {
                targets.Add(id, new Target(id));
                f.getFlpMain().Controls.Add(targets[id].getPanel());
            }
            
        }
    }
}
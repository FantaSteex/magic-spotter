using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magic_Spotter {
    static class Program {

        



        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Dictionary<int, Dictionary<int, double>> adjustmentsTable = Adjustments.adjustmentsTable;

            Debug.WriteLine(adjustmentsTable[300][-50]);

            Application.Run(new Form1());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Spotter {
    static class Adjustments {

        public static Dictionary<int, Dictionary<int, double>> adjustmentsTable = new Dictionary<int, Dictionary<int, double>>() {
            {
                300, new Dictionary<int, double>() {
                    { -100, 0.3 },
                    { -50, 0.15 },
                    { 0, -0.35 },
                    { 50, -0.5 },
                    { 100, -1 }
                }
            },
            {
                400, new Dictionary<int, double>() {
                    { -100, 0.5 },
                    { -50, 0.25 },
                    { 0, -0.25 },
                    { 50, -0.6 },
                    { 100, -1 }
                }
            },
            {
                500, new Dictionary<int, double>() {
                    { -100, 1 },
                    { -50, 0.5 },
                    { 0, 0.05 },
                    { 50, -0.7 },
                    { 100, -1 }
                }
            },
            {
                600, new Dictionary<int, double>() {
                    { -100, 1 },
                    { -50, 0.6 },
                    { 0, -0.2 },
                    { 50, -0.8 },
                    { 100, -1 }
                }
            },
            {
                700, new Dictionary<int, double>() {
                    { -100, 1 },
                    { -50, 0.6 },
                    { 0, -0.25 },
                    { 50, -0.8 },
                    { 100, -1 }
                }
            },
            {
                800, new Dictionary<int, double>() {
                    { -100, 1 },
                    { -50, 0.6 },
                    { 0, -0.25 },
                    { 50, -0.8 },
                    { 100, -1 }
                }
            },
            {
                900, new Dictionary<int, double>() {
                    { -100, 1 },
                    { -50, 0.5 },
                    { 0, -0.15 },
                    { 50, -0.8 },
                    { 100, -1.5 }
                }
            },
            {
                1000, new Dictionary<int, double>() {
                    { -100, 1 },
                    { -50, 0.55 },
                    { 0, -0.15 },
                    { 50, -0.9 },
                    { 100, -1.5 }
                }
            },
            {
                1100, new Dictionary<int, double>() {
                    { -100, 1.1 },
                    { -50, 0.5 },
                    { 0, -0.25 },
                    { 50, -0.95 },
                    { 100, -1.6 }
                }
            },
            {
                1200, new Dictionary<int, double>() {
                    { -100, 1.15 },
                    { -50, 0.45 },
                    { 0, -0.2 },
                    { 50, -0.9 },
                    { 100, -1.7 }
                }
            },
            {
                1300, new Dictionary<int, double>() {
                    { -100, 1.5 },
                    { -50, 0.5 },
                    { 0, -0.2 },
                    { 50, -1 },
                    { 100, -1.5 }
                }
            },
            {
                1400, new Dictionary<int, double>() {
                    { -100, 1.75 },
                    { -50, 0.6 },
                    { 0, -0.2 },
                    { 50, -1.1 },
                    { 100, -1.75 }
                }
            },
            {
                1500, new Dictionary<int, double>() {
                    { -100, 1.75 },
                    { -50, 0.75 },
                    { 0, -0.3 },
                    { 50, -1.1 },
                    { 100, -2 }
                }
            },
            {
                1600, new Dictionary<int, double>() {
                    { -100, 1.75 },
                    { -50, 0.75 },
                    { 0, -0.3 },
                    { 50, -1.15 },
                    { 100, -2 }
                }
            },
            {
                1700, new Dictionary<int, double>() {
                    { -100, 1.75 },
                    { -50, 0.75 },
                    { 0, -0.3 },
                    { 50, -1.2 },
                    { 100, -2.25 }
                }
            },
            {
                1800, new Dictionary<int, double>() {
                    { -100, 2 },
                    { -50, 0.85 },
                    { 0, -0.3 },
                    { 50, -1.4 },
                    { 100, -2.5 }
                }
            },
            {
                1900, new Dictionary<int, double>() {
                    { -100, 0.5 },
                    { -50, 0.25 },
                    { 0, -0.25 },
                    { 50, -0.6 },
                    { 100, -1 }
                }
            },
            {
                2000, new Dictionary<int, double>() {
                    { -100, 2.5 },
                    { -50, 1 },
                    { 0, -0.25 },
                    { 50, -1.5 },
                    { 100, -2.75 }
                }
            },
            {
                2100, new Dictionary<int, double>() {
                    { -100, 2.5 },
                    { -50, 1.2 },
                    { 0, -0.3 },
                    { 50, -1.5 },
                    { 100, -3.2 }
                }
            },
            {
                2200, new Dictionary<int, double>() {
                    { -100, 0.5 },
                    { -50, 0.25 },
                    { 0, -0.35 },
                    { 50, -0.6 },
                    { 100, -1 }
                }
            },
            {
                2300, new Dictionary<int, double>() {
                    { -100, 0.5 },
                    { -50, 0.25 },
                    { 0, -0.3 },
                    { 50, -0.6 },
                    { 100, -1 }
                }
            },
            {
                2400, new Dictionary<int, double>() {
                    { -100, 0.5 },
                    { -50, 0.25 },
                    { 0, -0.4 },
                    { 50, -0.6 },
                    { 100, -3.7 }
                }
            }
        };

    }
}

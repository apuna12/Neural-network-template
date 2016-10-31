using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int[] size = {2, 10, 5, 1};
            double[][] data = new double[4][];
            data[0] = new double[2] {0, 0};
            data[1] = new double[2] { 0, 1 };
            data[2] = new double[2] { 1, 0 };
            data[3] = new double[2] { 1, 1 };
            double[] results = { 0, 1, 1, 0 };
            Network net = new Network(4, size, 0.2);
            double[] arr = new double[1];

            for (int i = 0; i < 5000000; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arr[0] = results[j];
                    net.Learning(data[j], arr);
                }
            }

            double[] a = net.Run(data[0]);
            double[] b = net.Run(data[1]);
            double[] c = net.Run(data[2]);
            double[] d = net.Run(data[3]);
        }
    }
}

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
            int[] size = {3, 4, 1};
            Network net = new Network(3, size, 0.3);
            int a = 6;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BluetoothPoker
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            Dealer Deste = new Dealer();
            InitializeComponent();
            Deste.getready();
        }
    }
}

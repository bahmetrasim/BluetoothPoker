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
        List<string> player1 = new List<string>();
        List<string> player2 = new List<string>();
        List<List<string>> allplayers = new List<List<string>>();
        Dealer Deste = new Dealer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Deal_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                player1.Add(Deste.getcard());
                player2.Add(Deste.getcard());
            }
            allplayers.Add(player1);
            allplayers.Add(player2);
            UpdateForm(allplayers);
        }
        public void UpdateForm(List<List<string>> all)
        {
            int playernumber =0;
            do
            {
                for (int i = 0; i < 5; i++)
                {
                    Controls["label" + (playernumber*5+i)].Text = all[playernumber][i];
                }
                playernumber++;
            }  
            while (playernumber < allplayers.Count);
        }
    }
}

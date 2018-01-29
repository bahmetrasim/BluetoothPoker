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
        Dealer Deste = new Dealer();
        List<List<string>> allplayers = new List<List<string>>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Deal_Click(object sender, EventArgs e)
        {
            ResetForm();
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
            int playernumber = 0;
            do
            {
                for (int i = 0; i < 5; i++)
                {
                    Controls["label" + (playernumber * 5 + i)].Text = all[playernumber][i];
                }
                playernumber++;
            }
            while (playernumber < allplayers.Count);
        }

        public void ResetForm()
        {
            int labelnumber = -1;
            foreach (Control vControl in Controls)
            {
                if (vControl is Label) labelnumber++;
            }

            for (int i = 0; i < labelnumber; i++)
            {
                Controls["label" + i].Text = "";
            }
            allplayers.Clear();
            player1.Clear();
            player2.Clear();
        }
        private void Winner_Click(object sender, EventArgs e)
        {
            PlayerRatings winner = new PlayerRatings((Deste.allcards()), player1, player2);
            Controls["label" + 10].Text = winner.Compare();
           
        }
    }
}

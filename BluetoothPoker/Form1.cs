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
        List<string>[] players = new List<string>[9];
        Dealer Deste = new Dealer();
        List<List<string>> allplayers = new List<List<string>>();
        Dictionary<List<string>, int> bestoffive = new Dictionary<List<string>, int>();

        public Form1()
        {
            InitializeComponent();
            players[8] = new List<string>();
            for (int i = 1; i < 9; i++)
            {
                Controls["P"+i+"FOLD"].MouseClick += Buttons_Click;
            }
        }
        private void Buttons_Click(object sender, EventArgs e)
        {
            Button name = (Button)sender;
        }
        private void Deal_Click(object sender, EventArgs e)
        {
            ResetForm();
            Deste.resetcards();
            players[8].Clear();
            //Player 9 is Table with continue button
            for (int i = 0; i < 8; i++)
            {
                players[i] = new List<string>();
                players[i].Add(Deste.getcard());
            }
            for (int i = 0; i < 8; i++)
            {
                players[i].Add(Deste.getcard());
            }
            for (int i = 0; i < 9; i++)
            {
                allplayers.Add(players[i]);
            }
            UpdateForm(allplayers);

        }
        public void UpdateForm(List<List<string>> all)
        {
            int playernumber = 0;
            do
            {
                if (playernumber == 8)
                {
                    if (players[8].Count == 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            ((Label)Controls["tlabel" + i]).Image = null;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < players[8].Count; i++)
                        {
                            //Controls["tlabel" + i].Text = all[playernumber][i];
                            ((Label)Controls["tlabel" + i]).Image = resizeImage((Image)Properties.Resources.ResourceManager.GetObject("_" + all[playernumber][i]), ((Label)Controls["tlabel" + i]).Size);
                            // ((Label)Controls["tlabel" + i]).Image.
                        }
                    }
                    //tlabel0.Image = (Image)Properties.Resources.ResourceManager.GetObject(("_" + tlabel0.Text));
                    playernumber++;
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        //Controls["clabel" + (playernumber * 2 + i)].Text = all[playernumber][i];
                        ((Label)Controls["clabel" + (playernumber * 2 + i)]).Image = resizeImage((Image)Properties.Resources.ResourceManager.GetObject("_" + all[playernumber][i]), ((Label)Controls["clabel" + (playernumber * 2 + i)]).Size);
                    }
                    playernumber++;
                }
            }
            while (playernumber < allplayers.Count);
        }
        public void ResetForm()
        {
            for (int i = 0; i < 16; i++)
            {
                if (i < 5) Controls["tlabel" + i].Text = "";
                Controls["clabel" + i].Text = "";
            }
            allplayers.Clear();
            for (int i = 0; i < 9; i++)
            {
                if (players[i] != null) players[i].Clear();
            }
            Controls["winreason"].Text = "";
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void Winner_Click(object sender, EventArgs e)
        {
            //Controls["label" + 10].Text = winner.Compare();
            if (allplayers[8].Count != 5) { }
            else
            {
                PlayerRatings FinalCards = new PlayerRatings((Deste.allcards()), allplayers);
                bestoffive = FinalCards.PlayerCardswithTable();
                bestoffive = FinalCards.sortdic(bestoffive);
                WinningRules winnigrules = new WinningRules();
                if (bestoffive.ElementAt(0).Value != bestoffive.ElementAt(1).Value)
                {
                    string a = winnigrules.getwinnerlevel(bestoffive.ElementAt(0).Value);
                    Controls["winreason"].Text = "Player " + (allplayers.IndexOf(bestoffive.ElementAt(0).Key)+1) + " wins " + a;
                }
                else
                {
                    Dictionary<string, List<string>> compare = new Dictionary<string, List<string>>();
                    int high = bestoffive.ElementAt(0).Value;
                    int equalplayers = bestoffive.Values.Count(highest => highest == bestoffive.ElementAt(0).Value);
                    for (int i = 0; i < equalplayers; i++)
                    {
                        compare.Add(("Player" + (allplayers.IndexOf(bestoffive.ElementAt(i).Key)+1)), bestoffive.ElementAt(i).Key);
                    }
                    Controls["winreason"].Text = FinalCards.Compare(compare) +  " wins " + winnigrules.getwinnerlevel(high) ;            
                }
            }
        }
        private void Continue_Click(object sender, EventArgs e)
        {
            players[8].Add(Deste.getcard());
            UpdateForm(allplayers);
        }
        public void BravePlayers()
        {

        }
    }
}

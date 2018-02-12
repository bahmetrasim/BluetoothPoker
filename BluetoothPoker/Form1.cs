﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }
        private void Deal_Click(object sender, EventArgs e)
        {
            ResetForm();
            Deste.resetcards();
            //Player 9 is Table and 5 cards
            for (int i = 0; i < 9; i++)
            {
                players[i] = new List<string>();
                if (i<8)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        players[i].Add(Deste.getcard());
                    } 
                }
                else
                {
                    for (int j = 0; j < 5; j++)
                    {
                        players[i].Add(Deste.getcard());
                    }
                }

            }
            for (int i = 0; i < 9; i++)
            {
                allplayers.Add(players[i]);
            }       
            UpdateForm(allplayers);
            PlayerRatings FinalCards = new PlayerRatings((Deste.allcards()), allplayers);
            FinalCards.PlayerCardswithTable();
        }
        public void UpdateForm(List<List<string>> all)
        {
            int playernumber = 0;
            do
            {
                if (playernumber == 8)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        //Controls["tlabel" + i].Text = all[playernumber][i];
                        ((Label)Controls["tlabel" + i]).Image = resizeImage((Image)Properties.Resources.ResourceManager.GetObject("_" + all[playernumber][i]), ((Label)Controls["tlabel" + i]).Size);
                       // ((Label)Controls["tlabel" + i]).Image.
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
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void Winner_Click(object sender, EventArgs e)
        {
            
            //Controls["label" + 10].Text = winner.Compare();
           
        }

    }
}

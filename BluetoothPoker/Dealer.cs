﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluetoothPoker
{
    class Dealer
    
    {

        public void getready()
        {
            Dictionary<string, int> full = new Dictionary<string, int>();
            string kupa; //Heart
            string karo; //Diamonds
            string sinek; //Clubs
            string maca; //Spades

            for (int i = 2; i < 15; i++)
            {
                if (i == 10)
                {
                    kupa = "TH"; //Heart
                    karo = "TD"; //Diamonds
                    sinek = "TC"; //Clubs
                    maca = "TS"; //Spades
                    full.Add(kupa, i);
                    full.Add(karo, i);
                    full.Add(sinek, i);
                    full.Add(maca, i);

                }
                if (i == 11)
                {
                    kupa = "JH"; //Heart
                    karo = "JD"; //Diamonds
                    sinek = "JC"; //Clubs
                    maca = "JS"; //Spades
                    full.Add(kupa, i);
                    full.Add(karo, i);
                    full.Add(sinek, i);
                    full.Add(maca, i);

                }
                if (i == 12)
                {
                    kupa = "QH"; //Heart
                    karo = "QD"; //Diamonds
                    sinek = "QC"; //Clubs
                    maca = "QS"; //Spades
                    full.Add(kupa, i);
                    full.Add(karo, i);
                    full.Add(sinek, i);
                    full.Add(maca, i);

                }
                if (i == 13)
                {
                    kupa = "KH"; //Heart
                    karo = "KD"; //Diamonds
                    sinek = "KC"; //Clubs
                    maca = "KS"; //Spades
                    full.Add(kupa, i);
                    full.Add(karo, i);
                    full.Add(sinek, i);
                    full.Add(maca, i);
                }
                if (i == 14)
                {
                    kupa = "AH"; //Heart
                    karo = "AD"; //Diamonds
                    sinek = "AC"; //Clubs
                    maca = "AS"; //Spades
                    full.Add(kupa, i);
                    full.Add(karo, i);
                    full.Add(sinek, i);
                    full.Add(maca, i);
                }
                if (i < 10)
                {
                    kupa = i + "H"; //Heart
                    karo = i + "D"; //Diamonds
                    sinek = i + "C"; //Clubs
                    maca = i + "S"; //Spades
                    full.Add(kupa, i);
                    full.Add(karo, i);
                    full.Add(sinek, i);
                    full.Add(maca, i);
                }

            }
        }
    }
}

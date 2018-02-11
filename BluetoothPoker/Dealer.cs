using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace BluetoothPoker
{
    class Dealer

    {
        Dictionary<string, int> full = new Dictionary<string, int>();
        Dictionary<string, int> left = new Dictionary<string, int>();

        public Dealer()
        {
            string kupa; //Heart
            string karo; //Diamonds
            string sinek; //Clubs
            string maca; //Spades

            for (int i = 2; i < 15; i++)
            {
                if (i == 10)
                {
                    kupa = "10H"; //Heart
                    karo = "10D"; //Diamonds
                    sinek = "10C"; //Clubs
                    maca = "10S"; //Spades
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
            for (int i = 0; i < full.Count; i++)
            {
                left.Add(full.Keys.ElementAt(i), full.Values.ElementAt(i));
            }
        }
        public Dictionary<string, int> allcards()
        {
            return this.full;
        }
        public string getcard()
        {
            Random num = new Random();
            Thread.SpinWait(10000000);
            string card = left.Keys.ElementAt(num.Next(left.Count)).ToString();
            left.Remove(card);
            return card;
        }
        public void resetcards()
        {
            left.Clear();
            for (int i = 0; i < full.Count; i++)
            {
                left.Add(full.Keys.ElementAt(i), full.Values.ElementAt(i));
            }
        }
    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluetoothPoker
{
    class Deste52
    {
       
        public Deste52()
        {
            Dictionary<string, int> full = new Dictionary<string, int>();
            string kupa; //Heart
            string karo; //Diamonds
            string sinek; //Clubs
            string maca; //Spades
            for (int i = 2; i < 14; i++)
            {
                if (i==10)
                {
                    kupa = "TH"; //Heart
                    karo = "TD"; //Diamonds
                    sinek = "TC"; //Clubs
                    maca = "TS"; //Spades
                }
                if (i == 11)
                {
                    kupa = "JH"; //Heart
                    karo = "JD"; //Diamonds
                    sinek = "JC"; //Clubs
                    maca = "JS"; //Spades

                }
                if (i == 12)
                {
                    kupa = "JH"; //Heart
                    karo = "JD"; //Diamonds
                    sinek = "JC"; //Clubs
                    maca = "JS"; //Spades

                }
                if (i == 13)
                {
                    kupa = "JH"; //Heart
                    karo = "JD"; //Diamonds
                    sinek = "JC"; //Clubs
                    maca = "JS"; //Spades
                }
                if (i < 10)
                {
                    kupa = i + "H"; //Heart
                    karo = i + "D"; //Diamonds
                    sinek = i + "C"; //Clubs
                    maca = i + "S"; //Spades
                }
                
            }
        }
    }
}

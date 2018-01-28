using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluetoothPoker
{
    class WinningRules
    {
        public WinningRules() { }

        public int HighCard(List<string> el)
        {
            return 0;
        }
        public Tuple<bool, int, int> OnePair(List<string> el, int level = 1)
        {
            return new Tuple<bool, int, int>(false, 0, level);
        }
        public Tuple<bool, int, int,int> TwoPair(List<string> el, int level=2)
        {
            return new Tuple<bool, int, int, int>(false, 0, 1, level);
        }
        public Tuple<bool, int,int> ThreeofaKind(List<string> el, int level=3)
        {
            return new Tuple<bool, int,int>(false, 0,level);
        }
        public Tuple<bool, int, int> Straight(List<string> el, int level=4)
        {
            return new Tuple<bool, int, int>(false, 0,level);
        }
        public Tuple<bool, int, int> Flush(List<string> el, int level=5)
        {
            return new Tuple<bool, int, int>(false, 0, level); //return with highest Value
        }
        public Tuple<bool, int, int, int> FullHouse(List<string> el, int level=6)
        {
            if (TwoPair(el).Item1 == true && ThreeofaKind(el).Item1 == true)
            {
                return new Tuple<bool, int, int, int>(true, 3, 2, level);
            }
            return new Tuple<bool, int, int, int>(false, 0, 0, level);
        }
        public Tuple<bool, int, int, int> FourofaKİnd(List<string> el, int level=7)
        {
                return new Tuple<bool, int, int, int>(true, 3, 2, level);
        }
        public Tuple<bool, int, int> StraightFlush(List<string> el, int level = 8)
        {
            if (Straight(el).Item1 == true && Flush(el).Item1 == true)
            {
                return new Tuple<bool, int, int>(true, 3, level);
            }
            return new Tuple<bool, int, int>(false, 0, level);
        }
        public Tuple<bool, int, int> RoyalFlush(List<string> el, int level = 9)
        {
            if (Straight(el).Item1 == true && Flush(el).Item1 == true)
            {
                return new Tuple<bool, int, int>(true, 3, level);
            }
            return new Tuple<bool, int, int>(false, 0, level);
        }
    }
}

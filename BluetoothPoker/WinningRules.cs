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
        public Tuple<bool, int, int> isOnePair(List<string> el, int level = 1)
        {
            return new Tuple<bool, int, int>(false, 0, level);
        }
        public Tuple<bool, int, int,int> isTwoPair(List<string> el, int level=2)
        {
            return new Tuple<bool, int, int, int>(false, 0, 1, level);
        }
        public Tuple<bool, int,int> isThreeofaKind(List<string> el, int level=3)
        {
            return new Tuple<bool, int,int>(false, 0,level);
        }
        public Tuple<bool, int, int> isStraight(List<string> el, int level=4)
        {
            return new Tuple<bool, int, int>(false, 0,level);
        }
        public Tuple<bool, int, int> isFlush(List<string> el, int level=5)
        {
            return new Tuple<bool, int, int>(false, 0, level); //return with highest Value
        }
        public Tuple<bool, int, int, int> isFullHouse(List<string> el, int level=6)
        {
            if (isTwoPair(el).Item1 == true && isThreeofaKind(el).Item1 == true)
            {
                return new Tuple<bool, int, int, int>(true, 3, 2, level);
            }
            return new Tuple<bool, int, int, int>(false, 0, 0, level);
        }
        public Tuple<bool, int, int, int> isFourofaKind(List<string> el, int level=7)
        {
                return new Tuple<bool, int, int, int>(true, 3, 2, level);
        }
        public Tuple<bool, int, int> isStraightFlush(List<string> el, int level = 8)
        {
            if (isStraight(el).Item1 == true && isFlush(el).Item1 == true)
            {
                return new Tuple<bool, int, int>(true, 3, level);
            }
            return new Tuple<bool, int, int>(false, 0, level);
        }
        public Tuple<bool, int, int> isRoyalFlush(List<string> el, int level = 9)
        {
            if (isStraight(el).Item1 == true && isFlush(el).Item1 == true)
            {
                return new Tuple<bool, int, int>(true, 3, level);
            }
            return new Tuple<bool, int, int>(false, 0, level);
        }
    }
}

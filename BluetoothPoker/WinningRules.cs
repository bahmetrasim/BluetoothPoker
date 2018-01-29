using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluetoothPoker
{
    class WinningRules
    {
        Dictionary<string, int> cards52 = new Dictionary<string, int>();

        public WinningRules() { }
        public WinningRules(Dictionary<string, int> cards52)
        {
            this.cards52 = cards52;
        }

        public Tuple<int, int> HighTwo(List<string> left)
        {
            List<int> valueslist = new List<int>();
            foreach (var cards in left)
            {
                valueslist.Add(cards52[cards]);
            }
            valueslist.Sort();
            return new Tuple<int, int>(valueslist[valueslist.Count - 1], valueslist[valueslist.Count - 2]);
        }
        public int HighCard(List<string> el)
        {
            return 0;
        }
        public Tuple<bool, int, int, int ,int> isOnePair(List<string> el, int level = 1)
        {
            el.Sort();
            for (int i = 0; i < el.Count - 1; i++)
            {
                if (cards52[el[i]] == cards52[el[i + 1]])
                {
                    string paircard = el[i];
                    el.Remove(el[i]);
                    el.Remove(el[i]);                    
                    return new Tuple<bool, int, int, int, int>(true, cards52[paircard], level, HighTwo(el).Item1, HighTwo(el).Item2);
                }
            }
            return new Tuple<bool, int, int, int, int>(false, 0, level, 0, 0);
        }
        public Tuple<bool, int, int, int> isTwoPair(List<string> el, int level = 2)
        {
            return new Tuple<bool, int, int, int>(false, 0, 1, level);
        }
        public Tuple<bool, int, int> isThreeofaKind(List<string> el, int level = 3)
        {
            el.Sort();
            for (int i = 0; i < el.Count - 2; i++)
            {
                if (el[i].Substring(0, 1) == el[i + 1].Substring(0, 1) && el[i].Substring(0, 1) == el[i + 2].Substring(0, 1))
                {
                    return new Tuple<bool, int, int>(true, int.Parse(el[i].Substring(0, 1)), level);
                }
            }
            return new Tuple<bool, int, int>(false, 0, level);
        }
        public Tuple<bool, int, int> isStraight(List<string> el, int level = 4)
        {
            // Dictionary'den Value'lere ihtiyaç var
            el.Sort();
            int check = 0;
            for (int i = 0; i < el.Count - 1; i++)
            {
                if (int.Parse(el[i].Substring(0, 1)) == int.Parse(el[i + 1].Substring(0, 1)) - 1)
                {
                    check++;
                }
            }
            if (check == 4)
            {
                return new Tuple<bool, int, int>(true, int.Parse(el[0].Substring(0, 1)), level);
            }
            else
            {
                return new Tuple<bool, int, int>(false, 0, level);
            }
        }
        public Tuple<bool, int, int> isFlush(List<string> el, int level = 5)
        {
            return new Tuple<bool, int, int>(false, 0, level); //return with highest Value
        }
        public Tuple<bool, int, int, int> isFullHouse(List<string> el, int level = 6)
        {
            if (isTwoPair(el).Item1 == true && isThreeofaKind(el).Item1 == true)
            {
                return new Tuple<bool, int, int, int>(true, 3, 2, level);
            }
            return new Tuple<bool, int, int, int>(false, 0, 0, level);
        }
        public Tuple<bool, int, int> isFourofaKind(List<string> el, int level = 7)
        {
            el.Sort();
            for (int i = 0; i < el.Count - 3; i++)
            {
                if (el[i].Substring(0, 1) == el[i + 1].Substring(0, 1) && el[i].Substring(0, 1) == el[i + 2].Substring(0, 1) && el[i].Substring(0, 1) == el[i + 3].Substring(0, 1))
                {
                    return new Tuple<bool, int, int>(true, int.Parse(el[0].Substring(0, 1)), level);
                }
            }

            return new Tuple<bool, int, int>(true, 3, level);
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

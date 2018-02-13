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
        public Tuple<bool, List<string>, int> isOnePair(List<string> el, int level = 1)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < el.Count - 1; i++)
            {
                if (cards52[el[i]] == cards52[el[i + 1]])
                {
                    if (temp.Count == 0)
                    {
                        temp.Add(el[i]);
                        temp.Add(el[i + 1]);
                    }
                    else { temp.Add(el[i + 1]); }
                }
            }
            if (temp.Count == 2)
            {
                temp.AddRange(removedublicates(el).GetRange(0, 3));
                return new Tuple<bool, List<string>, int>(true, temp, level);
            }

            return new Tuple<bool, List<string>, int>(false, el.GetRange(0, 5), level);
        } //ok
        public Tuple<bool, List<string>, int> isTwoPair(List<string> el, int level = 2) 
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < el.Count - 1; i++)
            {
                if (cards52[el[i]] == cards52[el[i + 1]])
                {
                    if (temp.Count == 0)
                    {
                        temp.Add(el[i]);
                        temp.Add(el[i + 1]);
                    }
                    else { temp.Add(el[i + 1]); }
                }
            }
            if (temp.Count == 4 && cards52[temp[1]] != cards52[temp[3]])
            {
                temp.AddRange(removedublicates(el).GetRange(0, 1));
                return new Tuple<bool, List<string>, int>(true, temp, level);
            }
            return new Tuple<bool, List<string>, int>(false, el.GetRange(0, 5), level);
        }  ////Eğer temp count 6 olursa yani 3 pair varsa en büyük ikisini al
        public Tuple<bool, List<string>, int> isThreeofaKind(List<string> el, int level = 3)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < el.Count - 2; i++)
            {
                if (cards52[el[i]] == cards52[el[i + 1]] && cards52[el[i]] == cards52[el[i + 2]])
                {
                    temp.AddRange(el.GetRange(i, 3));
                    temp.AddRange(removedublicates(el).GetRange(0, 2));
                    return new Tuple<bool, List<string>, int>(true, temp, level);
                }
            }
            return new Tuple<bool, List<string>, int>(false, el.GetRange(0, 5), level);
        }  //Eğer temp count 6 olursa yani 2 pair varsa en büyük ikisini al
        public Tuple<bool, List<string>, int> isStraight(List<string> el, int level = 4)
        {
            // Dictionary'den Value'lere ihtiyaç var
            List<string> temp = new List<string>();
            el = removedublicates(el);
            for (int i = 0; i < el.Count - 1; i++)
            {
                if (cards52[el[i]] == cards52[el[i + 1]] + 1)
                {
                    if (temp.Count == 0)
                    {
                        temp.Add(el[i]);
                        temp.Add(el[i + 1]);
                    }
                    else { temp.Add(el[i + 1]); }
                }
                else { temp.Clear(); }
            }
            if (temp.Count > 4)
            {
                return new Tuple<bool, List<string>, int>(true, temp.GetRange(0, 5), level);
            }
            return new Tuple<bool, List<string>, int>(false, el.GetRange(0, 5), level);

        } //ok
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
        public Tuple<bool, List<string>, int> isFourofaKind(List<string> el, int level = 7)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < el.Count - 2; i++)
            {
                if (cards52[el[i]] == cards52[el[i + 1]] && cards52[el[i]] == cards52[el[i + 2]] && cards52[el[i]] == cards52[el[i + 3]])
                {
                    temp.AddRange(el.GetRange(i, 4));
                    temp.AddRange(removedublicates(el).GetRange(0, 1));
                    return new Tuple<bool, List<string>, int>(true, temp, level);
                }
            }
            return new Tuple<bool, List<string>, int>(false, el.GetRange(0, 5), level);
        }  //OK Kontrol Et
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
        public List<string> removedublicates(List<string> el)
        {
            for (int i = 0; i < el.Count - 1; i++)
            {
                for (int j = i + 1; j < el.Count; j++)
                {
                    if (cards52[el[i]] == cards52[el[j]])
                    {
                        el.RemoveAt(j);
                    }
                }
            }
            return el;
        }
        public List<string> removedublicateall(List<string> el)
        {
            for (int i = 0; i < el.Count - 1; i++)
            {
                    if (cards52[el[i]] == cards52[el[i+1]])
                    {
                        el.RemoveAt(i+1);
                    }
            }
            return el;
        }

    }
}

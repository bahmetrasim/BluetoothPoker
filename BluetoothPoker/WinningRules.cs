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
        Dictionary<int, string> levels = new Dictionary<int, string>();
        public WinningRules()
        {
            levels.Add(0, "High Card");
            levels.Add(1, "One Pair");
            levels.Add(2, "Two Pair");
            levels.Add(3, "Three of a Kind");
            levels.Add(4, "Straight");
            levels.Add(5, "Flush");
            levels.Add(6, "Full House");
            levels.Add(7, "Four of a Kind");
            levels.Add(8, "Straight Flush");
            levels.Add(9, "Royal Flush");

        }
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
        public List<string> HighCard(List<string> el)
        {
            return el.GetRange(0, 5);
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
            if (temp.Count == 6 && cards52[temp[1]] != cards52[temp[3]] && cards52[temp[3]] != cards52[temp[5]])
            {
                temp.RemoveRange(4, 2);
                SortbyDic(removepairs(el, cards52[temp[1]], cards52[temp[3]]));
                temp.AddRange(el.GetRange(0, 3));
                return new Tuple<bool, List<string>, int>(true, temp, level);
            }
            else if (temp.Count == 4 && cards52[temp[1]] != cards52[temp[3]])
            {
                temp.RemoveRange(2, 4);
                SortbyDic(removepairs(el, cards52[temp[1]], cards52[temp[3]]));
                temp.AddRange(el.GetRange(0, 3));
                return new Tuple<bool, List<string>, int>(true, temp, level);
            }
            else if (temp.Count == 2)
            {
                SortbyDic(removepairs(el, cards52[temp[1]]));
                temp.AddRange(el.GetRange(0, 3));
                return new Tuple<bool, List<string>, int>(true, temp, level);
            }

            return new Tuple<bool, List<string>, int>(false, el, level);
        } //ok
        public Tuple<bool, List<string>, int> isTwoPair(List<string> el, int level = 2)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < el.Count - 1; i++)
            {
                if (cards52[el[i]] == cards52[el[i + 1]])
                {
                    temp.Add(el[i]);
                    temp.Add(el[i + 1]);
                    i++;
                }
            }
            if (temp.Count == 6 && cards52[temp[1]] != cards52[temp[3]] && cards52[temp[3]] != cards52[temp[5]])
            {
                temp.RemoveRange(4, 2);
                SortbyDic(removepairs(el, cards52[temp[1]], cards52[temp[3]]));
                temp.AddRange(removedublicateall(el).GetRange(0, 1));
                return new Tuple<bool, List<string>, int>(true, temp, level);
            }
            else if (temp.Count == 4 && cards52[temp[1]] != cards52[temp[3]])
            {
                SortbyDic(removepairs(el, cards52[temp[1]], cards52[temp[3]]));
                temp.AddRange(el.GetRange(0, 1));
                return new Tuple<bool, List<string>, int>(true, temp, level);
            }
            return new Tuple<bool, List<string>, int>(false, el, level);
        }  ////Eğer temp count 6 olursa yani 3 pair varsa en büyük ikisini al
        public Tuple<bool, List<string>, int> isThreeofaKind(List<string> el, int level = 3)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < el.Count - 2; i++)
            {
                if (cards52[el[i]] == cards52[el[i + 1]] && cards52[el[i]] == cards52[el[i + 2]])
                {
                    temp.AddRange(el.GetRange(i, 3));
                    SortbyDic(removepairs(el, cards52[el[i]]));
                    temp.AddRange(el.GetRange(0, 2));
                    return new Tuple<bool, List<string>, int>(true, temp, level);
                }
            }
            return new Tuple<bool, List<string>, int>(false, el, level);
        }  //Eğer temp count 6 olursa yani 2 pair varsa en büyük ikisini al
        public Tuple<bool, List<string>, int> isStraight(List<string> el, int level = 4)
        {
            // Dictionary'den Value'lere ihtiyaç var
            List<string> temp = new List<string>();
            List<string> el1 = new List<string>();
            el1.AddRange(el);
            removedublicates(el1);
            for (int i = 0; i < el1.Count - 1; i++)
            {
                if (cards52[el1[i]] == cards52[el1[i + 1]] + 1)
                {
                    if (temp.Count == 0)
                    {
                        temp.Add(el1[i]);
                        temp.Add(el1[i + 1]);
                    }
                    else { temp.Add(el1[i + 1]); }
                }
                else { temp.Clear(); }
            }
            if (temp.Count > 4)
            {
                return new Tuple<bool, List<string>, int>(true, temp.GetRange(0, 5), level);
            }
            return new Tuple<bool, List<string>, int>(false, el, level);

        } //OK
        public Tuple<bool, List<string>, int> isFlush(List<string> el, int level = 5)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < el.Count; i++)
            {
                temp.Add(el[i].Substring(el[i].Length - 1));
            }
            for (int i = 0; i < 3; i++)
            {
                if ((temp.Count(suits => suits == temp[i])) >= 5)
                {
                    string suit = temp[i];
                    temp.Clear();
                    for (int j = 0; j < el.Count; j++)
                    {
                        if (el[j].Substring(el[j].Length - 1) == suit)
                        {
                            temp.Add(el[j]);
                            temp = SortbyDic(temp);
                            if (temp.Count > 5)
                            {
                                temp.RemoveRange(5, temp.Count - 5);
                            }
                        }
                    }
                    return new Tuple<bool, List<string>, int>(true, temp, level);
                }
            }

            return new Tuple<bool, List<string>, int>(false, new List<string>(), level);
        } // OK
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
            for (int i = 0; i < el.Count - 3; i++)
            {
                if (cards52[el[i]] == cards52[el[i + 1]] && cards52[el[i]] == cards52[el[i + 2]] && cards52[el[i]] == cards52[el[i + 3]])
                {
                    temp.AddRange(el.GetRange(i, 4));
                    SortbyDic(removepairs(el, cards52[el[i]]));
                    temp.AddRange(el.GetRange(0, 1));
                    return new Tuple<bool, List<string>, int>(true, temp, level);
                }
            }
            return new Tuple<bool, List<string>, int>(false, el, level);
        }  //OK Kontrol Et
        public Tuple<bool, List<string>, int> isStraightFlush(List<string> el, int level = 8)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < el.Count; i++)
            {
                temp.Add(el[i].Substring(el[i].Length - 1));
            }
            for (int i = 0; i < 3; i++)
            {
                if ((temp.Count(suits => suits == temp[i])) >= 5)
                {
                    string suit = temp[i];
                    temp.Clear();
                    for (int j = 0; j < el.Count; j++)
                    {
                        if (el[j].Substring(el[j].Length - 1) == suit)
                        {
                            temp.Add(el[j]);
                            temp = SortbyDic(temp);
                            for (int k = 0; k < temp.Count - 4; k++)
                            {
                                if (cards52[temp[k]] == cards52[temp[k + 1]] + 1 &&
                                cards52[temp[k + 1]] == cards52[temp[k + 2]] + 1 &&
                                cards52[temp[k + 2]] == cards52[temp[k + 3]] + 1 &&
                                cards52[temp[k + 3]] == cards52[temp[k + 4]] + 1)

                                {
                                    return new Tuple<bool, List<string>, int>(true, temp.GetRange(k,5), level);
                                }
                            }
                        }
                    }
                    
                }
            }

            return new Tuple<bool, List<string>, int>(false, new List<string>(), level);
        } // OK
        public Tuple<bool, List<string>, int> isRoyalFlush(List<string> el, int level = 9)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < el.Count; i++)
            {
                temp.Add(el[i].Substring(el[i].Length - 1));
            }
            for (int i = 0; i < 3; i++)
            {
                if ((temp.Count(suits => suits == temp[i])) >= 5)
                {
                    string suit = temp[i];
                    temp.Clear();
                    for (int j = 0; j < el.Count; j++)
                    {
                        if (el[j].Substring(el[j].Length - 1) == suit)
                        {
                            temp.Add(el[j]);
                            temp = SortbyDic(temp);
                            for (int k = 0; k < temp.Count - 4; k++)
                            {
                                if (cards52[temp[k]] == cards52[temp[k + 1]] + 1 &&
                                cards52[temp[k + 1]] == cards52[temp[k + 2]] + 1 &&
                                cards52[temp[k + 2]] == cards52[temp[k + 3]] + 1 &&
                                cards52[temp[k + 3]] == cards52[temp[k + 4]] + 1 &&
                                cards52[temp[k]] == 14)

                                {
                                    return new Tuple<bool, List<string>, int>(true, temp.GetRange(k, 5), level);
                                }
                            }
                        }
                    }

                }
            }

            return new Tuple<bool, List<string>, int>(false, new List<string>(), level);
        } // OK
        public List<string> removedublicates(List<string> del)
        {
            for (int i = 0; i < del.Count - 1; i++)
            {
                for (int j = i + 1; j < del.Count; j++)
                {
                    if (cards52[del[i]] == cards52[del[j]])
                    {
                        del.RemoveAt(j);
                    }
                }
            }
            return del;
        }
        public List<string> removedublicateall(List<string> el)
        {
            for (int i = 0; i < el.Count - 1; i++)
            {
                int count = 0;
                for (int j = i + 1; j < el.Count; j++)
                {
                    if (cards52[el[i]] == cards52[el[j]])
                    {
                        el.Remove(el[j]);
                        count++;
                    }
                }
                if (count != 0)
                {
                    el.Remove(el[i]);
                    i--;
                }
            }
            return el;
        }
        public List<string> removepairs(List<string> del, int a, int b = 0)
        {
            for (int i = 0; i < del.Count; i++)
            {
                if (cards52[del[i]] == a || cards52[del[i]] == b)
                {
                    del.Remove(del[i]);
                    i--;
                }
            }
            return del;
        }
        public List<string> SortbyDic(List<string> list)
        {
            Dictionary<string, int> temp = new Dictionary<string, int>();

            for (int i = 0; i < list.Count; i++)
            {
                temp.Add(list[i], cards52[list[i]]);
            }
            //list.Clear();
            // Denenecek
            temp = temp.OrderByDescending(u => u.Value).ToDictionary(z => z.Key, y => y.Value);

            return temp.Keys.ToList();
            //foreach (KeyValuePair<string, int> sort in temp.OrderByDescending(key => key.Value))
            //{
            //   list.Add(sort.Key);
            //}
            //return list;

        }
        public string getwinnerlevel(int level)
        {
            string name = levels[level];
            return name;
        }
    }
}

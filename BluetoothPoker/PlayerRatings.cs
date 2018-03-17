using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluetoothPoker
{
    class PlayerRatings
    {
        Dictionary<string, int> cards52 = new Dictionary<string, int>();
        List<List<string>> allplayers = new List<List<string>>();
        WinningRules status = new WinningRules();
        Dictionary<List<string>, int> PlayersDic = new Dictionary<List<string>, int>();
        Tuple<List<string>, int>[] PlayerTuple = new Tuple<List<string>, int>[8];

        public PlayerRatings() { }

        public PlayerRatings(Dictionary<string, int> cards52, List<List<string>> allplayers)
        {
            this.allplayers = allplayers;
            this.cards52 = cards52;
            status = new WinningRules(this.cards52);
        }
        public string Compare(Dictionary<string, List<string>> comparelist)
        {
            List<Tuple<string, List<string>, int>> compare = new List<Tuple<string, List<string>, int>>();

            for (int i = 0; i < comparelist.Count; i++)
            {
                int value = cards52[comparelist.Values.ElementAt(i).First()];
                compare.Add(new Tuple<string, List<string>, int>(comparelist.Keys.ElementAt(i), comparelist.Values.ElementAt(i), value));
            }
            var tupleListSorted = from thing in compare
                                  orderby thing.Item3
                                  select thing;
            List<Tuple<string, List<string>, int>> comparesorted = new List<Tuple<string, List<string>, int>>();
            foreach (var tupleThing in tupleListSorted)
            {
                comparesorted.Add(tupleThing);
            }
            if (comparesorted[comparesorted.Count - 1].Item3 == comparesorted[comparesorted.Count - 2].Item3)
            {
                for (int i = 0; i < comparesorted.Count; i++)
                {
                    if (comparesorted[i].Item3 != comparesorted[comparesorted.Count - 1].Item3)
                    {
                        comparesorted.RemoveAt(i);
                        i--;
                    }
                }
                if (comparesorted.Count == 2)
                {
                    int i = 0;
                    do
                    {
                        i++;
                        if (i ==5)
                        {
                            return comparesorted[0].Item1 + " and " + comparesorted[1].Item1;
                        }
                    }
                    while (cards52[comparesorted[0].Item2.ElementAt(i)] == cards52[comparesorted[1].Item2.ElementAt(i)]);
                    if (cards52[comparesorted[0].Item2.ElementAt(i)] > cards52[comparesorted[1].Item2.ElementAt(i)])
                        return comparesorted[0].Item1;
                    else
                        return comparesorted[1].Item1;
                }
                else
                {
                    return "player1";
                }
            }
            else
            {
                return comparesorted[comparelist.Count - 1].Item1;
            }
        }
        public Dictionary<List<string>, int> PlayerCardswithTable()
        {
            for (int i = 0; i < 8; i++)
            {
                if (allplayers[i].Count > 0)
                {
                    allplayers[i].AddRange(allplayers[8]);
                    PlayerTuple[i] = BestofFive(allplayers[i]);
                    allplayers[i] = PlayerTuple[i].Item1;
                    PlayersDic.Add(allplayers[i], PlayerTuple[i].Item2);
                }
                else
                {
                    allplayers[i] = allplayers[8];
                }
            }
            return PlayersDic;
        }
        public Tuple<List<string>, int> BestofFive(List<string> player)
        {
            player = SortbyDic(player);
            Tuple<bool, List<string>, int> RoyalFlush = new Tuple<bool, List<string>, int>(false, new List<string>(), 0);
            Tuple<bool, List<string>, int> StraightFlush = new Tuple<bool, List<string>, int>(false, new List<string>(), 0);
            Tuple<bool, List<string>, int> FourofaKind = new Tuple<bool, List<string>, int>(false, new List<string>(), 0);
            Tuple<bool, List<string>, int> FullHouse = new Tuple<bool, List<string>, int>(false, new List<string>(), 0);
            Tuple<bool, List<string>, int> Flush = new Tuple<bool, List<string>, int>(false, new List<string>(), 0);
            Tuple<bool, List<string>, int> Straight = new Tuple<bool, List<string>, int>(false, new List<string>(), 0);
            Tuple<bool, List<string>, int> ThreeofaKind = new Tuple<bool, List<string>, int>(false, new List<string>(), 0);
            Tuple<bool, List<string>, int> TwoPair = new Tuple<bool, List<string>, int>(false, new List<string>(), 0);
            Tuple<bool, List<string>, int> OnePair = new Tuple<bool, List<string>, int>(false, new List<string>(), 0);

            RoyalFlush = status.isRoyalFlush(player);
            if (RoyalFlush.Item1) { return new Tuple<List<string>, int>(RoyalFlush.Item2, RoyalFlush.Item3); }
            StraightFlush = status.isStraightFlush(player);
            if (StraightFlush.Item1) { return new Tuple<List<string>, int>(StraightFlush.Item2, StraightFlush.Item3); }
            FourofaKind = status.isFourofaKind(player);
            if (FourofaKind.Item1) { return new Tuple<List<string>, int>(FourofaKind.Item2, FourofaKind.Item3); }
            //FullHouse = status.isFullHouse(player);
            //if (FullHouse.Item1) { break; }
            Flush = status.isFlush(player);
            if (Flush.Item1) { return new Tuple<List<string>, int>(Flush.Item2, Flush.Item3); }
            Straight = status.isStraight(player);
            if (Straight.Item1)
            { return new Tuple<List<string>, int>(Straight.Item2, Straight.Item3); }
            ThreeofaKind = status.isThreeofaKind(player);
            if (ThreeofaKind.Item1) { return new Tuple<List<string>, int>(ThreeofaKind.Item2, ThreeofaKind.Item3); }
            TwoPair = status.isTwoPair(player);
            if (TwoPair.Item1) { return new Tuple<List<string>, int>(TwoPair.Item2, TwoPair.Item3); }
            OnePair = status.isOnePair(player);
            if (OnePair.Item1) { return new Tuple<List<string>, int>(OnePair.Item2, OnePair.Item3); }
            else
            {
                return new Tuple<List<string>, int>(status.HighCard(player), 0);
            }
        }
        public List<string> SortbyDic(List<string> list)
        {
            Dictionary<string, int> temp = new Dictionary<string, int>();
            for (int i = 0; i < list.Count; i++)
            {
                temp.Add(list[i], cards52[list[i]]);
            }
            temp = temp.OrderByDescending(u => u.Value).ToDictionary(z => z.Key, y => y.Value);
            return temp.Keys.ToList();
        }
        public Dictionary<List<string>, int> sortdic(Dictionary<List<string>, int> winner)
        {
            return winner.OrderByDescending(u => u.Value).ToDictionary(z => z.Key, y => y.Value);
        }
    }
}

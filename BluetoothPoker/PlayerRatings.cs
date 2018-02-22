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
        public string Compare()
        {
            List<string> abc = new List<string>(new string[] { "ahmet", "hüso" });
            //playerresult(abc);
            return "player1";
        }
        public void PlayerCardswithTable()
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
        }
        //public Tuple<int, int, int, int, int> playerresult(List<string> players)
        //{ //1.int level, 2. int başlangıç 3.int ve two pair ve full house için, 4 int kalan en büyük

        //    List<Tuple<int, int, int, int, int>> onlytrue = new List<Tuple<int, int, int, int, int>>();
        //    WinningRules status = new WinningRules(cards52);
        //    Tuple<bool, int, int, int, int> revalue = status.isOnePair(players);
        //    if (revalue.Item1 == true)
        //    {

        //        onlytrue.Add(new Tuple<int, int, int, int, int>(revalue.Item3, revalue.Item2, revalue.Item4, revalue.Item5, 0));
        //    }

        //    status.isTwoPair(players);
        //    status.isThreeofaKind(players);
        //    status.isStraight(players);
        //    status.isFlush(players);
        //    status.isFullHouse(players);
        //    status.isFourofaKind(players);
        //    status.isStraightFlush(players);
        //    status.isRoyalFlush(players);

        //    return new Tuple<int, int, int, int, int>(3, 2, 10, 12, 13);
        //}
        public Tuple <List<string>, int> BestofFive(List<string> player)
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
            
                //RoyalFlush = status.isRoyalFlush(player);
                //if (RoyalFlush.Item1){ break; }
                //StraightFlush = status.isStraightFlush(player);
                //if (StraightFlush.Item1) { break; }
                FourofaKind = status.isFourofaKind(player);
                if (FourofaKind.Item1) { return new Tuple<List<string>, int>(FourofaKind.Item2, FourofaKind.Item3); }
                //FullHouse = status.isFullHouse(player);
                //if (FullHouse.Item1) { break; }
                //Flush = status.isFlush(player);
                //if (Flush.Item1) { break; }
                Straight = status.isStraight(player);
                if (Straight.Item1) { return new Tuple<List<string>, int>(Straight.Item2, Straight.Item3); }
                ThreeofaKind  = status.isThreeofaKind(player);
                if (ThreeofaKind.Item1) { return new Tuple<List<string>, int>(ThreeofaKind.Item2, ThreeofaKind.Item3); }
                TwoPair = status.isTwoPair(player);
                if (TwoPair.Item1) { return new Tuple<List<string>, int>(TwoPair.Item2, TwoPair.Item3); }
                OnePair = status.isOnePair(player);
                if (OnePair.Item1) { return new Tuple<List<string>, int>(OnePair.Item2, OnePair.Item3); }

            //if (status.isRoyalFlush(player).Item1)
            //{
            //    return new Tuple<List<string>, int>(status.isStraight(player).Item2, status.isStraight(player).Item3);
            //}
            //else if (status.isStraightFlush(player).Item1)
            //{
            //    return new Tuple<List<string>, int>(status.isStraight(player).Item2, status.isStraight(player).Item3);
            //}
            //if (FourofaKind.Item1)
            //{
            //    return new Tuple<List<string>, int>(FourofaKind.Item2, FourofaKind.Item3);
            //}
            //else if (status.isFullHouse(player).Item1)
            //{
            //    return new Tuple<List<string>, int>(status.isStraight(player).Item2, status.isStraight(player).Item3);
            //}
            //else if (status.isFlush(player).Item1)
            //{
            //    return new Tuple<List<string>, int>(status.isStraight(player).Item2, status.isStraight(player).Item3);
            //}
            //else if (Straight.Item1) //OK
            //{
            //    return new Tuple<List<string>, int>(Straight.Item2, Straight.Item3);
            //}
            //else if (ThreeofaKind.Item1)
            //{
            //    return new Tuple<List<string>, int>(ThreeofaKind.Item2, ThreeofaKind.Item3);
            //}
            //else if (TwoPair.Item1)
            //{
            //    return new Tuple<List<string>, int>(TwoPair.Item2, TwoPair.Item3);
            //}
            //else if (OnePair.Item1) 
            //{
            //    return new Tuple<List<string>, int>(OnePair.Item2, OnePair.Item3);
            //}
            else
            {
                return new Tuple<List<string>, int>(status.HighCard(player), 0);
            }
        }
        public List<string> SortbyDic (List<string> list)
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
        public void playerstatus(int index, List<string> players, int level)
        {
           
            PlayersDic.Add(players, level);
        }
    }
}

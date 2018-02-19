﻿using System;
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
        Dictionary<List<string>, int>[] PlayerDic = new Dictionary<List<string>, int>[8];


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
                    allplayers[i] = BestofFive(allplayers[i]).Item1;
                    PlayerDic[i] = new Dictionary<List<string>, int>();
                    PlayerDic[i].Add(allplayers[i], BestofFive(allplayers[i]).Item2);
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
            Tuple<bool, List<string>, int> RoyalFlush = status.isRoyalFlush(player);
            Tuple<bool, List<string>, int> StraightFlush = status.isStraightFlush(player);
            Tuple<bool, List<string>, int> FourofaKind = status.isFourofaKind(player);
            Tuple<bool, List<string>, int> FullHouse = status.isFullHouse(player);
            Tuple<bool, List<string>, int> isFlush = status.isFlush(player);
            Tuple<bool, List<string>, int> Straight = status.isStraight(player);
            Tuple<bool, List<string>, int> ThreeofaKind  = status.isThreeofaKind(player);
            Tuple<bool, List<string>, int> TwoPair = status.isTwoPair(player);
            Tuple<bool, List<string>, int> OnePair = status.isOnePair(player);

            //if (status.isRoyalFlush(player).Item1)
            //{
            //    return new Tuple<List<string>, int>(status.isStraight(player).Item2, status.isStraight(player).Item3);
            //}
            //else if (status.isStraightFlush(player).Item1)
            //{
            //    return new Tuple<List<string>, int>(status.isStraight(player).Item2, status.isStraight(player).Item3);
            //}
            if (status.isFourofaKind(player).Item1)
            {
                return new Tuple<List<string>, int>(status.isFourofaKind(player).Item2, status.isFourofaKind(player).Item3);
            }
            //else if (status.isFullHouse(player).Item1)
            //{
            //    return new Tuple<List<string>, int>(status.isStraight(player).Item2, status.isStraight(player).Item3);
            //}
            //else if (status.isFlush(player).Item1)
            //{
            //    return new Tuple<List<string>, int>(status.isStraight(player).Item2, status.isStraight(player).Item3);
            //}
            else if (status.isStraight(player).Item1) //OK
            {
                return new Tuple<List<string>, int>(status.isStraight(player).Item2, status.isStraight(player).Item3);
            }
            else if (status.isThreeofaKind(player).Item1)
            {
                return new Tuple<List<string>, int>(status.isThreeofaKind(player).Item2, status.isThreeofaKind(player).Item3);
            }
            else if (status.isTwoPair(player).Item1)
            {
                return new Tuple<List<string>, int>(status.isTwoPair(player).Item2, status.isTwoPair(player).Item3);
            }
            else if (status.isOnePair(player).Item1) 
            {
                return new Tuple<List<string>, int>(status.isOnePair(player).Item2, status.isOnePair(player).Item3);
            }
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
           
            PlayerDic[index].Add(players, level);
        }
    }
}

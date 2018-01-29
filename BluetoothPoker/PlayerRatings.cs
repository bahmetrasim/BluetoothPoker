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
        List<string> Player1 = new List<string>();
        List<string> Player2 = new List<string>();
        public PlayerRatings() { }
        public PlayerRatings(Dictionary<string, int> cards52, List<string> player1, List<string> player2)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            this.cards52 = cards52;
        }
        public string Compare()
        {
            playerresult(Player1);
            return "player1";
        }
        public Tuple<int, int, int, int, int> playerresult(List<string> players)
        { //1.int level, 2. int başlangıç 3.int ve two pair ve full house için, 4 int kalan en büyük
            List<Tuple<int, int, int, int, int>> onlytrue = new List<Tuple<int, int, int, int, int>>();
            WinningRules status = new WinningRules(cards52);
            Tuple<bool, int, int, int, int> revalue = status.isOnePair(players);
            if (revalue.Item1 == true)
            {
                   
                onlytrue.Add(new Tuple<int, int, int, int, int>(revalue.Item3, revalue.Item2, revalue.Item4, revalue.Item5, 0));
            }

            status.isTwoPair(players);
            status.isThreeofaKind(players);
            status.isStraight(players);
            status.isFlush(players);
            status.isFullHouse(players);
            status.isFourofaKind(players);
            status.isStraightFlush(players);
            status.isRoyalFlush(players);

            return new Tuple<int, int, int, int, int>(3, 2, 10, 12, 13);
        }
    }
}
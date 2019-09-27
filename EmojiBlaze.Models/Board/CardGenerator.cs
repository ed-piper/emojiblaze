using System;
using System.Collections.Generic;
using System.Linq;
using EmojiBlaze.Models.Store.Game;

namespace EmojiBlaze.Models.Board
{
    public class CardGenerator : ICardGenerator
    {
        public List<Card> GenerateCards(int lengthWidth) {
            var randomizedCards = RandomizeCards(GeneratePairs(lengthWidth));
            var pairIdx = 0;
            for (var x = 0; x < lengthWidth; x++)
            {
                for (var y = 0; y < lengthWidth; y++)
                {
                    randomizedCards[pairIdx].SetCardPosition(x, y);
                    pairIdx++;
                }
            }
            return randomizedCards;
        }

        private List<Card> GeneratePairs(int lengthWidth) {
            var numberOfCards = lengthWidth * lengthWidth;
            var cardList = new List<Card>();
            var cardSymbolIdx = 0;

            for (var i = 0; i < numberOfCards; i += 2) {

                cardList.Add(new Card(CardSymbols[cardSymbolIdx]));
                cardList.Add(new Card(CardSymbols[cardSymbolIdx]));

                if (cardSymbolIdx < CardSymbols.Count - 1) {
                    cardSymbolIdx++;
                    continue;
                }
                cardSymbolIdx = 0;
            }
            return cardList;
        }

        private List<Card> RandomizeCards(List<Card> cards) {
            var rnd = new Random();
            return cards.OrderBy(x => rnd.Next()).ToList();
        }

        private List<string> CardSymbols => new List<string> {"🐯","🦁","🦓","🦒","🐴","🐮","🐷","🐻","🐼","🐲","🦄"};

    }
}
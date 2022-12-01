using System.Collections.Generic;
using System.Linq;

namespace Winner.Validations
{
    public class PlayingCardValidation
    {

        public static string PlayingCardsValidation(string[] playingCards)
        {
            var errorMessage = string.Empty;
            if (IsCorrectPlayingCardCount(playingCards).Count > 25)
            {
                return "Too many PlayingCards";
            }
            else if (IsCorrectPlayingCardCount(playingCards).Count < 25)
            {
                return "PlayingCards should be five per player";
            }
            else if (!IsPlayCardCorrectValues(playingCards))
            {
                return "Please ensure that playing cards are in correct format eg. 3C";
            }

            else if (IsDuplicatedCards(playingCards).Count() > 0)
            {
                return "Please ensure that playing cards are not the same";
            }

            return errorMessage;
        }

        private static List<string> IsCorrectPlayingCardCount(string[] playingCards)
        {
            var cards = new List<string>();
            for (int i = 0; i < playingCards.Length; i++)
            {
                var card = playingCards[i].Substring(playingCards[i].LastIndexOf(':') + 1).Split(',');
                for (int j = 0; j < card.Length; j++)
                {
                    cards.Add(card[j]);
                }
            }

            return cards;
        }

        private static bool IsPlayCardCorrectValues(string[] playingCards)
        {
            var correctFormat = true;
            for (int i = 0; i < playingCards.Length; i++)
            {
                var card = playingCards[i].Substring(playingCards[i].LastIndexOf(':') + 1).Split(',');
                for (int j = 0; j < card.Length; j++)
                {
                    if (card[j].Substring(0, card[j].Length - 1).Length > 1 && card[j].Substring(0, card[j].Length - 1).Length > 3)
                        return correctFormat = false;
                }
            }

            return correctFormat;
        }

        private static IEnumerable<string> IsDuplicatedCards(string[] playingCards)
        {
            var cards = new List<string>();
            for (int i = 0; i < playingCards.Length; i++)
            {
                var card = playingCards[i].Substring(playingCards[i].LastIndexOf(':') + 1).Split(',');
                for (int j = 0; j < card.Length; j++)
                {
                    cards.Add(card[j]);
                }
            }
            return cards.GroupBy(x => x).Where(g => g.Count() > 1).Select(x => x.Key);

        }

        ////private static bool IsCardSuit(string[] playingCards)
        ////{
        ////    var correctFormat = true;
        ////    for (int i = 0; i < playingCards.Length; i++)
        ////    {
        ////        var card = playingCards[i].Substring(playingCards[i].LastIndexOf(':') + 1).Split(',');
        ////        for (int j = 0; j < card.Length; j++)
        ////        {
        ////            var nn = card[j].Substring(0, card[j].Length - 1);
        ////            if (card[j].Substring(0, card[j].Length - 1).Length > 1 && card[j].Substring(0, card[j].Length - 1).Length > 3)
        ////                return correctFormat = false;
        ////        }
        ////    }

        ////    return correctFormat;
        ////}
    }
}

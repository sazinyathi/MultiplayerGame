using System.Collections.Generic;
using System.Threading.Tasks;
using Winner.Interface;
using Winner.Models;

namespace Winner.Repository
{
    public class DisplayCardScore : IPlayingCardScore
    {
        public async Task<List<PlayingCardScore>> DisplayCardAsync(string[] playingCards)
        {
            var playCards = new List<PlayingCardScore>();
            foreach (var item in playingCards)
            {
                var PlayingCardScore = new Models.PlayingCardScore();
                PlayingCardScore.Name = $"{item.Substring(0, item.LastIndexOf(':'))}";
                var cards =  item.Substring(item.LastIndexOf(':') + 1).Split(',');
                for (int i = 0; i < cards.Length; i++)
                {
                    var playCardTotal = SumPlayingCards(cards[i]);
                    PlayingCardTotals(i, playCardTotal, PlayingCardScore);
                }

                playCards.Add(PlayingCardScore);
            }
            return playCards;
        }

        private static int SumPlayingCards(string card)
        {
            var cardValue = card.ToCharArray();
            return Face.GetFace(cardValue[0].ToString()) + Suit.GetSuit(cardValue[1].ToString());
        }

        private static PlayingCardScore PlayingCardTotals(int index, int playingCardTotal, Models.PlayingCardScore playingScore)
        {
            
            if (index == 0)
            {
                playingScore.CardOneTotal = playingCardTotal;
                playingScore.TotalCardScore = playingScore.TotalCardScore + playingCardTotal;
            }
            else if (index == 1)
            {
                playingScore.CardTwoTotal = playingCardTotal;
                playingScore.TotalCardScore = playingScore.TotalCardScore + playingCardTotal;
            }
            else if (index == 2)
            {
                playingScore.CardThreeTotal = playingCardTotal;
                playingScore.TotalCardScore = playingScore.TotalCardScore + playingCardTotal;
            }
            else if (index == 3)
            {
                playingScore.CardFourTotal = playingCardTotal;
                playingScore.TotalCardScore = playingScore.TotalCardScore + playingCardTotal;
            }
            else if (index == 4)
            {
                playingScore.CardFiveTotal = playingCardTotal;
                playingScore.TotalCardScore = playingScore.TotalCardScore + playingCardTotal;
            }

            return playingScore;
        }
    }
}

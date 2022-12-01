using System.Collections.Generic;
using System.Linq;

namespace Winner
{
    public class ValidatePlayers
    {
        
        public static string ValidatePlayer(string[] playingCards)
        {
            var errorMessage = string.Empty;

            if (!IsPlayerNameHasColon(playingCards))
            {
                return "Please ensure that player Name are ended with colon";
            }

            else if(PlayerNames(playingCards).All(s => string.IsNullOrWhiteSpace(s)))
            {
                return "Please ensure that player Name are added";
            }
            else if (IsCorrectPlayersCount(playingCards).Count > 5)
            {
                return "Please ensure that player name are not more five";
            }

            else if (IsCorrectPlayersCount(playingCards).Count < 5)
            {
                return "Five players are required";
            }

            else if (IsDuplicatedPlayers(playingCards).Count() > 0)
            {
                return "Duplicate players Name";
            }

            return errorMessage;
        }

        private static List<string> IsCorrectPlayersCount(string[] playingCards)
        {
            var players = new List<string>();
            for (int i = 0; i < playingCards.Length; i++)
            {
                var names = $"{playingCards[i].Substring(0, playingCards[i].LastIndexOf(':'))}";
                players.Add(names);

            }
            return players;
        }
                  


        private static IEnumerable<string> IsDuplicatedPlayers(string[] playingCards)
        {
            var players = new List<string>();
            for (int i = 0; i < playingCards.Length; i++)
            {
                var names = $"{playingCards[i].Substring(0, playingCards[i].LastIndexOf(':'))}";
                players.Add(names);

            }
           return players.GroupBy(x => x).Where(g => g.Count() > 1).Select(x => x.Key);

        }

        private static List<string> PlayerNames(string[] playingCards)
        {
            var players = new List<string>();
            for (int i = 0; i < playingCards.Length; i++)
            {
                var names = $"{playingCards[i].Substring(0, playingCards[i].LastIndexOf(':'))}";
                players.Add(names);

            }
            return players;
        }


        private static bool IsPlayerNameHasColon(string[] playingCards)
        {
            var result = true;
            for (int i = 0; i < playingCards.Length; i++)
            {
                if (!playingCards[i].Contains(':'))
                {
                    result = false;
                    break;
                }
                
            }
            return result;
        }
    }
}

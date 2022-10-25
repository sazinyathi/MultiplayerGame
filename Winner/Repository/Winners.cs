using System.Collections.Generic;
using System.Threading.Tasks;
using Winner.Interface;
using Winner.Models;
using System.Linq;

namespace Winner.Repository
{
    public class Winners : IWinner
    {
        public async Task<string> WinnerAsync(List<PlayingCardScore> playingCardScore)
        {
            var highestScore = playingCardScore.Max(r => r.TotalCardScore);
            var names = string.Join(",", playingCardScore.Where(x => x.TotalCardScore == highestScore).Select(x => x.Name).ToList());
            return $"{names} : {highestScore}";

        }
    }
}

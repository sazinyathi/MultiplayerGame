using System.Collections.Generic;
using System.Threading.Tasks;
using Winner.Models;

namespace Winner.Interface
{
    public interface IPlayingCardScore
    {
        Task<List<PlayingCardScore>> DisplayCardAsync(string[] playingCards);
    }
}

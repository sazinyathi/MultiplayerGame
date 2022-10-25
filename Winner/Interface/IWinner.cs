using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winner.Models;

namespace Winner.Interface
{
    public interface IWinner
    {
        Task<string> WinnerAsync(List<PlayingCardScore> playingCardScore);
    }
}

using System;
using Winner.Interface;
using Winner.Repository;

namespace Winner
{

    class Program
    {
        private  static readonly IInputFile _inputFile = new PlayersTable() ;
        private  static readonly IPlayingCardScore _playingCardScore = new DisplayCardScore();
        private  static readonly IWinner _winner = new Winners();
       

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("*******************STARTING *******************************");
                var fileName = "abc.txt";
                
                var playingCards = _inputFile.ReadInputFileAsync(fileName);

                var scores = _playingCardScore.DisplayCardAsync(playingCards.Result);
                var result = _winner.WinnerAsync(scores.Result);

                _inputFile.WriteToFileAsync(result.Result);

                Console.WriteLine("*******************END APPLICATION ************************");
                Console.ReadLine();
            }
            catch (Exception)
            {
                _inputFile.WriteToFileAsync("ERROR");
                
            }
            
        }

        
    }

}

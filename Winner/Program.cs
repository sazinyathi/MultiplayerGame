using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Winner.Interface;
using Winner.Models;
using Winner.Repository;
using Winner.Validations;

namespace Winner
{

    class Program
    {
        private static readonly IInputFile _inputFile = new PlayersTable();
        private static readonly IPlayingCardScore _playingCardScore = new DisplayCardScore();
        private static readonly IWinner _winner = new Winners();

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("*******************STARTING *******************************");

                var fileConfigaration = ReadAppSetting();

                var fileValidation = FileValidation.ValidateFile(fileConfigaration.InputFiles);

                if (!string.IsNullOrEmpty(fileValidation))
                {
                    Console.WriteLine(fileValidation);
                    return;
                }

                var tableDesk = _inputFile.ReadInputFile(fileConfigaration.InputFiles);

                var inputValidation = InputValidation.ValidateInputs(tableDesk);
                if (!string.IsNullOrEmpty(inputValidation))
                {
                    Console.WriteLine(inputValidation);
                    return;
                }

                var validatePlayers = ValidatePlayers.ValidatePlayer(tableDesk);
                if (!string.IsNullOrEmpty(validatePlayers))
                {
                    Console.WriteLine(validatePlayers);
                    return;
                }

                var validatePlayingCards = PlayingCardValidation.PlayingCardsValidation(tableDesk);
                if (!string.IsNullOrEmpty(validatePlayingCards))
                {
                    Console.WriteLine(validatePlayingCards);
                    return;
                }

                var scores = _playingCardScore.DisplayCardAsync(tableDesk);
                var result = _winner.WinnerAsync(scores.Result);

                _inputFile.WriteToFileAsync(result.Result, fileConfigaration.OutFiles);

                Console.WriteLine("*******************END APPLICATION ************************");
                Console.ReadLine();
            }
            catch (Exception)
            {
                var fileConfigaration = ReadAppSetting();
                _inputFile.WriteToFileAsync("ERROR", fileConfigaration.OutFiles);

            }

        }



        private static FileConfigaration ReadAppSetting()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();
            var section = config.GetSection(nameof(FileConfigaration));
            return section.Get<FileConfigaration>();
        }
    }


}

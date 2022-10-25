using System;
using System.IO;
using System.Threading.Tasks;
using Winner.Interface;

namespace Winner.Repository
{
    public class PlayersTable : IInputFile
    {
        private string outPutFile = "xyz.txt";
        public async Task<string[]> ReadInputFileAsync(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                string cards = await reader.ReadToEndAsync();
                return cards.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            }
        }

        public async Task WriteToFileAsync(string message)
        {
            using (var file = new System.IO.StreamWriter(outPutFile))
            {
                await file.WriteLineAsync(message);
            }
        }
    }
}


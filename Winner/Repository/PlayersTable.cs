using System;
using System.IO;
using System.Threading.Tasks;
using Winner.Interface;

namespace Winner.Repository
{
    public class PlayersTable : IInputFile
    {
        public string[] ReadInputFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                string cards = reader.ReadToEnd().Trim();
                return cards.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            }
        }

        public async Task WriteToFileAsync(string message, string path)
        {
            using (var file = new System.IO.StreamWriter(path))
            {
                await file.WriteLineAsync(message);
            }
        }
    }
}


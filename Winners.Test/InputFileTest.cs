using NUnit.Framework;
using Winner.Repository;

namespace Winners.Test
{
    public class InputFileTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async void ReadInputFile_ExpectedFivePlayers_FivePlayingCards()
        {
            var fileName = "InputFile.txt";
            var model = new PlayersTable();
            model.ReadInputFile(fileName);
            Assert.Pass();
        }
    }
}
using System.Threading.Tasks;

namespace Winner.Interface
{
    public interface IInputFile
    {
        string [] ReadInputFile(string fileName);
        Task WriteToFileAsync(string message, string path);
    }
}

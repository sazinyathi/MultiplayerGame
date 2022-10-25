using System.Threading.Tasks;

namespace Winner.Interface
{
    public interface IInputFile
    {
        Task<string []> ReadInputFileAsync(string fileName);
        Task WriteToFileAsync(string message);
    }
}

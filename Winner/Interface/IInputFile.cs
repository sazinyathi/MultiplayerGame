using System.Collections.Generic;
using System.Threading.Tasks;
using Winner.Models;

namespace Winner.Interface
{
    public interface IInputFile
    {
        Task<string []> ReadInputFileAsync(string fileName);
        Task WriteToFileAsync(string message);
    }
}

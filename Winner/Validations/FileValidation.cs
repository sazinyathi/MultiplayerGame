using System.IO;

namespace Winner
{
    public class FileValidation
    {

        public static string ValidateFile(string fileName)
        {
            var message = string.Empty;
            if (!MissingTextFile(fileName))
            {
                return "Please ensure that file exists";
            }
            else if (string.IsNullOrEmpty(IsTextFileEmpty(fileName)))
            {
                return "Please ensure that Names and PlayCards are entered";
            }
            return message;
        }

        private static string IsTextFileEmpty(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
              return reader.ReadToEnd().Trim();
              
            }
        }

        private static bool MissingTextFile(string fileName)
        {
            return (!File.Exists(fileName)) ? false : true;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyTools;

namespace FileData
{
    public class FileManager : IFileManager
    {
        private readonly FileDetails _fileDetails;
        public FileManager()
        {
            _fileDetails = new FileDetails();
        }
        public bool UpdateFileData(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("Null arguments passed.");
            }
            if (args.Count() < 2)
            {
                throw new ArgumentException("Invalid arguments passed.");
            }

            string command = args[0], filePath = args[1];

            ValidateArguments(command, filePath);

            if (Entities.Versions.Contains(command.ToLower()))
            {
                Console.WriteLine("Version updated : {0}", _fileDetails.Version(filePath));
                return true;
            }

            if (Entities.Sizes.Contains(command.ToLower()))
            {
                Console.WriteLine("Size updated : {0}", _fileDetails.Size(filePath));
                return true;
            }

            return false;
        }

        private static void ValidateArguments(string command, string filePath)
        {
            if (command == null)
            {
                throw new ArgumentNullException("Command can not be null.");
            }

            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path can not be null or blank.");
            }
        }
    }

    public interface IFileManager
    {
        bool UpdateFileData(string[] args);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;
using LoggerLib;

namespace FileData
{
    public static class Program
    {

        public static void Main(string[] args)
        {
            IFileManager fileManager = new FileManager();
            ILogger logger = new Logger();
            try
            {
                logger.LogInfo("Command execution started.");
                if(fileManager.UpdateFileData(args))
                {
                    logger.LogSuccess("Command executed successfully.");
                }
                else
                {
                    logger.LogFailure("Opps.., something went wrong");
                }
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                logger.LogInfo("Command execution completed.");
                Console.ReadKey();
            }
        }
    }
}

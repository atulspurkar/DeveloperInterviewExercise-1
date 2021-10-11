using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData
{
    public class Entities
    {
        //Entities that contains list of versions, sizes commands, that application going to handle.
        private static string[] _versions = new string[] { "-v", "--v", "/v", "--version" };
        public static string[] Versions
        {
            get
            {
                return _versions;
            }
        }

        private static string[] _sizes = new string[] { "-s", "--s", "/s", "--size" };
        public static string[] Sizes
        {
            get
            {
                return _sizes;
            }
        }
    }
}

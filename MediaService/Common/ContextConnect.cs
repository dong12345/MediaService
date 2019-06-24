using System;
using System.Configuration;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace MediaService.Common
{
    public class ContextConnect
    {
        private static string _connstr_unittest = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        private static string _connstr_stable = ConfigurationManager.ConnectionStrings["connstr_stable"].ConnectionString;

        public static string ReadConnstrContent()
        {
            string result = string.Empty;
            string path = @"./env";
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                result = line;
                break;
            }

            var _sql = result.Equals("unittest") ? _connstr_unittest : _connstr_stable;
            return _sql;
        }
    }
}

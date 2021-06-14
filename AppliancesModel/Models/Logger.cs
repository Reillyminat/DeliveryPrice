using AppliancesModel.Contracts;
using System;
using System.IO;

namespace AppliancesModel
{
    public class Logger : ILogger
    {
        private readonly StreamWriter streamWriter;

        public Logger()
        {
            streamWriter = new StreamWriter("Log - " + DateTime.Now.ToShortDateString().Replace('/','.') + ".txt", true);
            streamWriter.WriteLine("Session started at " + DateTime.Now.ToLongTimeString());
        }

        public void AddLog(string data)
        {
            streamWriter.WriteLine(data + " at " + DateTime.Now.ToLongTimeString());
        }

        public void Dispose()
        {
            streamWriter.WriteLine();
            streamWriter.Dispose();
        }
    }
}
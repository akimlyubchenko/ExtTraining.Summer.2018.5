using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public abstract class Logger
    {
        private readonly string filePath = "log.txt";
        public virtual void Log(string message)
        {
            StreamWriter file = new StreamWriter(filePath, true);
            file.WriteLine(message + "\t\t\t" + DateTime.Now.ToLocalTime());
            file.Close();
        }

    }
}

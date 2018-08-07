using System;
using System.IO;
using System.Windows.Forms;

namespace No8.Solution.Printers
{
    public abstract class Printer
    {
        public string Name { get; private set; }
        public string Model { get; private set; }

        protected Printer(string name, string model)
        {
            Name = name ?? throw new ArgumentNullException("Fill name");
            Model = model ?? throw new ArgumentNullException("Fill model");
        }

        public virtual void Print()
        {
            var o = new OpenFileDialog();
            o.ShowDialog();
            FileStream fs = File.OpenRead(o.FileName);
            for (int i = 0; i < fs.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fs.ReadByte());
            }
        }
    }
}

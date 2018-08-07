using No8.Solution.Printers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace No8.Solution
{
    public class PrinterManager : Logger
    {
        // не хватало времени сделать грамотное событие
        public delegate void PrinterDelegate(PrinterManager pm,  string arg);
        public event PrinterDelegate OnPrinted;
        public List<Printer> Printers = new List<Printer>();

        public void Add(Printer p1)
        {
            if (!Printers.Contains(p1))
            {
                Printers.Add(p1);
                Log("Printer added");
            }
            else
            {
                Log("Printer has already been added");
            }

        }

        public void Create(string name, string model)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Fill note name");
            }

            if (string.IsNullOrEmpty(model))
            {
                throw new ArgumentException("Fill note model");
            }

            var printerType = GetPrinterType(name);
            if (printerType != null)
            {
                Add((Printer)Activator.CreateInstance(printerType, model));
            }
            else
            {
                Add(new CustomPrinter(name, model));
            }

            //Log($"Printer {printerType.GetType()} was added");
        }

        public void Remove(Printer p)
        {
            Printers.Remove(p);
            Log($"Remove {p.Name}\t{p.Model}");
        }

        public void Print(Printer p1)
        {
            Log("Print started");
            p1.Print();
            Log("Print finished");
            OnPrinted(this, "Print finished (c)OnPrinted");
        }

        public Printer GetPrinter(string name, string model)
        {
            for (int i = 0; i < Printers.Count; i++)
            {
                if (Printers[i].Name == name && Printers[i].Model == model)
                {
                    return Printers[i];
                }
            }

            return null;
        }

        public void ShowPrinters()
        {

        }

        private bool Contains(Printer p)
        {
            for (int i = 0; i < Printers.Count; i++)
            {
                if (Printers[i].Name == p.Name && Printers[i].Model == p.Model)
                {
                    return true;
                }
            }

            return false;
        }

        private Type GetPrinterType(string name)
        {
            for (int i = 0; i < Printers.Count; i++)
            {
                if (Printers[i].Name == name)
                {
                    return Printers[i].GetType();
                }
            }

            return null;
        }
    }
}

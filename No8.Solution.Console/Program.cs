using No8.Solution.Printers;
using System;
namespace No8.Solution.Console
{
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            PrinterManager pm = new PrinterManager();
            pm.OnPrinted += OnPrinted;
            pm.Create("myPrinter", "QWERT");
            EpsonPrinter ep = new EpsonPrinter("asdfg");
            CanonPrinter cp = new CanonPrinter("tukufgxcd");
            pm.Add(ep);
            pm.Add(cp);

            while (true)
            {
                System.Console.WriteLine("Select your choice:");
                System.Console.WriteLine("1:Add new printer");
                System.Console.WriteLine("2:Remove printer");
                System.Console.WriteLine("3:Show printers");
                System.Console.WriteLine("Esc to exit");

                var key = System.Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    string name = CreateTask("Write name");
                    pm.Create(name, CreateTask("Write model"));
                }

                if (key.Key == ConsoleKey.D2)
                {
                    string name = CreateTask("Write name");
                    pm.Remove(pm.GetPrinter(name, CreateTask("Write model")));
                }

                if (key.Key == ConsoleKey.D3)
                {
                    ShowPrintersSection(pm);
                }

                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }

            }

            pm.Log("\n\n");
        }

        private static void OnPrinted(PrinterManager pm, string str)
        {
            System.Console.WriteLine(str);
            pm.Log(str);
            
        }

        private static string CreateTask(string str)
        {
            System.Console.Clear();
            System.Console.WriteLine(str);
            return System.Console.ReadLine();
        }

        private static void ShowPrintersSection(PrinterManager pm)
        {
            System.Console.WriteLine("Select your choice:");
            for (int i = 1; i < pm.Printers.Count + 1; i++)
            {
                System.Console.WriteLine($"{i}. {pm.Printers[i - 1].Name}\t{pm.Printers[i - 1].Model}");
            }

            System.Console.WriteLine("Esc to previous step");

            var key = System.Console.ReadKey();

            if (key.Key == ConsoleKey.Escape)
            {
                return;
            }

            if (key.Key == ConsoleKey.D1)
            {
                pm.Print(pm.Printers[0]);
            }

            if (key.Key == ConsoleKey.D2)
            {
                pm.Print(pm.Printers[1]);
            }

            if (key.Key == ConsoleKey.D3)
            {
                pm.Print(pm.Printers[2]);
            }

            if (key.Key == ConsoleKey.D4)
            {
                pm.Print(pm.Printers[3]);
            }

            //не успевал подумать об этом блоке
        }
    }
}

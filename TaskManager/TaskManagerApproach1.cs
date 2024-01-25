using System;
using System.IO;


namespace TaskManagerBugFixes
{
    public class Printer
    {

        public void Print(string path)
        {
            System.Console.WriteLine($"Printing .....{path}");
        }
    }

    public class Scanner
    {

        public void Scan(string path)
        {
            System.Console.WriteLine($"Scanning .....{path}");
        }
    }

    public class PrintScanner   
    {
        public void Print(string path)
        {
            System.Console.WriteLine($"Printing .....{path}");
        }

        public void Scan(string path)
        {
            System.Console.WriteLine($"Scanning .....{path}");
        }
    }
    public static class TaskManager
    {
        public static void ExecuctePrintTask(Printer printer, string documentPath)
        {
            printer.Print(documentPath);
        }
        public static void ExecucteScanTask(Scanner scanner, string documentPath)
        {
            scanner.Scan(documentPath);
        }
        public static void ExecuctePrintTask(PrintScanner printer, string documentPath)
        {
            printer.Print(documentPath);
        }
        public static void ExecucteScanTask(PrintScanner scanner, string documentPath)
        {
            scanner.Scan(documentPath);
        }
    }

    public class Program
    {
        static void Main()
        {
            Printer printerObj = new Printer();
            Scanner scannerObj = new Scanner();
            PrintScanner printScannerObj = new PrintScanner();

            TaskManager.ExecuctePrintTask(printerObj, "Test.doc");
            TaskManager.ExecucteScanTask(scannerObj, "MyImage.png");
            TaskManager.ExecuctePrintTask(printScannerObj, "NewDoc.doc");
            TaskManager.ExecucteScanTask(printScannerObj, "YourImage.png");

            Console.ReadKey();
        }
    }
}

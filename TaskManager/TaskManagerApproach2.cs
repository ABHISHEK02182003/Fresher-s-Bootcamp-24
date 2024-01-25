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
    private readonly Printer printer;
    private readonly Scanner scanner;

    public PrintScanner(Printer printer, Scanner scanner)
    {
        this.printer = printer;
        this.scanner = scanner;
    }

    public void Print(string path)
    {
        printer.Print(path);
    }

    public void Scan(string path)
    {
        scanner.Scan(path);
    }
}

public static class TaskManager
{
    public static void ExecutePrintTask(Printer printer, string documentPath)
    {
        printer.Print(documentPath);
    }

    public static void ExecuteScanTask(Scanner scanner, string documentPath)
    {
        scanner.Scan(documentPath);
    }

    public static void ExecutePrintTask(PrintScanner printScanner, string documentPath)
    {
        printScanner.Print(documentPath);
    }

    public static void ExecuteScanTask(PrintScanner printScanner, string documentPath)
    {
        printScanner.Scan(documentPath);
    }
}

public class Program
{
    static void Main()
    {
        Printer printerObj = new Printer();
        Scanner scannerObj = new Scanner();
        PrintScanner printScannerObj = new PrintScanner(printerObj, scannerObj);

        TaskManager.ExecutePrintTask(printerObj, "Test.doc");
        TaskManager.ExecuteScanTask(scannerObj, "MyImage.png");
        TaskManager.ExecutePrintTask(printScannerObj, "NewDoc.doc");
        TaskManager.ExecuteScanTask(printScannerObj, "YourImage.png");
    }
}

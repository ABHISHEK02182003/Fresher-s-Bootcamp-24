using System;
using System.Reflection;
using Xunit;

public class CsvDataExample
{
    [Theory]
    [CsvData("path/to/testdata.csv", hasHeaders: true)]
    public void CsvTestMethod(int id, string name, double value)
    {
        // Your test logic using the provided parameters
        Console.WriteLine($"Test Method: id={id}, name={name}, value={value}");
        // Assert or perform other test actions
    }

    public static void Main(string[] args)
    {
        // Discover and run tests using xUnit test framework
        Xunit.Runner.RunAllTests(Assembly.GetExecutingAssembly().Location);
    }
}

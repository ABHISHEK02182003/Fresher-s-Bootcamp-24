# CSV Data Attribute Example

This is a simple example demonstrating the usage of a custom CSV data attribute for parameterized testing in C# with xUnit.

## CsvDataAttribute

The `CsvDataAttribute` is a custom attribute that allows you to provide test data for parameterized tests in xUnit from a CSV file.

### Usage

Apply the `CsvDataAttribute` to a test method, specifying the path to the CSV file and whether it has headers:

```csharp
[Theory]
[CsvData("path/to/testdata.csv", hasHeaders: true)]
public void CsvTestMethod(int id, string name, double value)
{
    // Your test logic using the provided parameters
    Console.WriteLine($"Test Method: id={id}, name={name}, value={value}");
    // Assert or perform other test actions
}
```
## How to Run

1. Ensure you have [.NET Core SDK](https://dotnet.microsoft.com/download) installed.
2. Install the required packages:

    ```bash
    dotnet add package xunit --version 2.4.1
    dotnet add package xunit.runner.console --version 2.4.1
    ```

3. Replace `"path/to/testdata.csv"` in `CsvTestMethod` with the actual path to your CSV file.
4. Run the program:

    ```bash
    dotnet run
    ```

This will discover and execute the tests, printing the output of the `CsvTestMethod` with values from the CSV file.

Feel free to customize the CSV file path and test logic according to your specific use case.
```

You can copy and paste this content into a `README.md` file in your project repository. Customize it further based on your specific requirements and add more sections as needed.

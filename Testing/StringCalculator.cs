public interface IInputValidator
{
    void ValidateInput(string numbers);
}

public interface IDelimiterProvider
{
    char[] GetDelimiters(string numbers);
}

public interface INumberParser
{
    int[] ParseNumbers(string numbers);
}

public interface INegativeNumberChecker
{
    void CheckForNegativeNumbers(int[] numbers);
}

public class InputValidator : IInputValidator
{
    public void ValidateInput(string numbers)
    {
        if (numbers.EndsWith(",") || numbers.EndsWith("\n"))
        {
            throw new ArgumentException("Invalid input: Trailing comma or newline");
        }
    }
}

public class DelimiterProvider : IDelimiterProvider
{
    public char[] GetDelimiters(string numbers)
    {
        char[] defaultDelimiters = { ',', '\n' };

        if (numbers.StartsWith("//"))
        {
            return GetCustomDelimiters(numbers);
        }

        return defaultDelimiters;
    }

    private char[] GetCustomDelimiters(string numbers)
    {
        int delimiterStartIndex = numbers.IndexOf("[") + 1;
        int delimiterEndIndex = numbers.IndexOf("]");

        if (delimiterStartIndex > 0 && delimiterEndIndex > delimiterStartIndex)
        {
            string customDelimiterSection = numbers.Substring(delimiterStartIndex, delimiterEndIndex - delimiterStartIndex);
            return customDelimiterSection.ToCharArray();
        }

        // If no valid custom delimiters are found, you can return a default delimiter
        return new char[] { ';' }; // You can replace this with the default delimiter of your choice
    }
}

public class NumberParser : INumberParser
{
    public int[] ParseNumbers(string numbers)
    {
        string numbersSection = GetNumbersSection(numbers);
        return numbersSection.Split(GetDelimiters(numbers), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }

    private char[] GetDelimiters(string numbers)
    {
        return new DelimiterProvider().GetDelimiters(numbers);
    }

    private string GetNumbersSection(string numbers)
    {
        if (numbers.StartsWith("//"))
            return numbers.Substring(numbers.IndexOf('\n') + 1);

        return numbers;
    }
}

public class NegativeNumberChecker : INegativeNumberChecker
{
    public void CheckForNegativeNumbers(int[] numbers)
    {
        var negativeNumbers = numbers.Where(x => x < 0).ToList();

        if (negativeNumbers.Any())
        {
            throw new ArgumentException($"Negatives not allowed: ({string.Join(", ", negativeNumbers)})");
        }
    }
}

public static class StringCalculator
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
            return 0;

        new InputValidator().ValidateInput(numbers);
        int[] parsedNumbers = new NumberParser().ParseNumbers(numbers);
        new NegativeNumberChecker().CheckForNegativeNumbers(parsedNumbers);

        return parsedNumbers.Where(x => x <= 1000).Sum();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

public static class StringCalculator
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
            return 0;

        var delimiters = GetDelimiters(numbers);

        var parsedNumbers = ParseNumbers(GetNumbersSection(numbers), delimiters);

        CheckForNegativeNumbers(parsedNumbers);

        return parsedNumbers.Where(x => x <= 1000).Sum();
    }

    private static string GetNumbersSection(string numbers)
    {
        return numbers.StartsWith("//") ? numbers.Substring(numbers.IndexOf('\n') + 1) : numbers;
    }

    private static IEnumerable<int> ParseNumbers(string numbersSection, char[] delimiters)
    {
        return numbersSection
            .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
            .SelectMany(token => token.Split(delimiters, StringSplitOptions.RemoveEmptyEntries))
            .Select(int.Parse);
    }

    private static void CheckForNegativeNumbers(IEnumerable<int> numbers)
    {
        var negativeNumbers = numbers.Where(x => x < 0).ToList();

        if (negativeNumbers.Any())
        {
            throw new ArgumentException($"Negatives not allowed: ({string.Join(", ", negativeNumbers)})");
        }
    }

    private static char[] GetDelimiters(string numbers)
    {
        return numbers.StartsWith("//")
            ? new DelimiterProvider().GetDelimiters(numbers)
            : new char[] { ',', '\n' };
    }
}

public class DelimiterProvider
{
    public char[] GetDelimiters(string numbers)
    {
        return GetCustomDelimiters(numbers);
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

        return new char[] { ';' }; // Default delimiter
    }
}

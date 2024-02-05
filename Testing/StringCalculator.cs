using System;
using System.Collections.Generic;
using System.Linq;

public class StringCalculator
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
            return 0;

        CheckForInvalidInput(numbers);

        char[] delimiters = GetDelimiters(numbers);
        string[] numbersArray = GetNumbersArray(numbers, delimiters);

        CheckForNegativeNumbers(numbersArray);

        return numbersArray.Where(x => int.Parse(x) <= 1000).Sum(x => int.Parse(x));
    }

    private static void CheckForInvalidInput(string numbers)
    {
        if (numbers.EndsWith(",") || numbers.EndsWith("\n"))
        {
            throw new ArgumentException("Invalid input: Trailing comma or newline");
        }
    }

    private static char[] GetDelimiters(string numbers)
    {
        char[] defaultDelimiters = { ',', '\n' };

        if (numbers.StartsWith("//"))
        {
            int delimiterEndIndex = numbers.IndexOf('\n');
            string delimiterSection = numbers.Substring(2, delimiterEndIndex - 2);

            if (delimiterSection.StartsWith("[") && delimiterSection.EndsWith("]"))
            {
                var delimiters = new List<string>(delimiterSection
                    .TrimStart('[')
                    .TrimEnd(']')
                    .Split("]["));

                return delimiters.SelectMany(d => d.ToCharArray()).ToArray();
            }
            else
            {
                return new char[] { delimiterSection[0] };
            }
        }

        return defaultDelimiters;
    }

    private static string[] GetNumbersArray(string numbers, char[] delimiters)
    {
        string numbersSection = numbers;
        if (numbers.StartsWith("//"))
            numbersSection = numbers.Substring(numbers.IndexOf('\n') + 1);

        return numbersSection.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
    }

    private static void CheckForNegativeNumbers(string[] numbersArray)
    {
        var negativeNumbers = numbersArray.Where(x => int.Parse(x) < 0).ToList();

        if (negativeNumbers.Any())
        {
            throw new ArgumentException($"Negatives not allowed: ({string.Join(", ", negativeNumbers)})");
        }
    }
}

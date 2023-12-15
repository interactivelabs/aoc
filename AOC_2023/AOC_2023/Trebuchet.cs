namespace AOC_2023;

public class Trebuchet
{
    public int Run()
    {
        var stringToNumberMap = new Dictionary<string, string>
        {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" }
        };

        string[] substrings = { "1","2","3","4","5","6","7","8","9", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    
        var result = 0;

        // Read from stdin (which is now the file)
        while (Console.ReadLine() is { } input)
        {
            // Process the input here as needed
    
            var firstDigit = substrings
                .Select(substring => new { substring, index = input.IndexOf(substring, StringComparison.Ordinal) })
                .Where(item => item.index != -1).MinBy(item => item.index)?.substring;
    
            var reversedInput = new string(input.Reverse().ToArray());
            var lastDigit = substrings
                .Select(substring => new { substring, index = reversedInput.IndexOf(substring, StringComparison.Ordinal) })
                .Where(item => item.index != -1).MinBy(item => item.index)?.substring;
    
            if (firstDigit != null && lastDigit != null)
            {
        
                if (firstDigit.Length > 1)
                {
                    firstDigit = stringToNumberMap[firstDigit];
                }
        
                if (lastDigit.Length > 1)
                {
                    lastDigit = stringToNumberMap[lastDigit];
                }
        
                var lineDigits = string.Concat(firstDigit, lastDigit);
                var lineNumber = int.Parse(lineDigits);
        
                result += lineNumber;
        
            }
        }

        return result;
    }
}
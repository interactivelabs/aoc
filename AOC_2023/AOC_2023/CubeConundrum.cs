namespace AOC_2023;

public class CubeConundrum
{
    private int _redCubes = 12;
    private int _blueCubes = 14;
    private int _greenCubes = 13;

    public int Run(int? redCubes, int? blueCubes, int? greenCubes)
    {
        _redCubes = redCubes ?? _redCubes;
        _blueCubes = blueCubes ?? _blueCubes;
        _greenCubes = greenCubes ?? _greenCubes;
        
        var result = 0;

        // Read from stdin (which is now the file)
        while (Console.ReadLine() is { } input)
        {
             var values = IsGamePossible(input);
             if (values.isPossible)
             {
                 result += int.Parse(values.gameId);
             }
        }

        return result;
    }
    
    private (string gameId, bool isPossible) IsGamePossible(string input)
    {
        var gameId = input.Split(":")[0].Replace("Game ", "");
        var gameSets = input.Split(":")[1].Split(";");
        var isPossible = gameSets.Select(IsSetPossible).All(possible => possible);
        return (gameId, isPossible);
    }
    
    private bool IsSetPossible(string input)
    {
        var totalCubes = _redCubes + _blueCubes + _greenCubes;
        var setRedCubes = _redCubes;
        var setBlueCubes = _blueCubes;
        var setGreenCubes = _greenCubes;
        
        var shownCubes = input.Split(",").Select(part => part.Trim().Split(" ")).ToList();
        foreach (var colorSet in shownCubes)
        {
            var color = colorSet[1];
            var count = int.Parse(colorSet[0]);
            if (totalCubes < count)
            {
                return false;
            }
            if (color == "red")
            {
                if (setRedCubes < count)
                {
                    return false;
                }
                setRedCubes -= count;
            }
            else if (color == "blue")
            {
                if (setBlueCubes < count)
                {
                    return false;
                }
                setBlueCubes -= count;
            }
            else if (color == "green")
            {
                if (setGreenCubes < count)
                {
                    return false;
                }
                setGreenCubes -= count;
            }
            totalCubes -= count;
        }
        
        return true;
    }
    
    private int MinNumberOfCubes(string input)
    {
        
        var shownCubes = input.Split(",").Select(part => part.Trim().Split(" ")).ToList();
        
        var minRedCubes = 1;
        var minBlueCubes = 1;
        var minGreenCubes = 1;

        foreach (var colorSet in shownCubes)
        {
            var color = colorSet[1];
            var count = int.Parse(colorSet[0]);
            if (color == "red")
            {
                minRedCubes = Math.Max(minRedCubes, count);
            }
            else if (color == "blue")
            {
                minBlueCubes = Math.Max(minBlueCubes, count);
            }
            else if (color == "green")
            {
                minGreenCubes = Math.Max(minGreenCubes, count);
            }
        }
        
        return minBlueCubes * minGreenCubes * minRedCubes;
    }

}
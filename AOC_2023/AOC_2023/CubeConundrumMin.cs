namespace AOC_2023;

public class CubeConundrumMin
{
    
    public int Run()
    {
        
        var result = 0;

        // Read from stdin (which is now the file)
        while (Console.ReadLine() is { } input)
        {
             var power = GetGamePower(input);
 
            result += power;
             
        }

        return result;
    }
    
    private int GetGamePower(string input)
    {
        var minRedCubes = 1;
        var minBlueCubes = 1;
        var minGreenCubes = 1;
        var gameSets = input.Split(":")[1].Split(";");
        foreach (var gameSet in gameSets)
        {
            var minis = MinNumberOfCubes(gameSet);
            minRedCubes = Math.Max(minRedCubes, minis.minRedCubes);
            minBlueCubes = Math.Max(minBlueCubes, minis.minBlueCubes);
            minGreenCubes = Math.Max(minGreenCubes, minis.minGreenCubes);
        }

        return minRedCubes * minBlueCubes * minGreenCubes;
    }
    
    private  (int minRedCubes, int minBlueCubes, int minGreenCubes) MinNumberOfCubes(string input)
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

        return (minRedCubes, minBlueCubes, minGreenCubes);
    }

}
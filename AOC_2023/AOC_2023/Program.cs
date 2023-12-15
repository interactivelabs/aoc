using AOC_2023;

var currentDirectory = Directory.GetCurrentDirectory();

var projectRoot = Directory.GetParent(currentDirectory)?.Parent?.Parent?.FullName;

void RunTrebuchet()
{
    using StreamReader sr = new StreamReader(Path.Combine(projectRoot ?? "", "inputTrebuchet.txt"));
    Console.SetIn(sr);

    using StreamWriter sw = new StreamWriter(Path.Combine(projectRoot ?? "", "outputTrebuchet.txt"));
    Console.SetOut(sw);

    var trebuchet = new Trebuchet();
    var result = trebuchet.Run();

    Console.WriteLine(result.ToString());
}

void RunCubeConundrum()
{
    using StreamReader sr = new StreamReader(Path.Combine(projectRoot ?? "", "inputCubeConundrum.txt"));
    Console.SetIn(sr);

    using StreamWriter sw = new StreamWriter(Path.Combine(projectRoot ?? "", "outputCubeConundrum.txt"));
    Console.SetOut(sw);

    var cubeConundrum = new CubeConundrum();
    var result = cubeConundrum.Run(12, 14, 13);

    // Write to stdout (which is now the file)
    Console.WriteLine(result.ToString());
}

void RunCubeConundrumMin()
{
    using StreamReader sr = new StreamReader(Path.Combine(projectRoot ?? "", "inputCubeConundrum.txt"));
    Console.SetIn(sr);

    using StreamWriter sw = new StreamWriter(Path.Combine(projectRoot ?? "", "outputCubeConundrumMin.txt"));
    Console.SetOut(sw);

    var cubeConundrum = new CubeConundrumMin();
    var result = cubeConundrum.Run();

    // Write to stdout (which is now the file)
    Console.WriteLine(result.ToString());
}

// RunTrebuchet();
// RunCubeConundrum();
RunCubeConundrumMin();
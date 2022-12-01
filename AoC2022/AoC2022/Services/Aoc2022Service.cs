namespace AoC2022.Services;

public class Aoc2022Service : IAoc2022Service
{
    public int AoC001()
    {
        var readText = File.ReadAllLines(@"Inputs/001.txt");
        var allElfs = new List<List<int>>();
        var currentElf = new List<int>();
        foreach (var line in readText)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                allElfs.Add(currentElf);
                currentElf = new List<int>();
                continue;
            }
            currentElf.Add(int.Parse(line));
        }
        if(currentElf.Any())
            allElfs.Add(currentElf);

        var topElf = allElfs.OrderByDescending(x => x.Sum()).FirstOrDefault();

        return topElf?.Sum() ?? 0;
    }
}
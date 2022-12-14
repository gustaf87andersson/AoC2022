namespace AoC2022.Services;

public class Aoc2022Service : IAoc2022Service
{
    public int AoC003a()
    {
        var readText = File.ReadAllLines(@"Inputs/003.txt");
        var score = 0;
        foreach (var line in readText)
        {
            var first = line[..(line.Length / 2)];
            var second = line.Substring((int)(line.Length / 2), (int)(line.Length / 2));

            var existingChars = new List<char>();

            foreach (char item in first)
            {
                if(!second.Contains(item) || existingChars.Contains(item)) continue;
                
                score += item is >= 'A' and <= 'Z' ? item - 64 + 26 : item - 96;
                existingChars.Add(item);
            }
        }
        return score;
    }

    public int AoC003b()
    {
        var readText = File.ReadAllLines(@"Inputs/003.txt");
        var score = 0;
        var currentGroup = new List<string>();
        var existingChars = new List<char>();
        var index = 0;
        foreach (var line in readText)
        {
            currentGroup.Add(line);
            index++;

            if(index % 3 != 0) continue;

            foreach (var item in line)
            {
                if(!currentGroup.All(x => x.Contains(item)) || existingChars.Contains(item)) continue;
                
                score += item is >= 'A' and <= 'Z' ? item - 64 + 26 : item - 96;
                existingChars.Add(item);
            }
            existingChars = new List<char>();
            currentGroup = new List<string>();
        }
        return score;
    }

    public int AoC002b()
    {
        var readText = File.ReadAllLines(@"Inputs/002.txt");
        var totalPoints = 0;
        foreach (var line in readText)
        {
            var enemy = line.Split(" ")[0] switch
            {
                "A" => RockPaperScissor.Rock,
                "B" => RockPaperScissor.Paper,
                "C" => RockPaperScissor.Scissor,
            };
            var expectedOutcome = line.Split(" ")[1] switch
            {
                "X" => RpsExpectedOutcome.Lose,
                "Y" => RpsExpectedOutcome.Draw,
                "Z" => RpsExpectedOutcome.Win,
            };

            totalPoints += (int)expectedOutcome; 

            var me = expectedOutcome is RpsExpectedOutcome.Draw
                ? enemy : enemy switch
                {
                    RockPaperScissor.Rock => expectedOutcome is RpsExpectedOutcome.Win
                        ? RockPaperScissor.Paper
                        : RockPaperScissor.Scissor,
                    RockPaperScissor.Paper => expectedOutcome is RpsExpectedOutcome.Win
                        ? RockPaperScissor.Scissor
                        : RockPaperScissor.Rock,
                    RockPaperScissor.Scissor => expectedOutcome is RpsExpectedOutcome.Win
                        ? RockPaperScissor.Rock
                        : RockPaperScissor.Paper
                };

            totalPoints += (int)me;
        }

        return totalPoints;
    }

    public enum RpsExpectedOutcome
    {
        Lose = 0,
        Draw = 3,
        Win = 6,
    }

    public int AoC002a()
    {
        var readText = File.ReadAllLines(@"Inputs/002.txt");
        var totalPoints = 0;
        foreach (var line in readText)
        {
            var enemy = line.Split(" ")[0] switch
            {
                "A" => RockPaperScissor.Rock,
                "B" => RockPaperScissor.Paper,
                "C" => RockPaperScissor.Scissor,
            };
            var me = line.Split(" ")[1] switch
            {
                "X" => RockPaperScissor.Rock,
                "Y" => RockPaperScissor.Paper,
                "Z" => RockPaperScissor.Scissor,
            };
            
            totalPoints += (int)me;

            if (enemy == me)
            {
                totalPoints += 3;
            }
            else if(
                me == RockPaperScissor.Rock && enemy == RockPaperScissor.Scissor || 
                me == RockPaperScissor.Paper && enemy == RockPaperScissor.Rock || 
                me == RockPaperScissor.Scissor && enemy == RockPaperScissor.Paper)
            {
                totalPoints += 6;
            }
        }

        return totalPoints;
    }

    public enum RockPaperScissor
    {
        Rock = 1,
        Paper = 2,
        Scissor = 3
    }

    public int AoC001b()
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
        if (currentElf.Any())
            allElfs.Add(currentElf);

        var topThreeElfs = allElfs.OrderByDescending(x => x.Sum()).Take(3);

        return topThreeElfs.Select(x => x.Sum()).Sum();
    }

    public int AoC001a()
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
namespace AoC2022.Services;

public class Aoc2022Service : IAoc2022Service
{
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

            totalPoints += expectedOutcome switch
            {
                RpsExpectedOutcome.Lose => 0,
                RpsExpectedOutcome.Draw => 3,
                RpsExpectedOutcome.Win => 6
            };

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
        Lose = 1,
        Draw = 2,
        Win = 3,
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
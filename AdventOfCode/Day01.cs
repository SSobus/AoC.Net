using System.Text.RegularExpressions;
using System;

namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() { 
        List<string> lines = _input.Split('\n').ToList();

        long total = 0;
        foreach (string line in lines)
        {
            string digits = Regex.Replace(line, "[^0-9]+", "");
            total += digits.Length == 0 ? 0 : int.Parse($"{digits[0]}{digits[^1]}");
        }

        return new ValueTask<string>(total.ToString()); //56042
    }

    public override ValueTask<string> Solve_2()
    {
        List<string> lines = _input.Split('\n').ToList();
        var dict = new Dictionary<string, string>{ 
            { "one", "o1e" }, 
            { "two", "t2" }, 
            { "three", "t3e" },
            { "four", "4" }, 
            { "five", "5e" }, 
            { "six", "6" },
            { "seven", "7n" }, 
            { "eight", "e8t" }, 
            { "nine", "9" }};
        long total = 0;
        foreach (string line in lines)
        {
            string altered = line;
            foreach (var (k, v) in dict)
            {
                altered = altered.Replace(k, v);
            }

            altered = Regex.Replace(altered, "[^0-9]+", "");
            total += altered.Length == 0 ? 0 : int.Parse($"{altered[0]}{altered[^1]}");
        }

        return new ValueTask<string>(total.ToString()); //55358
    }
}

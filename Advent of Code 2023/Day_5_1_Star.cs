namespace Advent_of_Code_2023
{
    public class Day_5_1_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/5 Part 1

        private static List<long> ReturnSeeds(string line)
        {
            List<long> seeds = [];
            
            foreach (string number in line.Split(':')[1].Split(' '))
            {
                if (number.Equals(" ") || number.Equals(""))
                {
                    continue;
                }

                seeds.Add(long.Parse(number.Trim()));
            }

            return seeds;
        }

        private static List<long> ReturnNewMapping(List<string> lines, List<long> currentMapping)
        {
            if (lines.Count == 0)
            {
                return currentMapping;
            }

            List<long> newMapping = [];

            long destinationRangeStart;
            long sourceRangeStart;
            long rangeLength;

            long endSource;

            bool unmapped;

            foreach (long number in currentMapping)
            {
                unmapped = true;

                foreach (string line in lines)
                {
                    destinationRangeStart = long.Parse(line.Split(' ')[0]);
                    sourceRangeStart = long.Parse(line.Split(' ')[1]);
                    rangeLength = long.Parse(line.Split(' ')[2]);

                    endSource = sourceRangeStart + rangeLength;

                    if (number >= sourceRangeStart && number < endSource)
                    {
                        newMapping.Add(number - sourceRangeStart + destinationRangeStart);
                        unmapped = false;
                        break;
                    }
                }

                if (unmapped)
                {
                    newMapping.Add(number);
                }
            }

            return newMapping;
        }

        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day5_Input.txt");

                List<string> lines = [];

                List<long> currentMapping = [];

                List<long> seeds = [];

                string? line = sr.ReadLine();

                while (line != null)
                {
                    if (line.Equals(""))
                    {
                        line = sr.ReadLine();
                        continue;
                    }

                    if (line.Contains("-to-"))
                    {
                        currentMapping = ReturnNewMapping(lines, currentMapping);
                        lines.Clear();
                        line = sr.ReadLine();
                        continue;
                    }

                    if (line.Contains("seeds:"))
                    {
                        seeds = ReturnSeeds(line);
                        currentMapping = seeds;
                        line = sr.ReadLine();
                        continue;
                    }
                    else
                    {
                        lines.Add(line);
                    }

                    line = sr.ReadLine();
                }

                currentMapping = ReturnNewMapping(lines, currentMapping);

                long lowestNumber = long.MaxValue;

                foreach (long number in currentMapping)
                {
                    if (number < lowestNumber)
                    {
                        lowestNumber = number;
                    }
                }

                sr.Close();

                return lowestNumber.ToString();
            }
            catch (Exception ex)
            {
                return "Exception: " + ex.Message.ToString();
            }
        }
    }
}

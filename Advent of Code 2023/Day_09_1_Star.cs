namespace Advent_of_Code_2023
{
    public class Day_09_1_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/9 Part 1
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/9/input

        private static List<string> CreateSequence(string line, List<string> sequences)
        {
            string sequenceToAdd = "";

            bool sequencesFinished = true;

            int numberOne;
            int numberTwo;

            for(int i = 0; i < line.Split(' ').Length - 2; i++)
            {
                numberOne = int.Parse(line.Split(' ')[i]);
                numberTwo = int.Parse(line.Split(' ')[i + 1]);

                sequenceToAdd += (numberTwo - numberOne).ToString() + ' ';

                if (!numberOne.Equals(numberTwo))
                {
                    sequencesFinished = false;
                }
            }

            sequenceToAdd += 'A';

            if (sequencesFinished)
            {
                sequences.Add(sequenceToAdd.Replace('A', '0'));
                return sequences;
            }

            sequences.Add(sequenceToAdd);
            sequences = CreateSequence(sequenceToAdd, sequences);

            return sequences;
        }

        public static int ExtrapolatedValue(string line)
        {
            List<string> sequences = [];

            sequences.Add(line + " A");
            sequences = CreateSequence(sequences[0], sequences);
            sequences.Reverse();

            int currentNumber;
            int extrapolatedNumber;

            for (int i = 0; i < sequences.Count - 1; i++)
            {
                currentNumber = int.Parse(sequences[i].Split(' ')[^1]);
                extrapolatedNumber = int.Parse(sequences[i + 1].Split(" ")[^2]) + currentNumber;
                sequences[i + 1] = sequences[i + 1][..^1] + extrapolatedNumber; ;
            }

            return int.Parse(sequences[^1].Split(" ")[^1]);
        }

        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day9_Input.txt");

                List<string> lines = [];

                int sum = 0;

                string? line = sr.ReadLine();

                while (line != null)
                {
                    sum += ExtrapolatedValue(line);
                    line = sr.ReadLine();
                }

                sr.Close();

                return sum.ToString();
            }
            catch (Exception ex)
            {
                return "Exception: " + ex.Message.ToString();
            }
        }
    }
}

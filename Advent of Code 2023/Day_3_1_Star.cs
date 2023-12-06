using System.Text.RegularExpressions;

namespace Advent_of_Code_2023
{
    public class Day_3_1_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/3 Part 1
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/3/input

        private static readonly System.Buffers.SearchValues<char> s_myChars = System.Buffers.SearchValues.Create("0123456789");

        private static Dictionary<int, string> GetNumbersInLine(string line)
        {
            string currentNumber = "";
            int oldIndex = 0;
            int currentIndex = 0;

            Dictionary<int, string> numbers = [];

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i..].AsSpan().IndexOfAny(s_myChars) == -1)
                {
                    numbers.Add(i - currentNumber.Length, currentNumber.Trim());
                    break;
                }

                if (i == line.Length - 1 && !currentNumber.Equals(""))
                {
                    if (line[i..].AsSpan().IndexOfAny(s_myChars) != -1)
                    {
                        currentNumber += line[i + line[i..].AsSpan().IndexOfAny(s_myChars)];
                    }

                    numbers.Add(line.Length - currentNumber.Length, currentNumber.Trim());
                    break;
                }

                if (currentIndex >= i)
                {
                    if (currentNumber.Equals(""))
                    {
                        currentIndex = i + line.AsSpan().IndexOfAny(s_myChars);
                        currentNumber += line[currentIndex];
                    }

                    continue;
                }

                oldIndex = currentIndex;

                if (i == 0)
                {
                    currentIndex = i + line.AsSpan().IndexOfAny(s_myChars);
                }
                else
                {
                    currentIndex = i + line[i..].AsSpan().IndexOfAny(s_myChars);
                }


                if (currentIndex == oldIndex + 1 || oldIndex == 0)
                {
                    currentNumber += line[currentIndex];
                }
                else
                {
                    if (currentNumber.Equals(""))
                    {
                        continue;
                    }

                    numbers.Add(i - currentNumber.Length, currentNumber.Trim());
                    currentNumber = "";
                    currentNumber += line[currentIndex];
                    continue;
                }


            }

            return numbers;
        }

        private static bool CheckUpperOrLowerLine(int firstIndex, int lastIndex, string line)
        {
            if (line.Equals(""))
            {
                return false;
            }

            if (lastIndex < line.Length)
            {
                if (!Regex.IsMatch(line[lastIndex].ToString(), "[.0123456789]"))
                {
                    return true;
                }
            }

            if (firstIndex > 0)
            {
                if (!Regex.IsMatch(line[firstIndex - 1].ToString(), "[.0123456789]"))
                {
                    return true;
                }
            }

            for (int i = firstIndex; i < lastIndex; i++)
            {
                if (!Regex.IsMatch(line[i].ToString(), "[.0123456789]"))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckMiddleLine(int firstIndex, int lastIndex, string middleLine)
        {
            if (lastIndex < middleLine.Length)
            {
                if (!middleLine[lastIndex].Equals('.'))
                {
                    return true;
                }
            }

            if (firstIndex > 0)
            {
                if (!middleLine[firstIndex - 1].Equals('.'))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsAdjacent(int firstIndex, int lastIndex, string upperLine, string middleLine, string lowerLine)
        {
            if (CheckUpperOrLowerLine(firstIndex, lastIndex, upperLine))
            {
                return true;
            }

            if (CheckUpperOrLowerLine(firstIndex, lastIndex, lowerLine))
            {
                return true;
            }

            if (CheckMiddleLine(firstIndex, lastIndex, middleLine))
            {
                return true;
            }

            return false;
        }

        private static int SumOfLine(string upperLine, string middleLine, string lowerLine)
        {
            int sum = 0;

            Dictionary<int, string> numbers = GetNumbersInLine(middleLine);

            foreach (KeyValuePair<int, string> value in numbers)
            {
                if (IsAdjacent(value.Key, value.Key + value.Value.Length, upperLine, middleLine, lowerLine))
                {
                    sum += int.Parse(value.Value);
                }
            }

            return sum;
        }

        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day3_Input.txt");

                List<string> lines = [];

                int sum = 0;

                string? line = sr.ReadLine();

                while (line != null)
                {
                    lines.Add(line);
                    line = sr.ReadLine();
                }

                for (int i = 0; i < lines.Count; i++)
                {
                    if (i == 0)
                    {
                        sum += SumOfLine("", lines[i], lines[i + 1]);
                        continue;
                    }

                    if (i == lines.Count - 1)
                    {
                        sum += SumOfLine(lines[i - 1], lines[i], "");
                        continue;
                    }

                    sum += SumOfLine(lines[i - 1], lines[i], lines[i + 1]);
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

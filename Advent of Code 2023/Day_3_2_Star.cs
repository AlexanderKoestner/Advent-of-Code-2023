using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2023
{
    public class Day_3_2_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/3 Part 2

        private static List<int> GetGearPositions(string middleLine)
        {
            List<int> indexes = [];
            int currentIndex = 0;

            for (int i = 0; i < middleLine.Length; i++)
            {
                if (middleLine[i..].IndexOf('*') == -1)
                {
                    break;
                }

                if (currentIndex >= i)
                {
                    continue;
                }

                currentIndex = i + middleLine[i..].IndexOf('*');
                indexes.Add(currentIndex);
            }

            return indexes;
        }

        private static bool HasGear(string middleLine)
        {
            if (middleLine.Contains('*'))
            {   
                return true;
            }

            return false;
        }

        private static int CheckMiddleLine(int index, string middleLine)
        {
            int sum = 0;
            if (index > 0)
            {
                if (Regex.IsMatch(middleLine[index - 1].ToString(),"[0-9]"))
                {
                    sum += 1;
                }
            }

            if(index < middleLine.Length - 1) 
            {
                if (Regex.IsMatch(middleLine[index + 1].ToString(), "[0-9]"))
                {
                    sum += 1;
                }
            }
                
            return sum;
        }

        private static int CheckUpperOrLowerLine(int index, string line)
        {
            if (line.Equals(""))
            {
                return 0;
            }

            if (index < line.Length && index > 0)
            {
                if (Regex.IsMatch(line[(index - 1)..(index + 2)].ToString(), "[0-9]{3}"))
                {
                    return 1;
                }

                if (Regex.IsMatch(line[(index - 1)..(index + 2)].ToString(), "[0-9]{2}"))
                {
                    return 1;
                }

                if (Regex.IsMatch(line[(index - 1)..(index + 2)].ToString(), "[0-9][^0-9][0-9]"))
                {
                    return 2;
                }

                if (Regex.IsMatch(line[(index - 1)..(index + 2)].ToString(), "[0-9]"))
                {
                    return 1;
                }
            }

            return 0;
        }

        private static bool IsCorrectGear(int index, string upperLine, string middleLine, string lowerLine)
        {
            int sum = CheckMiddleLine(index, middleLine) + CheckUpperOrLowerLine(index, upperLine) + CheckUpperOrLowerLine(index, lowerLine);

            if (sum == 2)
            {
                return true;
            }

            return false;
        }

        private static List<int> ReturnRatioOfGear(int index, string line)
        {
            List<int> numbers = [];

            if (line.Equals(""))
            {
                return numbers;
            }

            if (index < line.Length && index > 0)
            {
                if (Regex.IsMatch(line[(index - 1)..(index + 2)].ToString(), "[0-9]{3}"))
                {
                    numbers.Add(int.Parse(line[(index - 1)..(index + 2)]));
                }

                if (Regex.IsMatch(line[(index - 1)..(index + 2)].ToString(), "[0-9]{2}[^0-9]"))
                {
                    if (Regex.IsMatch(line[(index - 3)..(index - 2)].ToString(), "[0-9]{2}"))
                    {
                        numbers.Add(int.Parse(line[(index - 3)..index].Trim('.')));
                    }
                    else
                    {
                        numbers.Add(int.Parse(line[(index - 2)..(index + 1)].Trim('.')));
                    }
                }

                if (Regex.IsMatch(line[(index - 1)..(index + 2)].ToString(), "[^0-9][0-9]{2}"))
                {
                    if (Regex.IsMatch(line[index + 2].ToString(), "[0-9]"))
                    {
                        numbers.Add(int.Parse(line[index..(index + 3)].Trim('.')));
                    }
                    else
                    {
                        numbers.Add(int.Parse(line[index..(index + 2)].Trim('.')));
                    }
                }

                if (Regex.IsMatch(line[(index - 1)..(index + 2)].ToString(), "[0-9][^0-9][0-9]"))
                {
                    numbers.Add(int.Parse(line[(index - 3)..index].Trim('.')));
                    numbers.Add(int.Parse(line[(index + 1)..(index + 4)].Trim('.')));
                }

                if (Regex.IsMatch(line[(index - 1)..(index + 2)].ToString(), "[0-9][^0-9]{2}"))
                {
                    numbers.Add(int.Parse(line[(index - 3)..index].Trim('.')));
                }

                if (Regex.IsMatch(line[(index - 1)..(index + 2)].ToString(), "[^0-9]{2}[0-9]"))
                {
                    numbers.Add(int.Parse(line[(index + 1)..(index + 4)].Trim('.')));
                }

                if (Regex.IsMatch(line[(index - 1)..(index + 2)].ToString(), "[^0-9][0-9][^0-9]"))
                {
                    numbers.Add(int.Parse(line[index].ToString()));
                }
            }

            return numbers;
        }

        private static int GetGearRatio(string upperLine, string middleLine, string lowerLine)
        {
            List<int> indexes = [];

            if (HasGear(middleLine))
            {
                indexes = GetGearPositions(middleLine);
            }

            int product;

            List<int> numbers = [];
            List<int> products = [];

            foreach (int index in indexes)
            {
                if (IsCorrectGear(index, upperLine, middleLine, lowerLine))
                {
                    foreach (int number in ReturnRatioOfGear(index, upperLine))
                    {
                        numbers.Add(number);
                    }
                    foreach (int number in ReturnRatioOfGear(index, middleLine))
                    {
                        numbers.Add(number);
                    }
                    foreach (int number in ReturnRatioOfGear(index, lowerLine))
                    {
                        numbers.Add(number);
                    }

                    product = 1;

                    foreach (int number in numbers)
                    {
                        product *= number;
                    }

                    products.Add(product);
                    numbers.Clear();
                }
            }

            if (products.Count == 0)
            {
                return 0;
            }
            
            int fullProduct = 0;

            foreach(int number in products)
            {
                fullProduct += number;
            }

            return fullProduct;
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
                        sum += GetGearRatio("", lines[i], lines[i + 1]);
                        continue;
                    }

                    if (i == lines.Count - 1)
                    {
                        sum += GetGearRatio(lines[i - 1], lines[i], "");
                        continue;
                    }

                    sum += GetGearRatio(lines[i - 1], lines[i], lines[i + 1]);
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


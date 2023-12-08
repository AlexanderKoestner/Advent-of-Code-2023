namespace Advent_of_Code_2023
{
    public class Day_01_2_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/1 Part 2
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/1/input

        private static readonly System.Buffers.SearchValues<char> s_myChars = System.Buffers.SearchValues.Create("0123456789");

        private static string GetNumber(string number)
        {
            return number switch
            {
                "one" => "1",
                "two" => "2",
                "three" => "3",
                "four" => "4",
                "five" => "5",
                "six" => "6",
                "seven" => "7",
                "eight" => "8",
                "nine" => "9",
                _ => "-1",
            };
        }
        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day1_Input.txt");

                List<string> digits = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

                string firstDigit;
                string lastDigit;

                int firstIndexOfStringDigit = int.MaxValue;
                int lastIndexOfStringDigit = int.MinValue;

                int firstIndexOfDigit = -1;
                int lastIndexOfDigit = -1;

                string currentFirstStringDigit = "";
                string currentLastStringDigit = "";

                int sum = 0;

                string? line = sr.ReadLine();

                while (line != null)
                {
                    foreach (string value in digits)
                    {
                        if (!line.Contains(value))
                        {
                            continue;
                        }

                        if (firstIndexOfStringDigit > line.IndexOf(value))
                        {
                            firstIndexOfStringDigit = line.IndexOf(value);
                            currentFirstStringDigit = value;
                        }

                        if (lastIndexOfStringDigit < line.LastIndexOf(value))
                        {
                            lastIndexOfStringDigit = line.LastIndexOf(value);
                            currentLastStringDigit = value;
                        }
                    }


                    firstIndexOfDigit = line.AsSpan().IndexOfAny(s_myChars);
                    lastIndexOfDigit = line.AsSpan().LastIndexOfAny(s_myChars);


                    if ((firstIndexOfDigit < firstIndexOfStringDigit || currentFirstStringDigit.Equals("")) && firstIndexOfDigit > -1)
                    {
                        firstDigit = line[firstIndexOfDigit].ToString();
                    }
                    else
                    {
                        firstDigit = GetNumber(currentFirstStringDigit);
                    }

                    if ((lastIndexOfDigit > lastIndexOfStringDigit || currentLastStringDigit.Equals("")) && lastIndexOfDigit > -1)
                    {
                        lastDigit = line[lastIndexOfDigit].ToString();
                    }
                    else
                    {
                        lastDigit = GetNumber(currentLastStringDigit);
                    }

                    sum += int.Parse(firstDigit + lastDigit);

                    firstIndexOfStringDigit = int.MaxValue;
                    lastIndexOfStringDigit = int.MinValue;

                    firstIndexOfDigit = -1;
                    lastIndexOfDigit = -1;

                    currentFirstStringDigit = "";
                    currentLastStringDigit = "";

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


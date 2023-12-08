namespace Advent_of_Code_2023
{
    public class Day_04_1_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/4 Part 1
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/4/input

        private static int CalcCardWorth(List<string> winningNumbers, List<string> myNumbers)
        {
            int sum = 0;

            for (int i = 0; i < winningNumbers.Count; i++)
            {
                for (int j = 0; j < myNumbers.Count; j++)
                {
                    if (int.Parse(winningNumbers[i]) == int.Parse(myNumbers[j]))
                    {
                        if (sum == 0)
                        {
                            sum = 1;
                        }
                        else
                        {
                            sum *= 2;
                        }

                        break;
                    }
                }
            }

            return sum;
        }
        private static int GetCardWorth(string line)
        {
            List<string> allWinningNumbers = [];
            List<string> allMyNumbers = [];

            string allNumbers = line.Split(':')[1];
            string winningNumbers = allNumbers.Split("|")[0].Trim();
            string myNumbers = allNumbers.Split("|")[1].Trim();

            foreach (string number in winningNumbers.Split(" "))
            {
                if (number.Equals(""))
                {
                    continue;
                }
                allWinningNumbers.Add(number);
            }

            foreach (string number in myNumbers.Split(" "))
            {
                if (number.Equals(""))
                {
                    continue;
                }
                allMyNumbers.Add(number);
            }

            return CalcCardWorth(allWinningNumbers, allMyNumbers);
        }
        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day4_Input.txt");

                List<string> lines = [];

                int sum = 0;

                string? line = sr.ReadLine();

                while (line != null)
                {
                    sum += GetCardWorth(line);

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

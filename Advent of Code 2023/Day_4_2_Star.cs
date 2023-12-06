namespace Advent_of_Code_2023
{
    public class Day_4_2_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/4 Part 2
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/4/input

        private static int GetCardMatches(List<List<int>> cardBreakdown)
        {
            int matches = 0;

            for (int i = 0; i < cardBreakdown[1].Count; i++)
            {
                for (int j = 0; j < cardBreakdown[2].Count; j++)
                {
                    if (cardBreakdown[1][i] == cardBreakdown[2][j])
                    {
                        matches++;
                        break;
                    }
                }
            }

            return matches;
        }
        private static List<List<int>> GetCardBreakdown(string line)
        {
            List<int> currentCardNumber = [];
            List<int> allWinningNumbers = [];
            List<int> allMyNumbers = [];

            string currentCard = line.Split(':')[0];
            string allNumbers = line.Split(':')[1];
            string currentCardNumberAsString = currentCard.Split(' ')[^1].Trim();
            string winningNumbers = allNumbers.Split("|")[0].Trim();
            string myNumbers = allNumbers.Split("|")[1].Trim();

            foreach (string number in winningNumbers.Split(" "))
            {
                if (number.Equals(""))
                {
                    continue;
                }
                allWinningNumbers.Add(int.Parse(number));
            }

            foreach (string number in myNumbers.Split(" "))
            {
                if (number.Equals(""))
                {
                    continue;
                }
                allMyNumbers.Add(int.Parse(number));
            }

            currentCardNumber.Add(int.Parse(currentCardNumberAsString));

            List<List<int>> all = [];

            all.Add(currentCardNumber);
            all.Add(allWinningNumbers);
            all.Add(allMyNumbers);

            return all;
        }
        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day4_Input.txt");

                List<string> lines = [];
                List<int> timesToPlayLine = [];

                int matches;

                int totalAmountOfCopies = 0;

                int timesToPlay;

                int actualMatches;

                string? line = sr.ReadLine();

                while (line != null)
                {
                    lines.Add(line);
                    timesToPlayLine.Add(1);

                    line = sr.ReadLine();
                }

                for (int i = 0; i < lines.Count; i++)
                {
                    matches = GetCardMatches(GetCardBreakdown(lines[i]));

                    timesToPlay = timesToPlayLine[i];

                    actualMatches = matches * timesToPlay;

                    totalAmountOfCopies += actualMatches;

                    for (int j = 1; j < matches + 1; j++)
                    {
                        timesToPlayLine[i + j] += timesToPlay;
                    }
                }

                sr.Close();

                return (totalAmountOfCopies + lines.Count).ToString();
            }
            catch (Exception ex)
            {
                return "Exception: " + ex.Message.ToString();
            }
        }
    }
}

using System.Runtime.CompilerServices;

namespace Advent_of_Code_2023
{
    public class Day_11_1_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/11 Part 1
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/11/input

        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day11_Input.txt");

                List<string> lines = [];
                List<int> xCoordinatesToDouble = [];

                string? line = sr.ReadLine();

                while (line != null)
                {
                    if (!line.Contains('#'))
                    {
                        lines.Add(line);
                    }
                    lines.Add(line);
                    line = sr.ReadLine();
                }

                bool noGalaxyFound = true;

                for (int x = 0; x < lines[0].Length; x++)
                {
                    noGalaxyFound = true;

                    for (int y = 0; y < lines.Count; y++)
                    {
                        if (lines[y][x].Equals('#'))
                        {
                            noGalaxyFound = false;
                            break;
                        }
                    }

                    if (noGalaxyFound)
                    {
                        xCoordinatesToDouble.Add(x);
                    }
                }

                xCoordinatesToDouble.Reverse();

                string lineToReplace;

                List<char> linesToReplace = [];

                for (int y = 0; y < lines.Count; y++)
                {
                    lineToReplace = "";
                    linesToReplace.Clear();

                    foreach (char ch in lines[y])
                    {
                        linesToReplace.Add(ch);
                    }

                    foreach (int x in xCoordinatesToDouble)
                    {
                        linesToReplace.Insert(x, '.');
                    }

                    foreach (char ch in linesToReplace)
                    {
                        lineToReplace += ch;
                    }

                    lines[y] = lineToReplace;
                }

                Dictionary<int, (int,int)> galaxies = [];

                int numberOfGalaxy = 1;

                for (int y = 0; y < lines.Count; y++)
                {
                    for (int x = 0; x < lines[y].Length; x++)
                    {
                        if (lines[y][x].Equals('#'))
                        {
                            galaxies.Add(numberOfGalaxy, (x, y));
                            numberOfGalaxy++;
                        }
                    }
                }

                int sum = 0;
                int xStep;
                int yStep;

                for (int i = 1; i <= galaxies.Count; i++)
                {
                    for(int j = 1; j <= galaxies.Count; j++)
                    {
                        if(i != j)
                        {
                            xStep = galaxies[i].Item1 - galaxies[j].Item1;
                            yStep = galaxies[i].Item2 - galaxies[j].Item2;

                            if (xStep < 0)
                            {
                                xStep *= -1;
                            }

                            if (yStep < 0)
                            {
                                yStep *= -1;
                            }

                            sum += xStep + yStep;
                        }
                    }
                }

                sum /= 2;

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

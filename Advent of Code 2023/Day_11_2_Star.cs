using System.Runtime.CompilerServices;

namespace Advent_of_Code_2023
{
    public class Day_11_2_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/11 Part 2
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/11/input

        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day11_Input.txt");

                List<string> lines = [];
                List<int> yCoordinatesToFactorize = [];
                List<int> xCoordinatesToFactorize = [];

                string? line = sr.ReadLine();

                while (line != null)
                {
                    lines.Add(line);
                    line = sr.ReadLine();
                }
                for (int i = 0; i < lines.Count; i++)
                {
                    if (!lines[i].Contains('#'))
                    {
                        yCoordinatesToFactorize.Add(i);
                    }
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
                        xCoordinatesToFactorize.Add(x);
                    }
                }

                Dictionary<int, (int, int)> galaxies = [];

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

                long sum = 0;
                long xStep;
                long yStep;
                int rangeStartX;
                int rangeStartY;
                int rangeEndX;
                int rangeEndY;

                for (int i = 1; i <= galaxies.Count; i++)
                {
                    for (int j = 1; j <= galaxies.Count; j++)
                    {
                        if (i != j)
                        {
                            if (galaxies[i].Item2 > galaxies[j].Item2)
                            {
                                rangeStartY = galaxies[j].Item2;
                                rangeEndY = galaxies[i].Item2;
                            }
                            else
                            {
                                rangeStartY = galaxies[i].Item2;
                                rangeEndY = galaxies[j].Item2;
                            }

                            if (galaxies[i].Item1 > galaxies[j].Item1)
                            {
                                rangeStartX = galaxies[j].Item1;
                                rangeEndX = galaxies[i].Item1;
                            }
                            else
                            {
                                rangeStartX = galaxies[i].Item1;
                                rangeEndX = galaxies[j].Item1;
                            }

                            xStep = rangeEndX - rangeStartX;
                            yStep = rangeEndY - rangeStartY;

                            foreach (int y in yCoordinatesToFactorize)
                            {
                                if (galaxies[i].Item2 > galaxies[j].Item2)
                                {
                                    if(y < galaxies[i].Item2 && y > galaxies[j].Item2)
                                    {
                                        yStep += 1000000 - 1;
                                    }
                                }
                                else
                                {
                                    if (y < galaxies[j].Item2 && y > galaxies[i].Item2)
                                    {
                                        yStep += 1000000 - 1;
                                    }
                                }
                            }

                            foreach (int x in xCoordinatesToFactorize)
                            {
                                if (galaxies[i].Item1 > galaxies[j].Item1)
                                {
                                    if (x < galaxies[i].Item1 && x > galaxies[j].Item1)
                                    {
                                        xStep += 1000000 - 1;
                                    }
                                }
                                else
                                {
                                    if (x < galaxies[j].Item1 && x > galaxies[i].Item1)
                                    {
                                        xStep += 1000000 - 1;
                                    }
                                }
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

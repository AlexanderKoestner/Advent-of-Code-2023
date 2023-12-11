using System.Security.Cryptography.X509Certificates;

namespace Advent_of_Code_2023
{
    public class Day_10_1_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/10 Part 1
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/10/input

        public static string NextPosition(int x, int y, string vector)
        {
            if (vector.Equals("UP"))
            {
                return (x + " " + (y - 1)).ToString();
            }

            if (vector.Equals("DOWN"))
            {
                return (x + " " + (y + 1)).ToString();
            }

            if (vector.Equals("LEFT"))
            {
                return ((x - 1)+ " " + y).ToString();
            }

            return ((x + 1) + " " + y).ToString();
        }

        public static string Vector(int x, int y, string lastVector, string symbol, Dictionary<string, char> map)
        {
            if (symbol.Equals("|"))
            {
                if (lastVector.Equals("UP"))
                {
                    return "UP " + map[x + " " + (y - 1)];
                }

                return "DOWN " + map[x + " " + (y + 1)];
            }

            if (symbol.Equals("-"))
            {
                if (lastVector.Equals("LEFT"))
                {
                    return "LEFT " + map[(x - 1) + " " + y];
                }

                return "RIGHT " + map[(x + 1) + " " + y];
            }

            if (symbol.Equals("7"))
            {
                if (lastVector.Equals("RIGHT"))
                {
                    return "DOWN " + map[x + " " + (y + 1)];
                }

                return "LEFT " + map[(x - 1) + " " + y];
            }

            if (symbol.Equals("J"))
            {
                if (lastVector.Equals("RIGHT"))
                {
                    return "UP " + map[x + " " + (y - 1)];
                }

                return "LEFT " + map[(x - 1) + " " + y];
            }

            if (symbol.Equals("F"))
            {
                if (lastVector.Equals("LEFT"))
                {
                    return "DOWN " + map[x + " " + (y + 1)];
                }

                return "RIGHT " + map[(x + 1) + " " + y];
            }

            if (symbol.Equals("L"))
            {
                if (lastVector.Equals("LEFT"))
                {
                    return "UP " + map[x + " " + (y - 1)];
                }

                return "RIGHT " + map[(x + 1) + " " + y];
            }

            if (map[x + " " + (y - 1)].Equals('|') || map[x + " " + (y - 1)].Equals('7') || map[x + " " + (y - 1)].Equals('F') || map[x + " " + (y - 1)].Equals('S'))
            {
                return "UP " + map[x + " " + (y - 1)];
            }

            if (map[x + " " + (y + 1)].Equals('|') || map[x + " " + (y + 1)].Equals('J') || map[x + " " + (y + 1)].Equals('L') || map[x + " " + (y + 1)].Equals('S'))
            {
                return "DOWN " + map[x + " " + (y + 1)];
            }

            return "RIGHT " + map[(x + 1) + " " + y];
        }

        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day10_Input.txt");

                Dictionary<string, char> map = [];

                string? line = sr.ReadLine();

                int x = 0;
                int y = 0;
                int startX = 0;
                int startY = 0;

                while (line != null)
                {
                    x = 0;

                    foreach (char ch in line)
                    {
                        if (ch.Equals('S'))
                        {
                            startY = y;
                            startX = x;
                        }

                        map.Add((x + " " + y).ToString(), ch);
                        x++;
                    }

                    y++;
                    line = sr.ReadLine();
                }

                bool notLooped = true;
                int steps = 0;
                string position = "S";
                string vectorAndSymbol = "S S";

                x = startX;
                y = startY;

                while (notLooped)
                {
                    steps++;
                    vectorAndSymbol = Vector(x, y, vectorAndSymbol.Split(' ')[0], vectorAndSymbol.Split(' ')[1], map);
                    position = NextPosition(x, y, vectorAndSymbol.Split(' ')[0]);
                    x = int.Parse(position.Split(' ')[0]);
                    y = int.Parse(position.Split(' ')[1]);

                    if (map[x + " " + y].Equals('S'))
                    {
                        notLooped = false;
                    }
                }

                sr.Close();

                return (steps / 2 + steps % 2).ToString();
            }
            catch (Exception ex)
            {
                return "Exception: " + ex.Message.ToString();
            }
        }
    }
}

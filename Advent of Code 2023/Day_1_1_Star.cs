using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2023
{
    internal class Day_1_1_Star
    {
        public string getResult()
        {
            try
            {
                StreamReader sr = new StreamReader("E:\\Advent_of_Code_2023\\AdventOfCode_Day1_Input.txt");

                string firstDigit;
                string lastDigit;

                int sum = 0;

                String line = sr.ReadLine();

                while (line != null)
                {
                    firstDigit = line[line.IndexOfAny("0123456789".ToCharArray())].ToString();
                    lastDigit = line[line.LastIndexOfAny("0123456789".ToCharArray())].ToString();

                    sum += (int.Parse(firstDigit + lastDigit));

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

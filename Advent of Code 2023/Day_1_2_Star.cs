using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2023
{
    internal class Day_1_2_Star
    {
        public string getNumber(string number)
        {
            switch (number)
            {
                case "one":
                    return "1";
                case "two":
                    return "2";
                case "three":
                    return "3";
                case "four":
                    return "4";
                case "five":
                    return "5";
                case "six":
                    return "6";
                case "seven":
                    return "7";
                case "eight":
                    return "8";
                case "nine":
                    return "9";
                default:
                    return "-1";
                   
            }
        }
        public string getResult()
        {
            try
            {
                StreamReader sr = new StreamReader("E:\\Advent_of_Code_2023\\AdventOfCode_Day1_Input.txt");

                List<string> digits = new List<string>(){"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

                string firstDigit;
                string lastDigit;

                int firstIndexOfStringDigit = -1;
                int lastIndexOfStringDigit = -1;

                int firstIndexOfDigit = -1;
                int lastIndexOfDigit = -1;

                string currentFirstStringDigit = "";
                string currentLastStringDigit = "";

                int sum = 0;

                String line = sr.ReadLine();

                while (line != null)
                {
                    foreach(string value in digits)
                    {
                        if (!line.Contains(value))
                        {
                            continue;
                        }

                        if(firstIndexOfStringDigit == -1)
                        {
                            firstIndexOfStringDigit = line.IndexOf(value);
                            currentFirstStringDigit = value;
                        }
                        else
                        {
                            if(firstIndexOfStringDigit > line.IndexOf(value))
                            {
                                firstIndexOfStringDigit = line.IndexOf(value);
                                currentFirstStringDigit = value;
                            }
                        }
                    }

                    foreach (string value in digits)
                    {
                        if (!line.Contains(value))
                        {
                            continue;
                        }

                        if (lastIndexOfStringDigit == -1)
                        {
                            lastIndexOfStringDigit = line.LastIndexOf(value);
                            currentLastStringDigit = value;
                        }
                        else
                        {
                            if (lastIndexOfStringDigit < line.LastIndexOf(value))
                            {
                                lastIndexOfStringDigit = line.LastIndexOf(value);
                                currentLastStringDigit= value;
                            }
                        }
                    }

                    firstIndexOfDigit = line.IndexOfAny("0123456789".ToCharArray());
                    lastIndexOfDigit = line.LastIndexOfAny("0123456789".ToCharArray());


                    if ((firstIndexOfDigit < firstIndexOfStringDigit || currentFirstStringDigit.Equals("")) && firstIndexOfDigit != -1)
                    {
                        firstDigit = line[firstIndexOfDigit].ToString();
                    }
                    else
                    {
                        firstDigit = getNumber(currentFirstStringDigit);
                    }

                    if ((lastIndexOfDigit > lastIndexOfStringDigit || currentLastStringDigit.Equals("")) && lastIndexOfDigit != -1)
                    {
                        lastDigit = line[lastIndexOfDigit].ToString();
                    }
                    else
                    {
                        lastDigit = getNumber(currentLastStringDigit);
                    }

                    sum += (int.Parse(firstDigit + lastDigit));
  
                    firstIndexOfStringDigit = -1;
                    lastIndexOfStringDigit = -1;

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

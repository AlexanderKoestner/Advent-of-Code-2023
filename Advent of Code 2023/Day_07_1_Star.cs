namespace Advent_of_Code_2023
{
    public class Day_07_1_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/7 Part 1
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/7/input

        private static char GetStrongerCard(char card1, char card2)
        {
            Dictionary<char, int> cardValues = [];

            cardValues.Add('2', 1);
            cardValues.Add('3', 2);
            cardValues.Add('4', 3);
            cardValues.Add('5', 4);
            cardValues.Add('6', 5);
            cardValues.Add('7', 6);
            cardValues.Add('8', 7);
            cardValues.Add('9', 8);
            cardValues.Add('T', 9);
            cardValues.Add('J', 10);
            cardValues.Add('Q', 11);
            cardValues.Add('K', 12);
            cardValues.Add('A', 13);

            if (cardValues[card1] > cardValues[card2])
            {
                return card1;
            }

            return card2;
        }

        private static Hand? GetStrongerHand(Hand hand1, Hand hand2)
        {
            char hand1Char;
            char hand2Char;

            Hand? strongerHand = null;

            for (int i = 0; i < hand1.Cards.Length; i++)
            {
                hand1Char = hand1.Cards[i];
                hand2Char = hand2.Cards[i];

                if (hand1Char.Equals(hand2Char))
                {
                    continue;
                }
                
                if (hand1Char.Equals(GetStrongerCard(hand1Char, hand2Char)))
                {
                    strongerHand = hand1;
                    break;
                }
                else
                {
                    strongerHand = hand2;
                    break;
                }
            }

            return strongerHand;
        }

        private static List<Hand> GetSortedHands(List<Hand> hands)
        {
            if (hands.Count == 1)
            {
                return hands;
            }

            List<Hand> sortedHands = [];

            bool firstHand = true;

            string sortedCardCheck;
            string sortedCardCheckPlusOne;
            string unsortedCardCheck;

            foreach (Hand hand in hands)
            {
                if (firstHand)
                {
                    sortedHands.Add(hand);
                    firstHand = false;
                }
                else
                {
                    for (int i = 0; i < sortedHands.Count; i++)
                    {
                        sortedCardCheck = sortedHands[i].Cards;
                        unsortedCardCheck = hand.Cards;

                        if (i == 0)
                        {
                            if (sortedHands[i].Cards.Equals(GetStrongerHand(sortedHands[i], hand).Cards))
                            {
                                sortedHands.Insert(0, hand);
                                break;
                            }
                            else
                            {
                                if (sortedHands.Count > 1)
                                {
                                    sortedCardCheckPlusOne = sortedHands[i + 1].Cards;

                                    if (sortedHands[i + 1].Cards.Equals(GetStrongerHand(sortedHands[i + 1], hand).Cards))
                                    {
                                        sortedHands.Insert(i + 1, hand);
                                        break;
                                    }
                                    continue;
                                }
                                else
                                {
                                    sortedHands.Add(hand);
                                    break;
                                }

                            }
                        }

                        if (i < sortedHands.Count - 1)
                        {
                            if (sortedHands[i].Cards.Equals(GetStrongerHand(sortedHands[i], hand).Cards))
                            {
                                sortedHands.Insert(i - 1, hand);
                                break;
                            }
                            else
                            {
                                sortedCardCheckPlusOne = sortedHands[i + 1].Cards;
                                unsortedCardCheck = hand.Cards;

                                if (sortedHands[i + 1].Cards.Equals(GetStrongerHand(sortedHands[i + 1], hand).Cards))
                                {
                                    sortedHands.Insert(i + 1, hand);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (sortedHands[i].Cards.Equals(GetStrongerHand(sortedHands[i], hand).Cards))
                            {
                                sortedHands.Insert(i - 1, hand);
                                break;
                            }

                            sortedHands.Add(hand);
                            break;
                        }
                    }
                }
                
            }

            return sortedHands;
        }

        private class Hand(string cards, int bid)
        {
            public string Cards { get;} = cards;
            public int Bid { get; } = bid;
        }

        private static int GetHandStrength(string hand)
        {
            Dictionary<char, int> cards = [];

            int first;
            int second;
            int third;

            foreach (char c in hand)
            {
                if (!cards.TryAdd(c, 1))
                {
                    cards[c] += 1;
                }
            }

            if (cards.Count == 1)
            {
                return 7;
            }

            if (cards.Count == 2)
            {
                first = cards.Values.ToArray()[0];
                second = cards.Values.ToArray()[1];

                if ((first == 1 && second == 4) || (first == 4 && second == 1))
                {
                    return 6;
                }

                if ((first == 2 && second == 3) || (first == 3 && second == 2))
                {
                    return 5;
                }
            }

            if (cards.Count == 3)
            {
                first = cards.Values.ToArray()[0];
                second = cards.Values.ToArray()[1];
                third = cards.Values.ToArray()[2];

                if ((first == 3 && second == 1 && third == 1) || (first == 1 && second == 3 && third == 1) || (first == 1 && second == 1 && third == 3))
                {
                    return 4;
                }

                if ((first == 2 && second == 2 && third == 1) || (first == 2 && second == 1 && third == 2) || (first == 1 && second == 2 && third == 2))
                {
                    return 3;
                }
            }

            if (cards.Count == 4)
            {
                return 2;
            }

            return 1;
        }

        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day7_Input.txt");

                List<Hand> fiveOfAKind = [];

                List<Hand> fourOfAKind = [];

                List<Hand> fullHouse = [];

                List<Hand> threeOfAKind = [];

                List<Hand> twoPair = [];

                List<Hand> onePair = [];

                List<Hand> highCard = [];

                string hand;
                int bid;
                int strength;

                string? line = sr.ReadLine();

                while (line != null)
                {
                    hand = line.Split(' ')[0].Trim();
                    bid = int.Parse(line.Split(' ')[1].Trim());
                    strength = GetHandStrength(hand);

                    switch (strength)
                    {
                        case 1:
                            highCard.Add(new(hand, bid));
                            break;
                        case 2:
                            onePair.Add(new(hand, bid));
                            break;
                        case 3:
                            twoPair.Add(new(hand, bid));
                            break;
                        case 4:
                            threeOfAKind.Add(new(hand, bid));
                            break;
                        case 5:
                            fullHouse.Add(new(hand, bid));
                            break;
                        case 6:
                            fourOfAKind.Add(new(hand, bid));
                            break;
                        default:
                            fiveOfAKind.Add(new(hand, bid));
                            break;
                    }

                    line = sr.ReadLine();
                }

                sr.Close();

                int sumOfBids = 0;
                int rank = 1;

                for (int i = 1; i < 8; i++)
                {
                    switch (i)
                    {
                        case 1:
                            foreach (Hand sorted in GetSortedHands(highCard))
                            {
                                sumOfBids += sorted.Bid * rank;
                                rank++;
                            }
                            break;
                        case 2:
                            foreach (Hand sorted in GetSortedHands(onePair))
                            {
                                sumOfBids += sorted.Bid * rank;
                                rank++;
                            }
                            break;
                        case 3:
                            foreach (Hand sorted in GetSortedHands(twoPair))
                            {
                                sumOfBids += sorted.Bid * rank;
                                rank++;
                            }
                            break;
                        case 4:
                            foreach (Hand sorted in GetSortedHands(threeOfAKind))
                            {
                                sumOfBids += sorted.Bid * rank;
                                rank++;
                            }
                            break;
                        case 5:
                            foreach (Hand sorted in GetSortedHands(fullHouse))
                            {
                                sumOfBids += sorted.Bid * rank;
                                rank++;
                            }
                            break;
                        case 6:
                            foreach (Hand sorted in GetSortedHands(fourOfAKind))
                            {
                                sumOfBids += sorted.Bid * rank;
                                rank++;
                            }
                            break;
                        default:
                            foreach (Hand sorted in GetSortedHands(fiveOfAKind))
                            {
                                sumOfBids += sorted.Bid * rank;
                                rank++;
                            }
                            break;
                    }
                }

                return sumOfBids.ToString();
            }
            catch (Exception ex)
            {
                return "Exception: " + ex.Message.ToString();
            }
        }
    }
}

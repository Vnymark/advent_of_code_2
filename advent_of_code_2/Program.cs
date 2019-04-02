using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = @"../../../input.txt";
            //var inputPath = @"../../../test.txt";
            List<string> inputText = File.ReadLines(inputPath).ToList();

            List<Box> BoxList = new List<Box>();
            int checksum = 0;
            string matchedString = null;

            CreateBoxes();
            AddCounts();
            GetCountSum(GetTwoTimesCount(), GetThreeTimesCount());
            Console.WriteLine(checksum);
            MatchBoxes();
            Console.WriteLine(matchedString);
            Console.ReadLine();

            void CreateBoxes()
            {
                foreach (string row in inputText)
                {
                    Box box = new Box();
                    box.Id = new List<char>();
                    foreach (char c in row)
                    {
                        box.Id.Add(c);
                    }
                    
                    BoxList.Add(box);
                }
            }

            void AddCounts()
            {
                foreach(Box box in BoxList)
                {
                    box.BoxIdToLists();
                }
            }

            int GetTwoTimesCount()
            {
                int twoTimesCount = 0;
                foreach (Box box in BoxList)
                {
                    if (box.TwoTimes.Count() != 0)
                    {
                        twoTimesCount++;
                    }
                }
                return twoTimesCount;
            }

            int GetThreeTimesCount()
            {
                int threeTimesCount = 0;
                foreach (Box box in BoxList)
                {
                    if (box.ThreeTimes.Count() != 0)
                    {
                        threeTimesCount++;
                    }
                }
                return threeTimesCount;
            }

            void GetCountSum(int twoTimesCount, int threeTimesCount)
            {
                checksum = twoTimesCount * threeTimesCount;
            }

            void MatchBoxes()
            {
                
                foreach (Box box in BoxList)
                {
                    List<Box> MatchedBoxes = new List<Box>(BoxList);
                    MatchedBoxes.Remove(box);
                    bool matched = false;
                    
                    foreach (Box b in MatchedBoxes)
                    {
                        int i = 0;
                        int m = 0;
                        matchedString = null;
                        while (i < b.Id.Count())
                        {
                            if (b.Id.ElementAt(i) == box.Id.ElementAt(i))
                            {
                                m++;
                                matchedString += b.Id.ElementAt(i);
                            }
                            if (m == (box.Id.Count() - 1))
                            {
                                matched = true;
                                break;
                            }
                            i++;
                        }
                    }
                        
                    if (matched == true)
                    {
                        break;
                    }
                    MatchedBoxes.Add(box);
                }
            }
                
        }
    }
}

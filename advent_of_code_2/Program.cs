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
            //Input
            var inputPath = @"../../../input.txt";
            //var inputPath = @"../../../test.txt";
            List<string> inputText = File.ReadLines(inputPath).ToList();

            //Add Data
            List<Box> BoxList = new List<Box>();
            CreateBoxes();
            AddCounts();
            
            //Part 1
            Console.WriteLine("Checksum: {0}", CountChecksum());

            //Part 2
            Console.WriteLine("Matched id except one (the character not matching): {0}", MatchBoxes());
            Console.ReadLine();

            //Creating boxes from the input.
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

            //Adding Counts to boxes.
            void AddCounts()
            {
                foreach(Box box in BoxList)
                {
                    box.BoxIdToLists();
                }
            }

            //Count the counts on all boxes and calculate the checksum.
            int CountChecksum()
            {
                int twoTimesCount = 0;
                int threeTimesCount = 0;
                foreach (Box box in BoxList)
                {
                    if (box.TwoTimes.Count() != 0)
                    {
                        twoTimesCount++;
                    }
                    if (box.ThreeTimes.Count() != 0)
                    {
                        threeTimesCount++;
                    }
                }
                return twoTimesCount * threeTimesCount;
            }

            //Matches the box id's to each other and returns the string of characters from the id of the two boxes that matches in every character but one.
            string MatchBoxes()
            {
                foreach (Box box in BoxList)
                {
                    List<Box> MatchedBoxes = new List<Box>(BoxList);
                    MatchedBoxes.Remove(box);

                    foreach (Box b in MatchedBoxes)
                    {
                        int i = 0;
                        int m = 0;
                        string matchedString = null;
                        while (i < b.Id.Count())
                        {
                            if (b.Id.ElementAt(i) == box.Id.ElementAt(i))
                            {
                                m++;
                                matchedString += b.Id.ElementAt(i);
                            }
                            if (m == (box.Id.Count() - 1))
                            {
                                return matchedString;
                            }
                            i++;
                        }
                    }
                    MatchedBoxes.Add(box);
                }
                return null;
            }
        }
    }
}

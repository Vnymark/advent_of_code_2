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

            CreateBoxes();
            AddCounts();
            GetCountSum(GetTwoTimesCount(), GetThreeTimesCount());
            Console.WriteLine(checksum);
            Console.ReadLine();

            void CreateBoxes()
            {
                foreach (string row in inputText)
                {
                    Box box = new Box();
                    box.Id = row;
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
        }
    }
}

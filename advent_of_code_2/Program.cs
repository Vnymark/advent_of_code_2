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
        }
    }
}

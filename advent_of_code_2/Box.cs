using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace advent_of_code_2
{
    class Box
    {
        public string Id { get; set; }
        public List<char> TwoTimes { get; set; }
        public List<char> ThreeTimes { get; set; }

        public void BoxIdToLists()
        {
            List<char> TwoTimes = new List<char>();
            List<char> ThreeTimes = new List<char>();
            foreach (char c in this.Id)
            {
                int matchedTimes = this.Id.Count(x => x == c);
        
                if (matchedTimes == 2)
                {
                    TwoTimes.Add(c);
                }
                if (matchedTimes == 3)
                {
                    ThreeTimes.Add(c);
                    TwoTimes.Remove(c);
                }
            }
            this.TwoTimes = TwoTimes.Distinct().ToList();
            this.ThreeTimes = ThreeTimes.Distinct().ToList();
        }
    }
}

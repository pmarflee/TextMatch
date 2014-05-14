using System;
using System.Collections.Generic;
using System.Linq;

namespace TextMatch
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Insufficient arguments.  Expected 'text' and 'subtext'.");
                return;
            }

            string text = args[0];
            string subtext = args[1];

            List<int> indexes = TextMatcher.FindAllIndexesOf(text, subtext).ToList();

            if (indexes.Count == 0) return;

            for (int i = 0; i < indexes.Count; i++)
            {
                Console.Write(indexes[i] + 1);
                if (i < indexes.Count - 1)
                {
                    Console.Write(",");
                }
            }
        }
    }
}
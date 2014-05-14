using System;
using System.Collections.Generic;

namespace TextMatch
{
    public class TextMatcher
    {
        /// <summary>
        ///     Finds all indexes of subtext in text
        /// </summary>
        /// <param name="text">The text to search</param>
        /// <param name="subtext">The subtext to search for</param>
        /// <returns>A sequence of zero-based indexes where subtext was found in text</returns>
        public static IEnumerable<int> FindAllIndexesOf(string text, string subtext)
        {
            int? index;
            int start = 0;
            while (TryFindIndexOf(text, subtext, start, out index))
            {
                yield return index.Value;
                start = index.Value + subtext.Length;
            }
        }

        /// <summary>
        ///     Finds the next index of subtext in text, starting from a particular index
        /// </summary>
        /// <param name="text">The text to search</param>
        /// <param name="subtext">The subtext to search for</param>
        /// <param name="start">The zero-based index in text to begin the search from</param>
        /// <param name="index">If the search is successful, the zero-index where subtext was first found in text, otherwise null</param>
        /// <returns>True if the search is successful, otherwise false</returns>
        internal static bool TryFindIndexOf(string text, string subtext, int start, out int? index)
        {
            if (String.IsNullOrEmpty(text) || String.IsNullOrEmpty(subtext) || start < 0 || text.Length < subtext.Length)
            {
                index = null;
                return false;
            }

            int textIndex = start;

            while (textIndex < text.Length)
            {
                int subtextIndex = 0;
                bool matched = true;

                while (subtextIndex < subtext.Length)
                {
                    int textIndexOffset = textIndex + subtextIndex;

		    // Abandon the match if we have run out of characters to search or if the characters don't match at the current search position
                    if (textIndexOffset >= text.Length || !AreCharsEqual(text[textIndexOffset], subtext[subtextIndex]))
                    {
                        matched = false;
                        break;
                    }

                    subtextIndex++;
                }

                if (matched)
                {
                    index = textIndex;
                    return true;
                }

                textIndex++;
            }

            index = null;
            return false;
        }

        /// <summary>
        ///     Performs a case-insensitive comparison between two char instances
        /// </summary>
        /// <param name="first">The first char instance to compare</param>
        /// <param name="second">The second char instance to compare</param>
        /// <returns>True if the instances are considered equal, otherwise false</returns>
        private static bool AreCharsEqual(char first, char second)
        {
            return char.ToUpperInvariant(first) == char.ToUpperInvariant(second);
        }
    }
}
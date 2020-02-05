namespace Prospa.BusinessMatcher.Service.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class StringExtensions
    {
        /// <summary>
        /// Splits a string into substrings on characters satisfying the predicate. Automatically handles end of string.
        /// </summary>
        /// <param name="predicate">condition to satisfy to split the string</param>
        /// <returns>An array whose elements contain the substrings from this instance</returns>
        public static string[] Split(this string value, Predicate<char> predicate) 
        {
            var result = new List<string>();
            if (value != null && value.Trim().Length > 0)
            {
                List<char> charList = value.ToList();

                var word = string.Empty;

                for (int i = 0; i <= charList.Count; i++)
                {
                    var c = charList.ElementAtOrDefault(i);
                    if (predicate(c) || c == '\0')
                    {
                        if (!string.IsNullOrWhiteSpace(word)) 
                        {
                            result.Add(word.Trim());
                        }

                        word = string.Empty;
                    }
                    else
                    {
                        word += c;
                    }
                }
            }

            return result.ToArray();
        }
    }
}

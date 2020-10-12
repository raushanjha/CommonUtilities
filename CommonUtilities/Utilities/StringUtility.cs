using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CommonUtilities.Utilities
{
    public class StringUtility
    {
        public static bool AreEqual(string input1, string input2)
        {
            return string.Equals(input1, input2, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Check for string equality after TRIM operation
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        public static bool AreTrimEqual(string input1, string input2)
        {
            return string.Equals(input1?.Trim(), input2?.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }


        public static bool AreNotEqual(string input1, string input2)
        {
            return !AreEqual(input1, input2);
        }

        /// <summary>
        /// Check for non-equality of string after TRIM operation
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        public static bool AreNotTrimEqual(string input1, string input2)
        {
            return !AreTrimEqual(input1, input2);
        }
        public static bool IsNull(string input)
        {
            return null == input;
        }

        public static bool IsNotNull(string input)
        {
            return !IsNull(input);
        }

        public static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        public static bool IsNotNullOrEmpty(string input)
        {
            return !IsNullOrEmpty(input);
        }

        public static bool IsNullOrWhiteSpace(string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        public static bool IsNotNullOrWhiteSpace(string input)
        {
            return !IsNullOrWhiteSpace(input);
        }

        public static string TrimStart(string input)
        {
            return input?.TrimStart();
        }

        public static string TrimEnd(string input)
        {
            return input?.TrimEnd();
        }

        public static string Trim(string input)
        {
            return input?.Trim();
        }

        public static string ToUpper(string input)
        {
            return input?.ToUpper();
        }

        public static string ToLower(string input)
        {
            return input?.ToLower();
        }

        /// <summary>
        /// Find the position of "searchString" withing the given "mainString"
        /// </summary>
        /// <param name="mainString"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public static int FindStringPositionWithinString(string mainString, string searchString)
        {
            return IsNull(mainString) || IsNull(searchString)
                ? -1
                : mainString.IndexOf(searchString, StringComparison.Ordinal);
        }

        /// <summary>
        /// Replace the "errorString" with "correctString" within "mainString" 
        /// </summary>
        /// <param name="mainString">Main string which which replace is to be done.</param>
        /// <param name="errorString"></param>
        /// <param name="correctString"></param>
        /// <returns></returns>
        public static string ReplaceString(string mainString, string errorString, string correctString)
        {
            return IsNullOrEmpty(mainString)
                ? mainString
                : mainString.Replace(errorString, correctString);
        }

        /// <summary>
        /// Convert the given string in title case (e.g.: "title case string => Title Case String")
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string ToTitleCase(string title)
        {
            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            var textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(title);
        }

        //Reverses a string
        //Hello -> olleH
        public static string Reverse(string input)
        {
            var ret = new StringBuilder();
            for (var i = input.Length - 1; i >= 0; i--)
            {
                ret.Append(input.Substring(i, 1));
            }
            return ret.ToString();
        }

        //Returns an array converted into a string
        public static string ArrayToString(Array input, string separator)
        {
            var ret = new StringBuilder();
            for (var i = 0; i < input.Length; i++)
            {
                ret.Append(input.GetValue(i));
                if (i != input.Length - 1)
                    ret.Append(separator);
            }
            return ret.ToString();
        }

        //Capitalizes a word or sentence
        //word -> Word
        //OR
        //this is a sentence -> This is a sentence
        public static string Capitalize(string input)
        {
            if (input.Length == 0) return string.Empty;
            if (input.Length == 1) return input.ToUpper();

            return input.Substring(0, 1).ToUpper() + input.Substring(1);
        }

        //Checks whether a word or sentence is capitalized
        //Word -> True
        //OR
        //This is a sentence -> True
        public static bool IsCapitalized(string input)
        {
            if (input.Length == 0) return false;
            return string.CompareOrdinal(input.Substring(0, 1), input.Substring(0, 1).ToUpper()) == 0;
        }

        //Checks whether a string is in all lower case
        //word -> True
        //Word -> False
        public static bool IsLowerCase(string input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (string.CompareOrdinal(input.Substring(i, 1), input.Substring(i, 1).ToLower()) != 0)
                    return false;
            }
            return true;
        }

        //Checks whether a string is in all upper case
        //word -> False
        //Word -> False
        //WORD -> True
        public static bool IsUpperCase(string input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (string.CompareOrdinal(input.Substring(i, 1), input.Substring(i, 1).ToUpper()) != 0)
                    return false;
            }
            return true;
        }

        //Alternates cases between letters of a string, first letter's case stays the same
        //Hi -> Hi
        //longstring -> lOnGsTrInG
        public static string AlternateCases(string input)
        {
            if (input.Length == 0) return string.Empty;
            if (input.Length == 1) return input; //Cannot automatically alternate

            var firstIsUpper = string.CompareOrdinal(input.Substring(0, 1), input.Substring(0, 1).ToUpper()) != 0;
            var ret = input.Substring(0, 1);
            for (var i = 1; i < input.Length; i++)
            {
                if (firstIsUpper)
                    ret += input.Substring(i, 1).ToUpper();
                else
                    ret += input.Substring(i, 1).ToLower();

                firstIsUpper = !firstIsUpper;
            }

            return ret;
        }

        //Checks to see if a string has alternate cases
        //lOnGsTrInG -> True
        public static bool IsAlternateCases(string input)
        {
            if (input.Length <= 1) return false;

            var lastIsUpper = string.CompareOrdinal(input.Substring(0, 1), input.Substring(0, 1).ToUpper()) == 0;

            for (var i = 1; i < input.Length; i++)
            {
                if (lastIsUpper)
                {
                    if (string.CompareOrdinal(input.Substring(i, 1), input.Substring(i, 1).ToLower()) != 0)
                        return false;
                }
                else
                {
                    if (string.CompareOrdinal(input.Substring(i, 1), input.Substring(i, 1).ToUpper()) != 0)
                        return false;
                }

                lastIsUpper = !lastIsUpper;
            }

            return true;
        }

        //Counts total number of a char or chars in a string
        //hello, l -> 2
        //hello, el -> 1
        public static int CountTotal(string input, string chars, bool ignoreCases)
        {
            var count = 0;
            for (var i = 0; i < input.Length; i++)
            {
                if (!(i + chars.Length > input.Length) &&
                    string.Compare(input.Substring(i, chars.Length), chars, ignoreCases) == 0)
                {
                    count++;
                }
            }
            return count;
        }

        //Checks to see if a string contains vowels
        //hello -> True
        //rmv -> False
        public static bool HasVowels(string input)
        {
            string currentLetter;
            for (var i = 0; i < input.Length; i++)
            {
                currentLetter = input.Substring(i, 1);

                if (string.Compare(currentLetter, "a", StringComparison.OrdinalIgnoreCase) == 0 ||
                    string.Compare(currentLetter, "e", StringComparison.OrdinalIgnoreCase) == 0 ||
                    string.Compare(currentLetter, "i", StringComparison.OrdinalIgnoreCase) == 0 ||
                    string.Compare(currentLetter, "o", StringComparison.OrdinalIgnoreCase) == 0 ||
                    string.Compare(currentLetter, "u", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    //A vowel found
                    return true;
                }
            }

            return false;
        }

        //Checks if string is nothing but spaces
        //"        " -> True
        public static bool IsSpaces(string input)
        {
            if (input.Length == 0) return false;
            return input.Replace(" ", "").Length == 0;
        }

        //Checks if the string has all the same letter/number
        //aaaaaaaaaaaaaaaaaaa -> true
        //aaaaaaaaaaaaaaaaaab -> false
        public static bool IsRepeatedChar(string input)
        {
            if (input.Length == 0) return false;
            return input.Replace(input.Substring(0, 1), "").Length == 0;
        }

        //Checks if string has only numbers
        //12453 -> True
        //234d3 -> False
        public static bool IsNumeric(string input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (!(Convert.ToInt32(input[i]) >= 48 && Convert.ToInt32(input[i]) <= 57))
                {
                    //Not integer value
                    return false;
                }
            }
            return true;
        }

        //Checks if the string contains numbers
        //hello -> False
        //h3llo -> True
        public static bool HasNumbers(string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, "\\d+");
        }

        //Checks if string is numbers and letters
        //Test1254 -> True
        //$chool! -> False
        public static bool IsAlphaNumberic(string input)
        {
            char currentLetter;
            for (var i = 0; i < input.Length; i++)
            {
                currentLetter = input[i];

                if (!(Convert.ToInt32(currentLetter) >= 48 && Convert.ToInt32(currentLetter) <= 57) &&
                    !(Convert.ToInt32(currentLetter) >= 65 && Convert.ToInt32(currentLetter) <= 90) &&
                    !(Convert.ToInt32(currentLetter) >= 97 && Convert.ToInt32(currentLetter) <= 122))
                {
                    //Not a number or a letter
                    return false;
                }
            }
            return true;
        }

        //Checks if a string contains only letters
        //Hi -> True
        //Hi123 -> False
        public static bool IsLetters(string input)
        {
            char currentLetter;
            for (var i = 0; i < input.Length; i++)
            {
                currentLetter = input[i];

                if (!(Convert.ToInt32(currentLetter) >= 65 && Convert.ToInt32(currentLetter) <= 90) &&
                    !(Convert.ToInt32(currentLetter) >= 97 && Convert.ToInt32(currentLetter) <= 122))
                {
                    //Not a letter
                    return false;
                }
            }
            return true;
        }

        // Returns the initials of a name or sentence
        //capitalize - whether to make intials capitals
        //includeSpace - to return intials separated (True - J. S. or False - J.S.)
        //John Smith -> J. S. or J.S.
        public static string GetInitials(string input, bool capitalize, bool includeSpace)
        {
            var words = input.Split(new char[] { ' ' });

            for (var i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                    if (capitalize)
                        words[i] = words[i].Substring(0, 1).ToUpper() + ".";
                    else
                        words[i] = words[i].Substring(0, 1) + ".";
            }

            if (includeSpace)
                return string.Join(" ", words);
            else
                return string.Join("", words);
        }

        //Capitalizes the first letter of every word
        //the big story -> The Big Story
        public static string GetTitle(string input)
        {
            var words = input.Split(new char[] { ' ' });

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                    words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1);
            }

            return string.Join(" ", words);
        }

        /*

        Checks whether
        the first
        letter of
        each word
    is
        capitalized */
        //The Big Story -> True
        //The big story -> False
        public static bool IsTitle(string input)
        {
            var words = input.Split(new char[] { ' ' });

            for (var i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                    if (string.CompareOrdinal(words[i].Substring(0, 1).ToUpper(), words[i].Substring(0, 1)) != 0)
                        return false;
            }
            return true;
        }

        //Returns all the locations of a char in a string
        //Hello, l -> 2, 3
        //Hello, o -> 4
        //Bob, 1 -> -1
        public static int[] IndexOfAll(string input, string chars)
        {
            var indices = new List<int>();
            for (var i = 0; i < input.Length; i++)
            {
                if (input.Substring(i, 1) == chars)
                    indices.Add(i);
            }

            if (indices.Count == 0)
                indices.Add(-1);

            return indices.ToArray();
        }

        //Gets the char in a string at a given position, but counting from right to left
        //string, 0 -> g
        public static char CharRight(string input, int index)
        {
            if (input.Length - index - 1 >= input.Length ||
                input.Length - index - 1 < 0)
                return new char();

            var str = input.Substring(input.Length - index - 1, 1);
            return str[0];
        }

        //Gets the char in a string from a starting position plus the index
        //string, 3, 1 -> n
        public static char CharMid(string input, int startingIndex, int countIndex)
        {
            if (startingIndex + countIndex < input.Length)
            {
                var str = input.Substring(startingIndex + countIndex, 1);
                return str[0];
            }
            else
                return new char();
        }

        //Function that works the same way as the default Substring, but
        //it takes Start and End (exclusive) parameters instead of Start and Length
        //hello, 1, 3 -> el
        public static string SubstringEnd(string input, int start, int end)
        {
            if (start > end) //Flip the values
            {
                start ^= end;
                end = start ^ end;
                start ^= end;
            }

            if (end > input.Length) end = input.Length; //avoid errors

            return input.Substring(start, end - start);

        }

        /// <summary>
        /// Join string items, each item separate by ","
        /// </summary>
        /// <param name="separator">default separator will be ","</param>
        /// <param name="input">IList of strings</param>
        /// <returns>Concatenated value</returns>
        public static string Join(IList<string> input, string separator = ", ")
        {
            return string.Join(separator, input);
        }

        /// <summary>
        /// Join string items, each item separate by ","
        /// </summary>
        /// <param name="separator">default separator will be ","</param>
        /// <param name="input">IEnumerable of strings</param>
        /// <returns>Concatenated value</returns>
        public static string Join(IEnumerable<string> input, string separator = ",")
        {
            return string.Join(separator, input);
        }

        /// <summary>
        /// Join string items, each item separate by ","
        /// </summary>
        /// <param name="separator">default separator will be ","</param>
        /// <param name="input">IList of strings</param>
        /// <returns>Concatenated value</returns>
        public static string Join(string separator = ",", params string[] input)
        {
            return string.Join(separator, input);
        }
    }
}

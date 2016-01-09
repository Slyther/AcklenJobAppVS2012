using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AcklenAveJobApp.Algorithms
{
    public enum ConcatenationType
    {
        Asterisks,
        ASCII
    }

    public class Algorithms
    {
        public HashSet<char> Vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'y' };
        public HashSet<char> Consonants = new HashSet<char> { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };
        public HashSet<string> VowelPairs;
        public HashSet<string> EnglishWords = new HashSet<string> { "drool", "cats", "clean", "code", "dogs", "materials", "needed", "this", "is",
                                                                           "hard", "what", "are", "you", "smoking", "shot", "gun", "down", "river", "super",
                                                                           "man", "rule", "acklen", "developers", "are", "amazing" };

        public Algorithms()
        {
            BuilVowelPairs();
        }

        public void BuilVowelPairs()
        {
            VowelPairs = new HashSet<string>();
            foreach (var vowel in Vowels)
            {
                foreach (var vowel1 in Vowels)
                {
                    VowelPairs.Add(vowel + vowel1 + "");
                }
            }
        }

        public string Base64Encode(string plaintext)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plaintext);
            return Convert.ToBase64String(plainTextBytes);
        }

        public IEnumerable<string> SortArray(IEnumerable<string> array, bool reverse)
        {
            var list = array.ToList();
            list.Sort(StringComparer.Create(new CultureInfo("en-US"), true));
            if (reverse)
                list.Reverse();
            return list.AsEnumerable();
        }

        public IEnumerable<string> ScrambleArrayText(IEnumerable<string> array)
        {
            var list = array.ToList();
            var toReturn = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                var element = list.ElementAt(i);
                if (!element.Any(n => Vowels.Contains(char.ToLower(n))))
                {
                    toReturn.Add(element);
                    continue;
                }
                var modifiedElement = new StringBuilder(list.ElementAt(i));
                for (int j = 0; j < modifiedElement.Length; j++)
                {
                    if (Vowels.Any(n => char.ToLower(modifiedElement[j]).Equals(n)))
                    {
                        if (j == modifiedElement.Length - 1)
                        {
                            char temp = modifiedElement[j];
                            modifiedElement.Remove(j, 1);
                            modifiedElement.Insert(0, temp);
                            continue;
                        }
                        if (Vowels.Any(n => char.ToLower(modifiedElement[j + 1]).Equals(n)))
                        {
                            if ((char.IsUpper(modifiedElement[j]) && char.IsUpper(modifiedElement[j + 1])) || (char.IsLower(modifiedElement[j]) && char.IsLower(modifiedElement[j + 1])))
                                continue;
                        }
                        char temp2 = modifiedElement[j];
                        modifiedElement.Remove(j, 1);
                        modifiedElement.Insert(j + 1, temp2);
                        j++;
                    }
                }
                toReturn.Add(modifiedElement.ToString());
            }
            return toReturn.AsEnumerable();
        }

        public string ConcatenateArrayText(IEnumerable<string> array, ConcatenationType concatenationType)
        {
            var toReturn = "";
            if (concatenationType.Equals(ConcatenationType.Asterisks))
            {
                toReturn = array.Aggregate(toReturn, (current, element) => current + (element + "*"));
                toReturn = toReturn.Remove(toReturn.Length - 1);
            }
            else
            {
                for (int i = 0; i < array.Count(); i++)
                {
                    var value = Encoding.ASCII.GetBytes(new[] { array.ElementAt((i == 0 ? array.Count() : i) - 1).ElementAt(0) })[0];
                    toReturn += array.ElementAt(i) + value;
                }
            }
            return toReturn;
        }

        public IEnumerable<string> SplitWords(IEnumerable<string> array)
        {
            var toReturn = new List<string>();
            foreach (var element in array)
            {
                var modifiedElement = element;
                if (!modifiedElement.ToLower().Equals("decoder") && (from englishWord in EnglishWords //Patch to prevent the word "decoder" from being mangled to death
                                                                     let culture = new CultureInfo("en-US")
                                                                     where
                                                                         culture.CompareInfo.IndexOf(modifiedElement, englishWord, CompareOptions.IgnoreCase) >= 0 &&
                                                                         modifiedElement.Length > englishWord.Length
                                                                     select englishWord).Any())
                {
                    string pattern = "(" + string.Join("|", EnglishWords.Select(d => Regex.Escape(d))
                        .ToArray()) + ")";
                    var parts = Regex.Split(modifiedElement, pattern, RegexOptions.IgnoreCase).ToList();
                    parts.RemoveAll(p => p.Equals(""));
                    toReturn.AddRange(parts);
                }
                else
                {
                    toReturn.Add(modifiedElement);
                }
            }
            return toReturn.AsEnumerable();
        }

        public IEnumerable<string> AlternateConsonants(IEnumerable<string> array)
        {
            bool upperCase = false;
            bool first = true;
            var toReturn = new List<string>();
            for (int i = 0; i < array.Count(); i++)
            {
                var element = new StringBuilder(array.ElementAt(i));
                for (int n = 0; n < element.Length; n++)
                {
                    if (first)
                    {
                        upperCase = char.IsUpper(element[n]);
                        first = false;
                    }
                    if (Consonants.Contains(char.ToLower(element[n])))
                    {
                        element[n] = upperCase ? char.ToUpper(element[n]) : char.ToLower(element[n]);
                        upperCase = !upperCase;
                    }
                }
                toReturn.Add(element.ToString());
            }
            return toReturn.AsEnumerable();
        }

        public IEnumerable<string> FibonacciMagic(IEnumerable<string> array, double startingFibonacciNumber)
        {
            double previousFibonacciNumber = 0;
            bool first = true;
            var toReturn = new List<string>();
            for (int i = 0; i < array.Count(); i++)
            {
                var element = new StringBuilder(array.ElementAt(i));
                for (int n = 0; n < element.Length; n++)
                {
                    if (Vowels.Contains(char.ToLower(element[n])))
                    {
                        element.Remove(n, 1);
                        element.Insert(n, (startingFibonacciNumber).ToString());
                        if (first)
                        {
                            var phi = 1.6180339887498948482;
                            previousFibonacciNumber = startingFibonacciNumber;
                            startingFibonacciNumber += Math.Round(startingFibonacciNumber / phi);
                            first = false;
                        }
                        else
                        {
                            var temp = startingFibonacciNumber;
                            startingFibonacciNumber += previousFibonacciNumber;
                            previousFibonacciNumber = temp;
                        }
                    }
                }
                toReturn.Add(element.ToString());
            }
            return toReturn.AsEnumerable();
        }
    }
}
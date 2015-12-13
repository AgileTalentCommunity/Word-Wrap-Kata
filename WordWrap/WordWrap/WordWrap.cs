using System;
using System.Collections.Generic;
using System.Linq;

namespace WordWrap
{
    internal class WordWrap
    {
        internal static string Wrap(string input, int columnNumber)
        {
            if(columnNumber < 1) throw new ArgumentOutOfRangeException(nameof(columnNumber));
            if (columnNumber >= input.Length)
                return input;
            var inputArray = new List<char>();
            var inputTreated = string.Empty;
            for (int i = 0; i < input.Length && i <= columnNumber; i++)
            {
                inputArray.Add(input[i]);
                if (i == columnNumber)
                {
                    if (input[i] == ' ')
                    {
                        inputArray[i] = '\n';
                        inputTreated += input[i];
                    }
                    else if (inputArray.Contains(' '))
                    {
                        var spacePosition = inputArray.FindLastIndex(c => c == ' ');
                        inputArray[spacePosition] = '\n';
                        inputArray = inputArray.Take(spacePosition + 1).ToList();
                        inputTreated = input.Substring(0, spacePosition + 1);
                    }
                    else
                    {
                        inputArray[i] = '\n';
                    }
                }
                else
                {
                    inputTreated += input[i];
                }
            }
            //return input.ToString();
            return new string(inputArray.ToArray()) + Wrap(input.Replace(inputTreated, ""), columnNumber);            
        }
    }
}
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
            if (columnNumber >= input.Length) return input;
            var inputArray = new List<char>();
            var inputTreated = string.Empty;
            for (var i = 0; i < input.Length && i <= columnNumber; i++)
            {
                inputArray.Add(input[i]);
                if (!IsLastCharacterInColumn(columnNumber, i)) inputTreated += input[i];
                else
                {                    
                    if (IsBreakOnWordAndHasAnSpace(input, i, inputArray))
                    {
                        inputArray = ComeBackToLastSpace(input, inputArray, ref inputTreated);
                    }
                    else
                    {
                        inputTreated = BreakOnWord(input, inputArray, i, inputTreated);
                    }
                }
            }
            return CallRecursive(input, columnNumber, inputArray, inputTreated);            
        }

        private static string BreakOnWord(string input, List<char> inputArray, int i, string inputTreated)
        {
            inputArray[i] = '\n';
            if (input[i] == ' ')
            {
                inputTreated += input[i];
            }
            return inputTreated;
        }

        private static bool IsBreakOnWordAndHasAnSpace(string input, int i, List<char> inputArray)
        {
            return input[i] != ' ' && inputArray.Contains(' ');
        }

        private static string CallRecursive(string input, int columnNumber, List<char> inputArray, string inputTreated)
        {
            return new string(inputArray.ToArray()) + Wrap(input.Replace(inputTreated, ""), columnNumber);
        }

        private static List<char> ComeBackToLastSpace(string input, List<char> inputArray, ref string inputTreated)
        {
            var spacePosition = inputArray.FindLastIndex(c => c == ' ');
            inputArray[spacePosition] = '\n';
            inputArray = inputArray.Take(spacePosition + 1).ToList();
            inputTreated = input.Substring(0, spacePosition + 1);
            return inputArray;
        }

        private static bool IsLastCharacterInColumn(int columnNumber, int i)
        {
            return i == columnNumber;
        }
    }
}
using System;
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
            var inputArray = input.ToList();
            for (int i = 0; i < inputArray.Count; i++)
            {
                if (i == columnNumber)
                {
                    if (inputArray[i] == ' ')
                    {
                        inputArray[i] = '\n';
                    }
                    else if(inputArray.Contains(' '))
                    {
                        var spacePosition = inputArray.FindLastIndex(c => c == ' ');
                        inputArray[spacePosition] = '\n';

                    }
                }
            }
            return new string(inputArray.ToArray());            
        }
    }
}
using System;

namespace WordWrap
{
    internal class WordWrap
    {
        internal static string Wrap(string input, int columnNumber)
        {
            if(columnNumber < 1) throw new ArgumentOutOfRangeException(nameof(columnNumber));
            if (columnNumber >= input.Length)
                return input;
            var inputArray = input.ToCharArray();
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (i == columnNumber)
                {
                    if (inputArray[i] == ' ')
                    {
                        inputArray[i] = '\n';
                    }
                }
            }
            return new string(inputArray);            
        }
    }
}
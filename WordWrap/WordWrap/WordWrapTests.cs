﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using NUnit.Framework;

namespace WordWrap
{
    public class WordWrapTests
    {
        [Test]
        public void Should_throw_exception_when_column_number_is_not_bigger_than_zero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                WordWrap.Wrap(string.Empty, 0);
            });
        }

        [Test]
        public void Should_return_the_input_when_column_number_is_equals_or_bigger_than_input_lenght()
        {
            var actual = WordWrap.Wrap("Small", 10);
            Check.That(actual).IsEqualTo("Small");
        }



        [Test]
        public void Should_return_word_newline_when_input_is_word_space_and_column_number_is_4()
        {
            var actual = WordWrap.Wrap("word ", 4);
            Check.That(actual).IsEqualTo("word\n");
        }

        [Test]
        public void Should_return_word_newline_word_when_input_is_wordword_and_column_number_is_4()
        {
            var actual = WordWrap.Wrap("word word", 4);
            Check.That(actual).IsEqualTo("word\nword");
        }
    }

    internal class WordWrap
    {
        internal static string Wrap(string input, int columnNumber)
        {
            if(columnNumber < 1) throw new ArgumentOutOfRangeException(nameof(columnNumber));
            var line = string.Empty;
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

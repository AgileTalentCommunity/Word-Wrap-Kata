using System;
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



        [TestCase("word ", 4, "word\n")]
        [TestCase("word word", 4, "word\nword")]
        [TestCase("abcd efgh ijkl", 4, "abcd\nefgh\nijkl")]
        public void Should_return_space_replaced_by_newlines_when_the_column_numner_match_with_a_space_in_the_input(string input, int columnNumber, string expected)
        {
            var actual = WordWrap.Wrap(input, columnNumber);
            Check.That(actual).IsEqualTo(expected);
        }
       
        [TestCase("a bc", 3, "a\nbc")]
        [TestCase("Like a word processor, break the line by replacing the last space in a line with a newline", 9, "Like a\nword\nprocessor\n, break\nthe line\nby\nreplacing\nthe last\nspace in\na line\nwith a\nnewline")]
        public void Should_avoid_breaking_line_in_middle_of_word_if_there_is_an_space(string input, int columnNumber, string expected)
        {
            var actual = WordWrap.Wrap(input, columnNumber);
            Check.That(actual).IsEqualTo(expected);
        }

        [Test]
        public void Should_break_word_if_no_space_found()
        {
            var actual = WordWrap.Wrap("abcd", 2);
            Check.That(actual).IsEqualTo("ab\ncd");
        }
    }
}

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

        [Test]
        public void Should_return_a_newline_bc_when_input_is_a_space_bc_and_column_number_is_3()
        {
            var actual = WordWrap.Wrap("a bc", 3);
            Check.That(actual).IsEqualTo("a\nbc");
        }
    }
}

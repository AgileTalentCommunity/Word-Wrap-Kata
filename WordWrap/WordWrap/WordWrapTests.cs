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
    }

    internal class WordWrap
    {
        internal static string Wrap(string input, int columNumber)
        {
            if(columNumber < 1) throw new ArgumentOutOfRangeException(nameof(columNumber));
            if (columNumber >= input.Length)
                return input;
            return input;
        }
    }
}

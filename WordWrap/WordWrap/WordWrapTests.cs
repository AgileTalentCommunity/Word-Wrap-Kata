using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }

    internal class WordWrap
    {
        internal static void Wrap(string input, int columNumber)
        {
            throw new ArgumentOutOfRangeException(nameof(columNumber));
        }
    }
}

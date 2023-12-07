using System.Collections;
using System.Collections.Generic;
using API;
using Xunit;

namespace Tests
{
    public class SolutionTests
    {
        [Theory]
        [ClassData(typeof(Data))]
        public void CheckSolution(int expected, params string[] lines)
        {
            var actual = new Solution().Sum(lines);
            Assert.Equal(expected, actual);
        }

    }

    public class Data : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                142,
                "1abc2",
                "pqr3stu8vwx",
                "a1b2c3d4e5f",
                "treb7uchet"
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
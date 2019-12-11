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
        public void CheckSolution(int x, int y, int expected)
        {
            var actual = new Solution().Sum(x, y);
            Assert.Equal(expected, actual);
        }

    }

    public class Data : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {

            yield return new object[] { 1, 2, 3 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
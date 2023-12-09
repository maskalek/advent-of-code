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
                281,
                "two1nine", 
                "eightwothree",
                "abcone2threexyz", 
                "xtwone3four", 
                "4nineeightseven2",
                "zoneight234", 
                "7pqrstsixteen"
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
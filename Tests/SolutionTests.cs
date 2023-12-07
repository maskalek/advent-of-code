using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using API;
using Xunit;

namespace Tests
{
    public class SolutionTests
    {
        [Theory]
        [ClassData(typeof(Data))]
        public void CheckSolution(int expected, params string[] cards)
        {
            var actual = new Solution().GetTotalWining(cards);
            Assert.Equal(expected, actual);
        }


    class Data : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                6440,
                "32T3K 765",
                "T55J5 684",
                "KK677 28",
                "KTJJT 220",
                "QQQJA 483"
            };
            yield return new object[]
            {
                10,
                "AAAAA 1",
                "KKKKT 2",
                "QQQTT 3"
            };
            yield return new object[]
            {
                3,
                "AAAAA 2",
                "AAAAA 1"
            };
            yield return new object[]
            {
                3,
                "AAAAA 2",
                "AAAAA 1"
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    }

}
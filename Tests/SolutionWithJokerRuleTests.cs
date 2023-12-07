using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using API;
using Xunit;

namespace Tests
{
    public class SolutionWithJokerRuleTests
    {
        [Theory]
        [InlineData("AAAAA")]
        [InlineData("AAAAJ")]
        [InlineData("AAAJJ")]
        [InlineData("JAAAJ")]
        [InlineData("AJAJA")]
        [InlineData("AAJJJ")]
        [InlineData("AJJJJ")]
        [InlineData("JJJJJ")]
        public void GetHandType_ShouldBeFiveOfKind(string hand)
        {
            Assert.Equal(SolutionWithJokerRule.EHandType.FiveOfKind, new SolutionWithJokerRule().GetHandType(hand));
        }
        
        [Theory]
        [InlineData("AAAJQ")]
        [InlineData("AAJJQ")]
        [InlineData("AJJJQ")]
        [InlineData("JJJAQ")]
        [InlineData("JAAJQ")]
        [InlineData("JAAQJ")]
        public void GetHandType_ShouldBeFourOfKind(string hand)
        {
            Assert.Equal(SolutionWithJokerRule.EHandType.FourOfKind, new SolutionWithJokerRule().GetHandType(hand));
        }
        
        [Theory]
        [InlineData("AAAQQ")]
        [InlineData("AAJQQ")]
        public void GetHandType_ShouldBeFullHouse(string hand)
        {
            Assert.Equal(SolutionWithJokerRule.EHandType.FullHouse, new SolutionWithJokerRule().GetHandType(hand));
        }
        
        [Theory]
        [ClassData(typeof(Data))]
        public void CheckSolution(int expected, params string[] cards)
        {
            var actual = new SolutionWithJokerRule().GetTotalWining(cards);
            Assert.Equal(expected, actual);
        }


        public class Data : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    5905,
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
                    5,
                    "JJJJJ 2",
                    "AAAAB 1"
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
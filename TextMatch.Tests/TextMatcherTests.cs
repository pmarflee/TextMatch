using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TextMatch.Tests
{
    [TestFixture]
    public class TextMatcherTests
    {
        private const string Text =
            "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";

        [TestFixture]
        public class TryFindIndexOfTests
        {
            [Test]
            public void Should_Find_First_Instance_Of_Subtext_Polly_At_Index_0()
            {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf(Text, "Polly", 0, out index);
                Assert.IsTrue(isMatch);
                Assert.AreEqual(0, index);
            }

            [Test]
            public void Should_Find_Second_Instance_Of_Subtext_Polly_At_Index_25()
            {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf(Text, "Polly", 1, out index);
                Assert.IsTrue(isMatch);
                Assert.AreEqual(25, index);
            }

            [Test]
            public void Should_Find_Third_Instance_Of_Subtext_Polly_At_Index_50()
            {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf(Text, "Polly", 26, out index);
                Assert.IsTrue(isMatch);
                Assert.AreEqual(50, index);
            }

            [Test]
            public void Should_Find_First_Instance_Of_Subtext_ll_At_Index_2()
            {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf(Text, "ll", 0, out index);
                Assert.IsTrue(isMatch);
                Assert.AreEqual(2, index);
            }

            [Test]
            public void Should_Find_Second_Instance_Of_Subtext_ll_At_Index_27()
            {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf(Text, "ll", 3, out index);
                Assert.IsTrue(isMatch);
                Assert.AreEqual(27, index);
            }

            [Test]
            public void Should_Find_Third_Instance_Of_Subtext_ll_At_Index_52()
            {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf(Text, "ll", 28, out index);
                Assert.IsTrue(isMatch);
                Assert.AreEqual(52, index);
            }

            [Test]
            public void Should_Find_Fourth_Instance_Of_Subtext_ll_At_Index_77()
            {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf(Text, "ll", 53, out index);
                Assert.IsTrue(isMatch);
                Assert.AreEqual(77, index);
            }

            [Test]
            public void Should_Find_Fifth_Instance_Of_Subtext_ll_At_Index_81()
            {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf(Text, "ll", 78, out index);
                Assert.IsTrue(isMatch);
                Assert.AreEqual(81, index);
            }

            [Test]
            public void Should_Find_No_Match_For_Subtext_X()
            {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf(Text, "X", 0, out index);
                Assert.IsFalse(isMatch);
                Assert.AreEqual(null, index);
            }

            [Test]
            public void Should_Find_No_Match_For_Subtext_Polx()
            {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf(Text, "Polx", 0, out index);
                Assert.IsFalse(isMatch);
                Assert.AreEqual(null, index);
            }

	    [Test]
	    public void Should_Find_Match_At_Index_0_When_Subtext_Equals_Text()
	    {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf(Text, Text, 0, out index);
                Assert.True(isMatch);
                Assert.AreEqual(0, index);
	    }

            [Test]
            public void Should_Find_No_Match_When_Subtext_Is_Longer_Than_Text()
            {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf(Text, Text + "s", 0, out index);
                Assert.IsFalse(isMatch);
                Assert.AreEqual(null, index);
            }

	    [Test]
	    public void Should_Find_No_Match_When_Text_Is_Null()
	    {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf(null, "Polly", 0, out index);
                Assert.IsFalse(isMatch);
                Assert.AreEqual(null, index);
	    }

	    [Test]
	    public void Should_Find_No_Match_When_Text_Is_Empty()
	    {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf("", "Polly", 0, out index);
                Assert.IsFalse(isMatch);
                Assert.AreEqual(null, index);
	    }

	    [Test]
	    public void Should_Find_No_Match_When_Subtext_Is_Null()
	    {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf(Text, null, 0, out index);
                Assert.IsFalse(isMatch);
                Assert.AreEqual(null, index);
	    }

	    [Test]
	    public void Should_Find_No_Match_When_Subtext_Is_Empty()
	    {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf(Text, "", 0, out index);
                Assert.IsFalse(isMatch);
                Assert.AreEqual(null, index);
	    }

	    [Test]
	    public void Should_Find_First_Instance_Of_Subtext_aa_In_Text_aaaa_At_Index_0()
	    {
		int? index;
		bool isMatch = TextMatcher.TryFindIndexOf("aaaa", "aa", 0, out index);
		Assert.IsTrue(isMatch);
		Assert.AreEqual(0, index);
	    }

	    [Test]
	    public void Should_Find_Second_Instance_Of_Subtext_aa_In_Text_aaaa_At_Index_2()
	    {
		int? index;
		bool isMatch = TextMatcher.TryFindIndexOf("aaaa", "aa", 2, out index);
		Assert.IsTrue(isMatch);
		Assert.AreEqual(2, index);
	    }

	    [Test]
	    public void Should_Find_No_Match_When_Start_Is_Less_Than_Zero()
	    {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf(Text, "Polly", -1, out index);
                Assert.IsFalse(isMatch);
                Assert.AreEqual(null, index);
	    }

	    [Test]
	    public void Should_Find_No_Match_When_Start_Is_Greater_Than_Text_Length()
	    {
                int? index;
                bool isMatch = TextMatcher.TryFindIndexOf(Text, "Polly", Text.Length, out index);
                Assert.IsFalse(isMatch);
                Assert.AreEqual(null, index);
	    }

        }

        [TestFixture]
        public class FindAllIndexesOfTests
        {
            [Test]
            public void Should_Find_Indexes_Of_Subtext_Polly_At_0_25_50()
            {
                var expected = new[] {0, 25, 50};
                IEnumerable<int> actual = TextMatcher.FindAllIndexesOf(Text, "Polly");
                CollectionAssert.AreEqual(expected, actual);
            }

            [Test]
            public void Should_Find_Indexes_Of_Subtext_ll_At_2_27_52_77_81()
            {
                var expected = new[] {2, 27, 52, 77, 81};
                IEnumerable<int> actual = TextMatcher.FindAllIndexesOf(Text, "ll");
                CollectionAssert.AreEqual(expected, actual);
            }

            [Test]
            public void Should_Find_Indexes_Of_Subtext_aa_In_Text_aaaa_At_0_2()
            {
                var expected = new[] { 0, 2 };
                IEnumerable<int> actual = TextMatcher.FindAllIndexesOf("aaaa", "aa");
                CollectionAssert.AreEqual(expected, actual);
            }

            [Test]
            public void Should_Find_Indexes_Of_Subtext_pp_In_Text_ppp_At_0()
            {
                var expected = new[] { 0 };
                IEnumerable<int> actual = TextMatcher.FindAllIndexesOf("ppp", "pp");
                CollectionAssert.AreEqual(expected, actual);
            }

            [Test]
            public void Should_Find_No_Indexes_Of_Subtext_X()
            {
                IEnumerable<int> expected = Enumerable.Empty<int>();
                IEnumerable<int> actual = TextMatcher.FindAllIndexesOf(Text, "X");
                CollectionAssert.AreEqual(expected, actual);
            }

            [Test]
            public void Should_Find_No_Indexes_Of_Subtext_Polx()
            {
                IEnumerable<int> expected = Enumerable.Empty<int>();
                IEnumerable<int> actual = TextMatcher.FindAllIndexesOf(Text, "Polx");
                CollectionAssert.AreEqual(expected, actual);
            }

            [Test]
            public void Should_Find_No_Indexes_When_Subtext_Is_Longer_Than_Text()
            {
                IEnumerable<int> expected = Enumerable.Empty<int>();
                IEnumerable<int> actual = TextMatcher.FindAllIndexesOf(Text, Text + "s");
                CollectionAssert.AreEqual(expected, actual);
            }
        }
    }
}
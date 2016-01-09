using System.Collections.Generic;
using System.Linq;
using AcklenAveJobApp.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IronManStep1()
        {
            var algorithms = new Algorithms();
            var elements = new List<string>
            {
                "dog", "cat","5zebra", "bird"
            };
            var expectedResults = new List<string>
            {
                "5zebra", "bird", "cat", "dog"
            };
            var results = algorithms.SortArray(elements, false);
            CollectionAssert.AreEqual(results.ToArray(), expectedResults);
        }

        [TestMethod]
        public void IronManStep2() //originally had read = raed, which was a mistake on the challenge specifications.
        {
            var algorithms = new Algorithms();
            var elements = new List<string>
            {
                "hEllo", "bOok", "reAd", "NeEd", "paliNdromE", "happy"
            };
            var expectedResults = new List<string>
            {
                "ohlEl", "boOk", "rAed", "NEed", "EplaNidrmo", "yhpap"
            };
            var results = algorithms.ScrambleArrayText(elements);
            CollectionAssert.AreEqual(results.ToArray(), expectedResults);
        }

        [TestMethod]
        public void IronManStep3()
        {
            var algorithms = new Algorithms();
            var elements = new List<string>
            {
                "dog", "cat","bird"
            };
            var expectedResult = "dog98cat100bird99";
            var result = algorithms.ConcatenateArrayText(elements, ConcatenationType.ASCII);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void IronManStep4()
        {
            var algorithms = new Algorithms();
            var element = "dog98cat100bird99";
            var expectedResult = "ZG9nOThjYXQxMDBiaXJkOTk=";
            var result = algorithms.Base64Encode(element);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void TheIncredibleHulkStep2()
        {
            var algorithms = new Algorithms();
            var elements = new List<string>
            {
                "dog", "cat", "bird"
            };
            var expectedResults = new List<string>
            {
                "dog", "cat", "bird"
            };
            var results = algorithms.SortArray(elements, true);
            CollectionAssert.AreEqual(results.ToArray(), expectedResults);
        }

        public void TheIncredibleHulkStep3()
        {
            var algorithms = new Algorithms();
            var elements = new List<string>
            {
                "dog", "cat","bird"
            };
            var expectedResult = "dog*cat*bird";
            var result = algorithms.ConcatenateArrayText(elements, ConcatenationType.Asterisks);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void ThorStep1()
        {
            var algorithms = new Algorithms();
            var elements = new List<string>
            {
                "aresmoking", "youacklen", "catsdrool", "likings"
            };
            var expectedResults = new List<string>
            {
                "are", "smoking", "you", "acklen", "cats", "drool", "likings"
            };
            var results = algorithms.SplitWords(elements);
            CollectionAssert.AreEqual(results.ToArray(), expectedResults);
        }

        [TestMethod]
        public void ThorStep3()
        {
            var algorithms = new Algorithms();
            var elements = new List<string>
            {
                "DoG", "CaT", "BiRd"
            };
            var expectedResults = new List<string>
            {
                "Dog", "Cat", "BirD"
            };
            var results = algorithms.AlternateConsonants(elements);
            CollectionAssert.AreEqual(results.ToArray(), expectedResults);
        }

        [TestMethod]
        public void ThorStep4()
        {
            var algorithms = new Algorithms();
            var elements = new List<string>
            {
                "dog", "cat", "bird", "chihuahua"
            };
            var expectedResults = new List<string>
            {
                "d5g", "c8t", "b13rd", "ch21h3455h89144"
            };
            var results = algorithms.FibonacciMagic(elements, 5);
            CollectionAssert.AreEqual(results.ToArray(), expectedResults);
        }
    }
}

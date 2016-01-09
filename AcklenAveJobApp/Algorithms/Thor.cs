using AcklenAveJobApp.Interfaces;
using AcklenAveJobApp.Models;

namespace AcklenAveJobApp.Algorithms
{
    public class Thor : IEncoder
    {
        private readonly Algorithms _algorithms;

        public Thor(Algorithms algorithms)
        {
            _algorithms = algorithms;
        }

        public string Encode(ResponseModel model)
        {
            var array = _algorithms.SplitWords(model.Words);
            array = _algorithms.SortArray(array, false);
            array = _algorithms.AlternateConsonants(array);
            array = _algorithms.FibonacciMagic(array, model.StartingFibonacciNumber);
            var plaintext = _algorithms.ConcatenateArrayText(array, ConcatenationType.Asterisks);
            return _algorithms.Base64Encode(plaintext);
        }
    }
}
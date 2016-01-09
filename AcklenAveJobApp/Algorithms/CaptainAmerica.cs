using AcklenAveJobApp.Interfaces;
using AcklenAveJobApp.Models;

namespace AcklenAveJobApp.Algorithms
{
    public class CaptainAmerica : IEncoder
    {
        private readonly Algorithms _algorithms;

        public CaptainAmerica(Algorithms algorithms)
        {
            _algorithms = algorithms;
        }

        public string Encode(ResponseModel model)
        {
            var array = _algorithms.ScrambleArrayText(model.Words);
            array = _algorithms.SortArray(array, true);
            array = _algorithms.FibonacciMagic(array, model.StartingFibonacciNumber);
            var plaintext = _algorithms.ConcatenateArrayText(array, ConcatenationType.ASCII);
            return _algorithms.Base64Encode(plaintext);
        }
    }
}
using AcklenAveJobApp.Interfaces;
using AcklenAveJobApp.Models;
namespace AcklenAveJobApp.Algorithms
{
    public class TheIncredibleHulk : IEncoder
    {
        private readonly Algorithms _algorithms;

        public TheIncredibleHulk(Algorithms algorithms)
        {
            _algorithms = algorithms;
        }

        public string Encode(ResponseModel model)
        {
            var array = _algorithms.ScrambleArrayText(model.Words);
            array = _algorithms.SortArray(array, true);
            var plaintext = _algorithms.ConcatenateArrayText(array, ConcatenationType.Asterisks);
            return _algorithms.Base64Encode(plaintext);
        }
    }
}
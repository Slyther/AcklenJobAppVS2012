using AcklenAveJobApp.Interfaces;
using AcklenAveJobApp.Models;
namespace AcklenAveJobApp.Algorithms
{
    public class IronMan : IEncoder
    {
        private readonly Algorithms _algorithms;

        public IronMan(Algorithms algorithms)
        {
            _algorithms = algorithms;
        }

        public string Encode(ResponseModel model)
        {
            var array = _algorithms.SortArray(model.Words, false);
            array = _algorithms.ScrambleArrayText(array);
            var plaintext = _algorithms.ConcatenateArrayText(array, ConcatenationType.ASCII);
            return _algorithms.Base64Encode(plaintext);
        }
    }
}
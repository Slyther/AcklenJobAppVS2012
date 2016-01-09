using System.Collections.Generic;
using AcklenAveJobApp.Algorithms;

namespace AcklenAveJobApp.Models
{
    public class ResponseModel
    {
        public IEnumerable<string> Words { get; set; }
        public double StartingFibonacciNumber { get; set; }
        public AlgorithmType Algorithm { get; set; }
    }

    public class EncodedResponseModel
    {
        public string Encoded { get; set; }
    }

    public class PostResponseModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
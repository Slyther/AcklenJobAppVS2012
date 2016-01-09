using System.Collections.Generic;
using AcklenAveJobApp.Interfaces;
using AcklenAveJobApp.Models;

namespace AcklenAveJobApp.Algorithms
{
    public enum AlgorithmType
    {
        IronMan,
        CaptainAmerica,
        TheIncredibleHulk,
        Thor
    }

    public class AlgorithmsHandler
    {
        public Dictionary<AlgorithmType, IEncoder> EncodersDictionary = new Dictionary<AlgorithmType, IEncoder>
        {
            {AlgorithmType.IronMan, new IronMan(new Algorithms()) },
            {AlgorithmType.CaptainAmerica, new CaptainAmerica(new Algorithms()) },
            {AlgorithmType.TheIncredibleHulk, new TheIncredibleHulk(new Algorithms()) },
            {AlgorithmType.Thor, new Thor(new Algorithms()) }
        };

        public string Encode(ResponseModel model)
        {
            var encoder = EncodersDictionary[model.Algorithm];
            return encoder.Encode(model);
        }
    }
}
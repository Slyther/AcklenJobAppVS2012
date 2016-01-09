using System;

namespace AcklenAveJobApp.Models
{

    public class SecretPayloadRegisterModel
    {
        public string Secret { get; set; }
    }

    public class SecretPayloadDisplayModel
    {
        public DateTime ReceivedDateTime { get; set; }
        public string Secret { get; set; }
    }
}
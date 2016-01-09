using System;
using System.ComponentModel;

namespace AcklenAveJobApp.Entities
{
    public class SecretPayload
    {
        public SecretPayload()
        {
            ReceivedDateTime = DateTime.UtcNow;
        }
        public long Id { get; set; }

        [DisplayName("Time and Date of Retrieval")]
        public DateTime ReceivedDateTime { get; set; }
        public string Secret { get; set; }
    }
}
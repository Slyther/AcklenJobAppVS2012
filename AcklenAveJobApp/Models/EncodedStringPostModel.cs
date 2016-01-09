using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcklenAveJobApp.Models
{
    public class EncodedStringPostModel
    {
        public EncodedStringPostModel(string encodedValue)
        {
            EncodedValue = encodedValue;
            EmailAddress = "joseph.a.griff@gmail.com";
            WebhookUrl = "http://arcommsbeacon.apphb.com/api/values/";
            RepoUrl = "https://github.com/Slyther/AcklenJobApp";
        }

        public string EncodedValue { get; set; }
        public string EmailAddress { get; set; }
        public string WebhookUrl { get; set; }
        public string RepoUrl { get; set; }
    }
}
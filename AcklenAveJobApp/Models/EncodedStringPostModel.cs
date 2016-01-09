namespace AcklenAveJobApp.Models
{
    public class EncodedStringPostModel
    {
        public EncodedStringPostModel(string encodedValue)
        {
            EncodedValue = encodedValue;
            EmailAddress = "joseph.a.griff@gmail.com";
            WebhookUrl = "http://arcommsbeaconvs2012.apphb.com/api/values";
            RepoUrl = "https://github.com/Slyther/AcklenJobAppVS2012";
            Name = "Jose Guillermo Avila Griffin";
        }

        public string EncodedValue { get; set; }
        public string EmailAddress { get; set; }
        public string WebhookUrl { get; set; }
        public string RepoUrl { get; set; }
        public string Name { get; set; }
    }
}
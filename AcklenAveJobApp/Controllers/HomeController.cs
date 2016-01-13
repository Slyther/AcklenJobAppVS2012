using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using AcklenAveJobApp.Algorithms;
using AcklenAveJobApp.Interfaces;
using AcklenAveJobApp.Models;

namespace AcklenAveJobApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISecretPayloadRepository _secretPayloadRepository;

        public HomeController(ISecretPayloadRepository secretPayloadRepository)
        {
            _secretPayloadRepository = secretPayloadRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "AR Communications Beacon";
            return View();
        }

        public ActionResult Messages()
        {
            var payloads = _secretPayloadRepository.GetAllPayloads();
            return View(payloads);
        }

        public ActionResult RequestSecret()
        {
            for (int i = 0; i < 20; i++)
            {
                string encodedResponse;
                ResponseModel obtainedResponseModel;
                string guid = Guid.NewGuid().ToString();
                using (var client = new WebClient())
                {
                    client.Headers.Add(HttpRequestHeader.Accept, "application/json");
                    var guidConcat = "values/" + guid;
                    var json = client.DownloadString("http://internal-devchallenge-2-dev.apphb.com/" + guidConcat);
                    obtainedResponseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseModel>(json);
                    AlgorithmsHandler handler = new AlgorithmsHandler();
                    encodedResponse = handler.Encode(obtainedResponseModel);
                }
                var guidConcat2 = "values/" + guid + "/" + obtainedResponseModel.Algorithm.ToString("G");
                var http = (HttpWebRequest)WebRequest.Create(new Uri("http://internal-devchallenge-2-dev.apphb.com/" + guidConcat2));
                http.Accept = "application/json";
                http.ContentType = "application/json";
                http.Method = "POST";
                var postModel = new EncodedStringPostModel(encodedResponse);
                var stringifiedPostModel = Newtonsoft.Json.JsonConvert.SerializeObject(postModel);
                byte[] bytes = Encoding.ASCII.GetBytes(stringifiedPostModel);
                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
            }
            return RedirectToAction("Messages");
        }

        public ActionResult RequestSecretForDebugging()
        {
            for (int i = 0; i < 1000; i++)
            {
                string encodedResponse;
                ResponseModel obtainedResponseModel;
                string guid = Guid.NewGuid().ToString();
                using (var client = new WebClient())
                {
                    client.Headers.Add(HttpRequestHeader.Accept, "application/json");
                    var guidConcat = "values/" + guid;
                    var json = client.DownloadString("http://internal-devchallenge-2-dev.apphb.com/" + guidConcat);
                    obtainedResponseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseModel>(json);
                    AlgorithmsHandler handler = new AlgorithmsHandler();
                    encodedResponse = handler.Encode(obtainedResponseModel);
                }

                using (var client = new WebClient())
                {
                    client.Headers.Add(HttpRequestHeader.Accept, "application/json");
                    var guidConcat = "encoded/" + guid + "/" + obtainedResponseModel.Algorithm.ToString("G");
                    var json = client.DownloadString("http://internal-devchallenge-2-dev.apphb.com/" + guidConcat);
                    EncodedResponseModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<EncodedResponseModel>(json);
                    if (model.Encoded != encodedResponse)
                    {
                        throw new Exception();
                    }
                }
            }
            return RedirectToAction("Messages");
        }
    }
}
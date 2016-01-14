using AcklenAveJobApp.Entities;
using AcklenAveJobApp.Interfaces;
using System.Web.Http;
using AcklenAveJobApp.Models;
using AutoMapper;

namespace AcklenAveJobApp.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ISecretPayloadRepository _secretPayloadRepository;

        public ValuesController(ISecretPayloadRepository secretPayloadRepository)
        {
            _secretPayloadRepository = secretPayloadRepository;
        }

        [HttpPost]
        // POST api/values
        public void Post([FromBody]SecretPayloadRegisterModel Payload)
        {
            var payload = Mapper.Map<SecretPayload>(Payload);
            _secretPayloadRepository.Create(payload);
        }
    }
}

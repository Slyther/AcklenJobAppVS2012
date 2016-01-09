using AcklenAveJobApp.Entities;
using AcklenAveJobApp.Models;
using AutoMapper;

namespace AcklenAveJobApp.App_Start
{
    public class AutoMapperConfig
    {
        public static void ConfigureMappings()
        {
            Mapper.CreateMap<SecretPayloadRegisterModel, SecretPayload>();
            Mapper.CreateMap<SecretPayload, SecretPayloadDisplayModel>();
        }
    }
}
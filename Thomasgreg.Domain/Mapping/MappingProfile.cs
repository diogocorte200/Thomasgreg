using AutoMapper;
using Thomasgreg.Domain.Domain;
using Thomasgreg.Infra.Entity;

namespace Thomasgreg.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Logradouro, LogradouroModel>().ReverseMap();
            CreateMap<ClienteModel, Cliente>().ReverseMap();

        }
    }
}

using System;
using AutoMapper;
using Samples.Server.Api.Controllers;
using Samples.Server.Domain.Entities;

namespace Samples.Server.Api.Mappers
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateCourtMaps();
        }

        private void CreateCourtMaps() => CreateDomainObjectMap<CourtDto, Court>();

        //TODO: put this piece of functionality into 
        //an external package, e.g. Model.Mapping.AutoMapper
        private void CreateDomainObjectMap<TDto, TModel>() => CreateDomainObjectMap(typeof(TDto), typeof(TModel));

        private void CreateDomainObjectMap(Type dtoType, Type modelType)
        {
            CreateMap(dtoType, modelType);
            CreateMap(modelType, dtoType);
        }
    }
}
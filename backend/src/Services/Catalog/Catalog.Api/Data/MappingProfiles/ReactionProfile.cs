using AutoMapper;
using WhiteBear.Services.Catalog.Api.Data.DTO.Reaction;
using WhiteBear.Services.Catalog.Api.Data.Entities;

namespace WhiteBear.Services.Catalog.Api.Data.MappingProfiles
{
    public class ReactionProfile : Profile
    {
        public ReactionProfile()
        {
            CreateMap<ReactionDTO, Reaction>();
            CreateMap<Reaction, ReactionDTO>();
            CreateMap<NewReactionDTO, Reaction>();  
        }
    }
}

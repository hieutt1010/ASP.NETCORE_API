using ASPNETCORE_API.Models.DTO;
using ASPNETCORE_API.Repositories;
using AutoMapper;

namespace ASPNETCORE_API.Profiles
{
    public class WalkProfile : Profile
    {

        public WalkProfile()
        {
            CreateMap<Models.Domain.Walk, Models.DTO.Walk>().ReverseMap();
            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficuty>().ReverseMap();
        }
    }
}
using AnonTalkAPI.DTO;
using AnonTalkAPI.Models;
using AutoMapper;

namespace AnonTalkAPI.Profiles
{
    public class PostParametersProfile : Profile
    {
        public PostParametersProfile()
        {
            CreateMap<PostReceiveDTO, PostParameters>();
            CreateMap<PostParameters, Post>();
        }
    }
}

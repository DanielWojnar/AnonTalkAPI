using AnonTalkAPI.DTO;
using AnonTalkAPI.Models;
using AutoMapper;

namespace AnonTalkAPI.Profiles
{
    public class CommentParametersProfile : Profile
    {
        public CommentParametersProfile()
        {
            CreateMap<CommentReceiveDTO, CommentParameters>();
            CreateMap<CommentParameters, Comment>();
        }
    }
}

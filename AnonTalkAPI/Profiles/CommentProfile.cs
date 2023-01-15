using AnonTalkAPI.DTO;
using AnonTalkAPI.Models;
using AutoMapper;

namespace AnonTalkAPI.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentReturnDTO>()
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(x => x.Image ? Constants.Comment.CommentImagePath + x.Id.ToString() + Constants.Comment.CommentImageExt : null));
        }
    }
}

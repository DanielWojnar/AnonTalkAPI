using AnonTalkAPI.DTO;
using AnonTalkAPI.Models;
using AutoMapper;

namespace AnonTalkAPI.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostMinimalReturnDTO>()
                .ForMember(dest => dest.HideComments, opt => opt.MapFrom(x => x.Comments.Count > Constants.Post.HideCommentsLimit))
                .ForMember(dest => dest.HiddenComments, opt => opt.MapFrom(x => x.Comments.Count - Constants.Post.HideCommentsLimit))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(x => x.Comments.Take(Constants.Post.HideCommentsLimit)))
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(x => x.Image ? Constants.Post.PostImagePath + x.Id.ToString() + Constants.Post.PostImageExt : null));
            CreateMap<Post, PostFullReturnDTO>()
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(x => x.Image ? Constants.Post.PostImagePath + x.Id.ToString() + Constants.Post.PostImageExt : null));
        }
    }
}

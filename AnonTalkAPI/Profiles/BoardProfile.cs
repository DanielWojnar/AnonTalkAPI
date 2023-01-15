using AnonTalkAPI.DTO;
using AnonTalkAPI.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AnonTalkAPI.Profiles
{
    public class BoardProfile : Profile
    {
        public BoardProfile()
        {
            CreateMap<Board, BoardReturnDTO>();
        }
    }
}

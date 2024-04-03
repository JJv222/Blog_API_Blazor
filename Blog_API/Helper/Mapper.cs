using AutoMapper;
using ModelsLibrary;
using ModelsLibrary.Dto;

namespace Blog_API.Helper
{
    public class Mapper : Profile
    {
        public Mapper() {
            CreateMap<User, UserDto>();
            CreateMap<Post,PostDto>();
            CreateMap<Comment, CommentDto>();
        }
    }
}

using AutoMapper;
using ModelsLibrary;
using ModelsLibrary.Dto;

namespace Blog_API.Helper
{
    public class Mapper : Profile
    {
        public Mapper() {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Post,PostDto>();
            CreateMap<PostDto, Post>();
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
        }
    }
}

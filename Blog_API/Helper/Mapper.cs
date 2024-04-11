using AutoMapper;
using ModelsLibrary;
using ModelsLibrary.CommentDto;
using ModelsLibrary.PostDto;
using ModelsLibrary.UserDto;

namespace Blog_API.Helper
{
    public class Mapper : Profile
    {
        public Mapper() {
            CreateMap<Post, PostDtoBlogResponse>();
            CreateMap<Post, PostDtoPostResponse>();

            CreateMap<Comment, CommentDtoPostResponse>();
            CreateMap<CommentDtoCreate, Comment>();

            CreateMap<User, UserDto>();
            CreateMap<User, UserDtoAuth>();
            CreateMap<UserDtoAuth, User>();
        }
    }
}

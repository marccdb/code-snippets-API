using AutoMapper;
using SnippetsAPI.DTOs;
using SnippetsAPI.Models;

namespace SnippetsAPI.Profiles
{
    public class SnippetsProfile : Profile
    {

        public SnippetsProfile()
        {
            //Source -> Destination
            CreateMap<Snippet, SnippetReadDto>();
            CreateMap<SnippetCreateDto, Snippet>();
            CreateMap<SnippetUpdateDto, Snippet>();

        }

    }
}

using AutoMapper;
using SnippetsAPI.DTOs;
using SnippetsAPI.Models;

namespace SnippetsAPI.Profiles
{
    public class SnippetsProfile : Profile
    {

        public SnippetsProfile()
        {
            CreateMap<Snippet, SnippetReadDto>();
        }

    }
}

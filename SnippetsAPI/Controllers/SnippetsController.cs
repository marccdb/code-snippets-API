using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SnippetsAPI.Data;
using SnippetsAPI.DTOs;
using SnippetsAPI.Models;

namespace SnippetsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnippetsController : ControllerBase
    {
        private readonly ISnippetRepo _repository;
        private readonly IMapper _mapper;

        public SnippetsController(ISnippetRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //Get api/snippets
        [HttpGet]
        public ActionResult<IEnumerable<Snippet>> GetAllSnippets()
        {
            var returnedValue = _repository.GetSnippets();
            return Ok(returnedValue);
        }

        //Get api/snippets/{id}
        [HttpGet("{id}", Name = "GetSnippetById")]
        public ActionResult<SnippetReadDto> GetSnippetById(int id)
        {
            var returnedValue = _repository.GetSnippetById(id);
            if (returnedValue != null)
            {
                return Ok(_mapper.Map<SnippetReadDto>(returnedValue));
            }
            return NotFound();
        }

        //Post api/snippets
        [HttpPost]
        public ActionResult<SnippetReadDto> CreateSnippet(SnippetCreateDto snippetsCreateDto)
        {
            var snippetModel = _mapper.Map<Snippet>(snippetsCreateDto);
            _repository.CreateSnippet(snippetModel);
            _repository.SaveChanges();

            var snippetsReadDto = _mapper.Map<SnippetReadDto>(snippetModel);

            return CreatedAtRoute(nameof(GetSnippetById), new { Id = snippetsReadDto.Id }, snippetsReadDto);

        }

        // Update-PUT api/snippets/{id}
        [HttpPut("{id}")]
        public ActionResult<SnippetUpdateDto> UpdateSnippet(int id, SnippetUpdateDto snippetUpdateDto)
        {
            var returnedIdFromRepo = _repository.GetSnippetById(id);
            if(returnedIdFromRepo != null)
            {
                _mapper.Map(snippetUpdateDto, returnedIdFromRepo);
                _repository.UpdateSnippet(returnedIdFromRepo);
                _repository.SaveChanges();

                return NoContent();
                
            }
            else
            {
                return NotFound();
            }

        }


    }
}

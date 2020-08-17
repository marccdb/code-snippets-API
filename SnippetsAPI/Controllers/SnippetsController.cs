using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        //GET api/snippets
        [HttpGet]
        public ActionResult<IEnumerable<Snippet>> GetAllSnippets()
        {
            var returnedValue = _repository.GetSnippets();
            return Ok(returnedValue);
        }

        //GET api/snippets/{id}
        [HttpGet("{id}", Name = "GetSnippetById")]
        public ActionResult<SnippetReadDto> GetSnippetById(int id)
        {
            var checkForValue = _repository.GetSnippetById(id);
            if (checkForValue != null)
            {
                return Ok(_mapper.Map<SnippetReadDto>(checkForValue));
            }
            return NotFound();
        }

        //POST api/snippets
        [HttpPost]
        public ActionResult<SnippetReadDto> CreateSnippet(SnippetCreateDto snippetsCreateDto)
        {
            var snippetModel = _mapper.Map<Snippet>(snippetsCreateDto);
            _repository.CreateSnippet(snippetModel);
            _repository.SaveChanges();

            var snippetsReadDto = _mapper.Map<SnippetReadDto>(snippetModel);

            return CreatedAtRoute(nameof(GetSnippetById), new { Id = snippetsReadDto.Id }, snippetsReadDto);

        }

        // PUT api/snippets/{id}
        [HttpPut("{id}")]
        public ActionResult<SnippetUpdateDto> UpdateSnippet(int id, SnippetUpdateDto snippetUpdateDto)
        {
            var returnedIdFromRepo = _repository.GetSnippetById(id);
            if (returnedIdFromRepo != null)
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

        //PATCH api/snippets/{id}
        [HttpPatch("{id}")]
        public ActionResult PatchSnippetUpdate(int id, JsonPatchDocument<SnippetUpdateDto> patchDocument)
        {
            var returnedIdFromRepo = _repository.GetSnippetById(id);
            if (returnedIdFromRepo != null)
            {
                var snippetToPatch = _mapper.Map<SnippetUpdateDto>(returnedIdFromRepo);
                patchDocument.ApplyTo(snippetToPatch, ModelState);
                if (!TryValidateModel(snippetToPatch))
                {
                    return ValidationProblem(ModelState);
                }

                _mapper.Map(snippetToPatch, returnedIdFromRepo);
                _repository.UpdateSnippet(returnedIdFromRepo);
                _repository.SaveChanges();
                return NoContent();


            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteSnippet(int id)
        {
            var returnedValue = _repository.GetSnippetById(id);
            if (returnedValue != null)
            {
                _repository.DeleteSnippet(returnedValue);
                _repository.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }


    }
}

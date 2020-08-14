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
        [HttpGet("{id}")]
        public ActionResult<SnippetReadDto> GetSnippetById(int id)
        {
            var returnedValue = _repository.GetSnippetById(id);
            if (returnedValue != null)
            {
                return Ok(_mapper.Map<SnippetReadDto>(returnedValue));
            }
            return NotFound();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnippetsAPI.Data;
using SnippetsAPI.Models;

namespace SnippetsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnippetsController : ControllerBase
    {
        private readonly ISnippetRepo _repository;

        public SnippetsController(ISnippetRepo repository)
        {
            _repository = repository;
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
        public ActionResult<Snippet> GetSnippetById(int id)
        {
            var returnedValue = _repository.GetSnippetById(id);
            return Ok(returnedValue);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnippetsAPI.Models;

namespace SnippetsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnippetsController : ControllerBase
    {
        private readonly Snippet _snippet;


        //Get api/snippets
        [HttpGet]
        public ActionResult<IEnumerable<Snippet>> GetAllSnippets()
        {
            throw new Exception("Error");

        }

        //Get api/snippets/{id}
        [HttpGet("{id}")]
        public ActionResult<Snippet> GetSnippetById(int id)
        {
            throw new Exception("Error");

        }


    }
}

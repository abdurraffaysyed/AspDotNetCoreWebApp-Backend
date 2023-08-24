using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetCoreWebApp.Models;
using Newtonsoft.Json;
using DotNetCoreWebApp.Repositories;

namespace DotNetCoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorRepository repo;

        public AuthorsController(AuthorRepository repository)
        {
            repo = repository;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> Getauthor()
        {

            return await repo.Getauthor();
            //var serializedAuthors = JsonConvert.SerializeObject(authors, Formatting.Indented,
            //new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //});
            //return Content(serializedAuthors, "application/json");
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor([FromRoute] string id)
        {
           
            return Ok(await repo.GetAuthor(id));
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor([FromRoute] string id, [FromBody] Author author)
        {
            await repo.PutAuthor(id, author);
            return NoContent();
        }

        // POST: api/Authors
        [HttpPost]
        public async Task<IActionResult> PostAuthor([FromBody] Author author)
        {
            await repo.PostAuthor(author);
            return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] string id)
        {
            return Ok(await repo.DeleteAuthor(id));
        }

        
    }
}
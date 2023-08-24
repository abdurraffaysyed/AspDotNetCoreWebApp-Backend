using DotNetCoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebApp.Repositories
{

    public class AuthorRepository:IAuthorRepository
    {


        private readonly AppDbContext appDbContext;
        public AuthorRepository(AppDbContext context)
        {
            appDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Author>>> Getauthor()
        {

            var authors = await appDbContext.author.Include(author => author.playlists).ToListAsync();
            return authors;
            //var serializedAuthors = JsonConvert.SerializeObject(authors, Formatting.Indented,
            //new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //});
            //return Content(serializedAuthors, "application/json");
        }
        public async Task<ActionResult<Author>> GetAuthor(string id)
        {
            
            var author = await appDbContext.author.FindAsync(id);
            return author;
        }
        public async Task PutAuthor(string id, Author author)
        {
            

            appDbContext.Entry(author).State = EntityState.Modified;

            try
            {
                await appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new NotImplementedException();
            }

        }
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            

            appDbContext.author.Add(author);
            await appDbContext.SaveChangesAsync();

            return author;
        }
        public async Task<ActionResult<Author>> DeleteAuthor(string id)
        {
            

            var author = await appDbContext.author.FindAsync(id);
            

            appDbContext.author.Remove(author);
            await appDbContext.SaveChangesAsync();

            return author;
        }
    }
    
}

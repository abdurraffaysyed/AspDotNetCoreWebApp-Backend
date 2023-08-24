using DotNetCoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApp.Repositories
{
    public interface IAuthorRepository
    {
        Task<ActionResult<IEnumerable<Author>>> Getauthor();
        Task<ActionResult<Author>> GetAuthor(string id);
        Task PutAuthor(string id, Author author);
        Task<ActionResult<Author>> PostAuthor(Author author);
        Task<ActionResult<Author>> DeleteAuthor(string id);

    }
}

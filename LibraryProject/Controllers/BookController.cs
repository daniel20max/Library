using LibraryProject.Data;
using LibraryProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Controllers
{
    [ApiController]
    [Route("v1/Books")]
    public class BookController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Book>>> Get([FromServices] DataContext context)
        {
            var books = await context.Books.ToListAsync();
            return books;
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Book>> GetById([FromServices] DataContext context, int id)
        {
            var book = await context.Books.Include(x => x.Author)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return book;
        }
        [HttpGet]
        [Route("author/{id:int}")]
        public async Task<ActionResult<List<Book>>> GetByAuthor([FromServices] DataContext context, int id)
        {
            var books = await context.Books
                .Include(x => x.Author)
                .AsNoTracking()
                .Where(x => x.AuthorId == id)
                .ToListAsync();
            return books;
        }
        [HttpGet]
        [Route("book/{name}")]
        [HttpPost]
        public async Task<ActionResult<List<Book>>> GetByName([FromServices] DataContext context, string name)
        {
            var book = await context.Books.Where(x => name == null ?
            true :
            x.Name.ToUpper()
            .Contains(name.ToUpper()))
            .AsNoTracking()
            .ToListAsync();
            return book;
        }
        [Route("")]
        public async Task<ActionResult<Book>> Post(
            [FromServices] DataContext context,
            [FromBody] Book model)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}

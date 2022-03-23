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
    [Route("v1/Authors")]
    public class AuthorController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Author>>> Get([FromServices] DataContext context)
        {
            var authors = await context.Authors.ToListAsync();
            return authors;
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Author>> GetById([FromServices] DataContext context, int id)
        {
            var author = await context.Authors.FirstOrDefaultAsync(x => x.Id == id);
            if (author == null)
            {
                return BadRequest("Nenhum Autor encontrado com essa ID");
            }
            else
            {
                return author;
            }

        }
        [HttpGet]
        [Route("author/{name}")]
        public async Task<ActionResult<List<Author>>> GetByName([FromServices] DataContext context, string name)
        {
            var test = await context.Authors.Where(x => name == null ?
                true :
                x.Name.ToUpper()
                .Contains(name.ToUpper()))
                .AsNoTracking()
                .ToListAsync();

            //var authors = await context.Authors.Where(x => x.Name == name)
            //    .AsNoTracking()
            //    .ToListAsync();
            return test;
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Author>> Post(
            [FromServices] DataContext context,
            [FromBody] Author model)
        {
            if (ModelState.IsValid)
            {
                context.Authors.Add(model);
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

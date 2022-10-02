using System;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;
        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await _context.Todos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo is null)
                return BadRequest("Todo Not Found");
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return Ok(await _context.Todos.ToListAsync());
        }

        [HttpPut]
        public async Task<IActionResult> Update(Todo request)
        {
            var todo = await _context.Todos.FindAsync(request.Id);
            if (todo is null)
                return BadRequest("Todo Not Found");

            todo.Title = request.Title;
            todo.Description = request.Description;

            await _context.SaveChangesAsync();

            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo is null)
                return BadRequest("Todo Not Found");
            
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return Ok(todo);
        }
    }
}

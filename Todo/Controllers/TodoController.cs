using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context) {
            _context = context;
        }//GET: api/todo
        [HttpGet]
        public String[] Get() {
            return new string[] { "value1", "value2" };
        }

        // GET api/todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(long id) {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null) { return NotFound(); }
            return todoItem;
        }

        // POST api/todo
        [HttpPost]
        public async Task<ActionResult<TodoItem>>Post([FromBody]TodoItem todoItem) {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = todoItem.Id }, todoItem);
        }

        // PUT api/todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]TodoItem todoItem) {
            if(id != todoItem.Id) { return BadRequest(); }
            _context.Entry(todoItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id) {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if(todoItem == null) { return NotFound(); }
            _context.Remove(todoItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

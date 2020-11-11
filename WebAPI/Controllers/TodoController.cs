using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    
    public class TodoController : Controller
    {
        public TodoController(ITodoRepo todoItems)
        {
            TodoItems = todoItems;
        }
        public ITodoRepo TodoItems { get; set; }
        // GET: api/<TodoController>
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return TodoItems.GetAll();
        }

        // GET api/<TodoController>/<Guid>
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(Guid id)
        {
            var item = TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/<TodoController>
        [HttpPost]
        public IActionResult Post([FromBody] TodoItem value)
        {
            if (value==null)
            {
                return BadRequest();
            }
            TodoItems.Add(value);
            return CreatedAtRoute("GetTodo", new { id = value.Key }, value);
        }

        // PUT api/<TodoController>/<Guid>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] TodoItem value)
        {
            if (value == null || value.Key != id)
            {
                return BadRequest();
            }
            TodoItem todo = TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            TodoItems.Update(value);
            return new NoContentResult();
        }

        //(part put) PATCH ap/<TodoController>
        [HttpPatch("{id}")]
        public IActionResult Patch([FromBody] TodoItem value, Guid id)
        {
            if(value == null)
            {
                return BadRequest();
            }

            TodoItem todo = TodoItems.Find(id);

            if(todo == null)
            {
                return NotFound();
            }

            value.Key = todo.Key;
            TodoItems.Update(value);

            return new NoContentResult();
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var todo = TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            TodoItems.Remove(id);
            return new NoContentResult();
        }
    }
}

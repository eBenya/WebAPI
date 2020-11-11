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

        // GET api/<TodoController>/5
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            Guid.TryParse(id, out Guid guid);
            var item = TodoItems.Find(guid);
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

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

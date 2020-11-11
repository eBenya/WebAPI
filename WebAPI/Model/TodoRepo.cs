using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class TodoRepo : ITodoRepo
    {
        private static ConcurrentDictionary<Guid, TodoItem> todos = 
            new ConcurrentDictionary<Guid, TodoItem>();
        public TodoRepo()
        {
            Add(new TodoItem { Name = "KEK" });
        }
        public void Add(TodoItem item)
        {
            item.Key = Guid.NewGuid();
            todos[item.Key] = item;
        }

        public TodoItem Find(Guid key)
        {
            todos.TryGetValue(key, out TodoItem item);
            return item;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return todos.Values;
        }

        public TodoItem Remove(Guid key)
        {
            todos.TryRemove(key, out TodoItem item);
            return item;
        }

        public void Update(TodoItem item)
        {
            todos[item.Key] = item;
        }
    }
}

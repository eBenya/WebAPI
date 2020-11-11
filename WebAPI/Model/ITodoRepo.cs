using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    interface ITodoRepo
    {
        void Add(TodoItem item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(Guid key);
        TodoItem Remove(Guid key);
        void Update(TodoItem item);
    }
}

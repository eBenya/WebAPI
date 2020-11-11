using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class TodoItem
    {
        public Guid Key { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}

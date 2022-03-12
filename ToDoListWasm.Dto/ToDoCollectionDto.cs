using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListWasm.Dto
{
    public class ToDoCollectionDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<ToDoItemDto>? Items { get; set; }
    }
}

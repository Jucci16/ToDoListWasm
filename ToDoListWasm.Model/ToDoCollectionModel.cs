using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListWasm.Model
{
    public class ToDoCollectionModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<ToDoItemModel>? Items { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListReichl1903
{
    class TodoItem
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string DisplayName { get => $"{Date.ToShortDateString()} - {Name}"; }
    }
}

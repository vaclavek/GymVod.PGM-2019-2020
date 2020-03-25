using System;

namespace TodoList.Data
{
    public class TodoItem
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public string DisplayName => $"{Date.ToShortDateString()} - {Name}";
    }
}

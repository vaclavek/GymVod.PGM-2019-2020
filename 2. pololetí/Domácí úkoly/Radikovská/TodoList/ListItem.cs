using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    class ListItem
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string TodoText { get; set; }
        public DateTime Date { get; set; }
        public string DisplayName
        {
            get { return Date.ToShortDateString() + ": " + TodoText; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    class Event
    {
        public Guid Id { get; set; } = new Guid();
        public  string Name { get; set; }
        public DateTime Date { get; set; }

        public string Displayname => $"{Date.ToShortDateString()} - {Name}";


    }
}

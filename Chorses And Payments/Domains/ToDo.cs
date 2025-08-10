using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDos.Domains
{
     public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Payment { get; set; }
        public DateTime ApplicationDate { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public Person Person { get; set; }
    }

    public enum TaskStatus 
    {
        Completed,
        NotCompleted
    }
}

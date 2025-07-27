using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDos.Domains;

namespace ToDos
{
    public class AppDbContext : DbContext
    {
        public DbSet<ToDo> Tasks { get; set; }
        public DbSet<Domains.Person> People { get; set; }

        public AppDbContext() : base("TaskManagerConnection") { }
    }
}


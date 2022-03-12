using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListWasm.Model;

namespace ToDoListWasm.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoItemModel> ToDoItems { get; set; }

        public DbSet<ToDoCollectionModel> ToDoCollections { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ToDoCollectionModel>().ToTable("ToDoCollection");
            builder.Entity<ToDoItemModel>().ToTable("ToDoItem");
        }
    }
}

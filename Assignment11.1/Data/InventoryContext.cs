using Microsoft.EntityFrameworkCore;
using Assignment11._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment11._1.Data
{
    public class InventoryContext: DbContext
    {
        public DbSet<Inventory> Inventorystable { get; set; }
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>().HasData(GetInventory());//generate basic data
            base.OnModelCreating(modelBuilder);
        }
        private Inventory[] GetInventory()
        {
            return new Inventory[]
            {
                new Inventory { ISBN = "978-3-16-148410-0", BookName = "The Great Gatsby", AuthorName = "F. Scott Fitzgerald", Summary = "A novel about the American dream." },
                new Inventory { ISBN = "978-0-14-118263-6", BookName = "1984", AuthorName = "George Orwell", Summary = "A dystopian novel about totalitarianism." },
                new Inventory { ISBN = "978-0-452-28423-4", BookName = "To Kill a Mockingbird", AuthorName = "Harper Lee", Summary = "A novel about racial injustice in the Deep South." },
                new Inventory { ISBN = "978-0-7432-7356-5", BookName = "The Da Vinci Code", AuthorName = "Dan Brown", Summary = "A mystery thriller novel." }
            };
        }   
    }
}

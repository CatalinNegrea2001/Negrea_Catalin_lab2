using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Negrea_Catalin_lab2.Models;

namespace Negrea_Catalin_lab2.Data
{
    public class Negrea_Catalin_lab2Context : DbContext
    {
        public Negrea_Catalin_lab2Context (DbContextOptions<Negrea_Catalin_lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Negrea_Catalin_lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Negrea_Catalin_lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Negrea_Catalin_lab2.Models.Authors>? Authors { get; set; }

        public DbSet<Negrea_Catalin_lab2.Models.Category>? Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Borrowing)
                .WithOne(b => b.Book)
                .HasForeignKey<Borrowing>(b => b.BookID);
        }
        public DbSet<Negrea_Catalin_lab2.Models.Member>? Member { get; set; }
        public DbSet<Negrea_Catalin_lab2.Models.Borrowing>? Borrowing { get; set; }
    }
}

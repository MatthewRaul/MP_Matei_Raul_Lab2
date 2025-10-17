using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab2.Models;
using Matei_Raul_Lab2.Models;

namespace Matei_Raul_Lab2.Data
{
    public class Matei_Raul_Lab2Context : DbContext
    {
        public Matei_Raul_Lab2Context (DbContextOptions<Matei_Raul_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Matei_Raul_Lab2.Models.Publisher> Publisher { get; set; } = default!;

        public DbSet<Author> Authors { get; set; } = default!;
    }
}

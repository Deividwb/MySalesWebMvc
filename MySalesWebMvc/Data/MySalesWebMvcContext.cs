using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySalesWebMvc.Models;

namespace MySalesWebMvc.Data
{
    public class MySalesWebMvcContext : DbContext
    {
        public MySalesWebMvcContext (DbContextOptions<MySalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<MySalesWebMvc.Models.Department> Department { get; set; } = default!;
    }
}

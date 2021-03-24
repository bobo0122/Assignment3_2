using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_2.Models
{
    public class MovieDbContext : DbContext
    {
       
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationResponse> ApplicationResponses { get; set; }
        //pull in another table
   
    }
}

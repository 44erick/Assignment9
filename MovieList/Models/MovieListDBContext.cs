using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Models
{
    public class MovieListDBContext : DbContext
    {
        public MovieListDBContext(DbContextOptions<MovieListDBContext> options) : base(options)
        {

        }

        public DbSet<modelResponse> modelResponses { get; set; }
    }
}

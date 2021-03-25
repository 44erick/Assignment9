using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Models
{
    //test
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {

            MovieListDBContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<MovieListDBContext>();

            //migrate if nothing there
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

        
            if (!context.modelResponses.Any())
            {

                context.modelResponses.AddRange(
                new modelResponse
                {
                    Category = "Action",
                    Title = "IP Man",
                    Year = 2009,
                    Director = "Smart bro",
                    Rating = "R",
                    Edited = false,
                    Lent = "no",
                    Notes = "good movie"
                }

                );

                //save changes bruh
                context.SaveChanges();
            }
        }
    }
}

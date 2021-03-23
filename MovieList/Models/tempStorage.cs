using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Models
{
    public static class tempStorage
    {
        private static List<modelResponse> moviess = new List<modelResponse>();

        public static IEnumerable<modelResponse> Moviess => moviess;

        public static void AddMovie(modelResponse application)
        {
            moviess.Add(application);
        }
    }
}
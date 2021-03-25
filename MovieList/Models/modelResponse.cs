using System;
using System.Collections.Generic;
//so we can see the validation errors
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Models
{
    public class modelResponse
    {
        [Key]
        public int MovieID { get; set; }
        //required
        [Required(ErrorMessage = "Please enter category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter year")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Please enter director")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Please enter rating")]
        public string Rating { get; set; }

        public bool? Edited { get; set; }

        public string Lent { get; set; }
        [MaxLength(25, ErrorMessage = "No more than 25 characters allowed")]
        public string Notes { get; set; }

    }
}
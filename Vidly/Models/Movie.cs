using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string Genre { get; set; }
        [Display(Name="Number in Stock")]
        [Required]
        [Range(1, 10)]
        public int NoInStock { get; set; }
    }
}
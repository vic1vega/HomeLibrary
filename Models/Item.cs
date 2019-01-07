using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeLibrary.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public string Cover { get; set; }
        
        [Required]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        
        [Required]
        [Display(Name = "Rok produkcji")]
        public int Year { get; set; }
        
        [Required]
        [Display(Name = "Typ nośnika")]        
        public Types Type { get; set; }
        
        [Required]
        [Display(Name = "Autor")]         
        public string AuthorName { get; set; }
        public int RentDate { get; set; }

        [Display(Name = "Wypożyczający")]
        public string RentName { get; set; }
        public bool IsRent { get; set; }
    }
}
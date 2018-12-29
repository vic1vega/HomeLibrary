using System;
using System.Collections.Generic;

namespace HomeLibrary.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public string Cover { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public Types Type { get; set; }
        public string AuthorName { get; set; }
        public int RentDate { get; set; }
        public string RentName { get; set; }
    }
}
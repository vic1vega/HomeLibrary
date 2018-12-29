using System.Collections.Generic;
using HomeLibrary.Models;

namespace HomeLibrary.ViewModels
{
    public class HomeVM
    {
        public string Title { get; set; }
        public List<Item> Items { get; set; }
    }
}
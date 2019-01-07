using System.Collections.Generic;
using HomeLibrary.Models;

namespace HomeLibrary.ViewModels
{
    public class StatsVM
    {
        public int AllItem { get; set; }
        public int  DvdItem { get; set; }
        public int  CdItem { get; set; }
        public int  BookItem { get; set; }
        public int  AvailableItem { get; set; }
        public int  NonAvailableItem { get; set; }
        public List<Item> ListNonAvailableItem { get; set; }
    }
}
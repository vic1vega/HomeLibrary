using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeLibrary.Models
{
    public class MockItemRepository : IItemRepository
    {
        private List<Item> items;

        public MockItemRepository()
        {
            if (items == null)
            {
                LoadItems();
            }
        }

        private void LoadItems()
        {
            items = new List<Item>
            {
                new Item {AuthorName="Alejandro González Iñárritu",Cover= "https://www.filmweb.pl/video/zwiastun/nr+2+polski-37388",ItemId=1,RentDate=0,RentName=null,Title="Zjawa",Type=Types.DVD,UserId=0,Year=2015 },
                new Item {AuthorName="Queen",Cover= "https://images-na.ssl-images-amazon.com/images/I/6139YfAAyBL._SS500.jpg",ItemId=2,RentDate=0,RentName=null,Title="Jazz",Type=Types.CD,UserId=0,Year=1978 },
                new Item {AuthorName="George Orwell",Cover= "https://pl.wikipedia.org/wiki/Plik:Animal_Farm_-_1st_edition.jpg",ItemId=3,RentDate=0,RentName=null,Title="Folwark Zwierzęcy",Type=Types.Book,UserId=0,Year=1945 }
            };
        }

        public IEnumerable<Item> GetAllItems()
        {
            return items;
        }

        public Item GetItemByAuthor(string author)
        {
            return items.FirstOrDefault(i => i.AuthorName == author);
        }

        public Item GetItemByTitle(string title)
        {
            return items.FirstOrDefault(i => i.Title == title);
        }

        public IEnumerable<Item> GetItemByType(Types type)
        {
            return items.FindAll(i => i.Type == type);
        }
    }

    public enum Types
    {
        DVD,
        CD,
        Book
    }

}
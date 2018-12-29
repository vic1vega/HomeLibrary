using System.Collections.Generic;

namespace HomeLibrary.Models
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItems();
        Item GetItemByTitle(string title);
        Item GetItemByAuthor(string author);
        IEnumerable<Item> GetItemByType(Types type);
    }
}
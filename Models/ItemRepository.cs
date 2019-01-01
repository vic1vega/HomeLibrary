using System.Collections.Generic;
using System.Linq;

namespace HomeLibrary.Models
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public ItemRepository (AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Item> GetAllItems()
        {
            return _appDbContext.Items;
        }

        public Item GetItemById(int id)
        {
            return _appDbContext.Items.FirstOrDefault(i => i.ItemId == id);
        }

        public Item GetItemByAuthor(string author)
        {
            return _appDbContext.Items.FirstOrDefault(i => i.AuthorName == author);
        }

        public Item GetItemByTitle(string title)
        {
           return _appDbContext.Items.FirstOrDefault(i => i.Title ==title);
        }

        public IEnumerable<Item> GetItemByType(Types type)
        {
            return _appDbContext.Items.ToList().FindAll(i => i.Type == type);
        }

        public void CreateItem(Item item)
        {
            _appDbContext.Items.Add(item);
            _appDbContext.SaveChanges();
        }

        public void UpdateItem(Item item)
        {
            _appDbContext.Items.Update(item);
            _appDbContext.SaveChanges();
        }
    }
}
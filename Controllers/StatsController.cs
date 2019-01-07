using HomeLibrary.Models;
using HomeLibrary.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace HomeLibrary.Controllers
{
    public class StatsController : Controller
    {
        private readonly IItemRepository _itemRepository;
        public StatsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allItems = this._itemRepository.GetAllItems();
            var statsVM = new StatsVM()
            {
            AllItem = allItems.Count(),
            DvdItem = allItems.Where(i => i.Type == Types.DVD).Count(),
            CdItem = allItems.Where(i => i.Type == Types.CD).Count(),
            BookItem = allItems.Where(i => i.Type == Types.Book).Count(),
            AvailableItem = allItems.Where(i => i.IsRent == false).Count(),
            NonAvailableItem = allItems.Where(i => i.IsRent == true).Count(),
            ListNonAvailableItem = allItems.Where(i => i.IsRent == true).ToList(),
            };

            return View(statsVM);
        }
    }
}
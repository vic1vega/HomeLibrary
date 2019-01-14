using HomeLibrary.Models;
using HomeLibrary.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace HomeLibrary.Controllers
{
    public class SearchController : Controller
    {
        private readonly IItemRepository _itemRepository;
        public SearchController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchResult(string searchString, bool Title, bool Author)
        {

            var items = from i in _itemRepository.GetAllItems()
                         select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            return View(items);
        }
    }
}
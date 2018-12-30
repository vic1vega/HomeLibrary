using HomeLibrary.Models;
using HomeLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Encodings.Web;

namespace HomeLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public HomeController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public IActionResult Index()
        {
            var items = _itemRepository.GetAllItems().OrderBy(i => i.Title);
            var homeVM = new HomeVM()
            {
                Title = "Strona główna biblioteki",
                Items = items.ToList()
            };

            return View(homeVM);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var item = _itemRepository.GetItemById(id);

            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return View(item);
            }

        }
    }
}
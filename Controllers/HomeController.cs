using HomeLibrary.Models;
using Microsoft.AspNetCore.Mvc;
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
          //TODO: Implement Realistic Implementation
          return View();
        }
    }
}
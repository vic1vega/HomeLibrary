using HomeLibrary.Models;
using HomeLibrary.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace HomeLibrary.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private IHostingEnvironment _env;

        public ItemController(IItemRepository itemRepository, IHostingEnvironment env)
        {
            _itemRepository = itemRepository;
            _env = env;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var items = _itemRepository.GetAllItems();

            return View(items);
        }

        [HttpGet]
        public IActionResult Create(string FileName)
        {
            if (!string.IsNullOrEmpty(FileName))
            {
                ViewBag.ImgPath = "/images/" + FileName;
            }

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _itemRepository.CreateItem(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpGet]
        public IActionResult Update(int id, string FileName)
        {
            var item = _itemRepository.GetItemById(id);

            if (item == null)
            {
                NotFound();
            }

            if (!string.IsNullOrEmpty(FileName))
            {
                ViewBag.ImgPath = "/images/" + FileName;
            }
            else
            {
                ViewBag.ImgPath = item.Cover;
            }

            return View(item);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(Item item)
        {
            if (ModelState.IsValid)
            {
                _itemRepository.UpdateItem(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var item = _itemRepository.GetItemById(id);

            if (item != null)
            {
                return View(item);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormCollection form)
        {
            var webRoot = _env.WebRootPath;
            var filePath = Path.Combine(webRoot.ToString() + "/images/" + form.Files[0].FileName);

            if (form.Files[0].FileName.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await form.Files[0].CopyToAsync(stream);
                }
            }

            if (Convert.ToString(form["ItemId"]) == string.Empty || Convert.ToString(form["ItemId"]) == "0")
            {
                return RedirectToAction("Create", new { FileName = Convert.ToString(form.Files[0].FileName) });
            }
            else
            {
                return RedirectToAction("Update", new { FileName = Convert.ToString(form.Files[0].FileName), id = Convert.ToString(form["ItemId"]) });
            }
        }
    }
}
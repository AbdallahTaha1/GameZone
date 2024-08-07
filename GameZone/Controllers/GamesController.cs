using GameZone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Security;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoryService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGamesServices _gamesServices;

        public GamesController(ICategoryService categories, 
                                IDevicesService devices, 
                                IGamesServices gamesServices)
        {
            _categoriesService = categories;
            _devicesService = devices;
            _gamesServices = gamesServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var veiwModel = new CreateGameFormViewModel()
            {
                Categories = _categoriesService.GetSelectList(),
                Devices = _devicesService.GetSelctList()
            };
            return View(veiwModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetSelectList();
                model.Devices = _devicesService.GetSelctList();
                return View(model);
            }
            
            await _gamesServices.Create(model);

            return RedirectToAction(nameof(Index));
        }
    }
}

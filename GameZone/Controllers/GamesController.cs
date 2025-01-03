﻿using GameZone.Models;
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
            var games = _gamesServices.GetAll();
            return View(games);
        }

        public IActionResult Details(int id)
        {
            var game = _gamesServices.GetById(id);

            if(game is null)
            {
                return NotFound();
            }
            return View(game);
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

        [HttpGet]
        public IActionResult Edit(int id) {

            var game = _gamesServices.GetById(id);

            if(game is null) return NotFound();

            var gameViewModel = new EditGameFormViewModel()
            {
                Name = game.Name,
                CategoryId = game.CategoryId,
                Categories = _categoriesService.GetSelectList(),
                Devices = _devicesService.GetSelctList(),
                SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
                Description = game.Description,
                currentCover = game.Cover
            };
            return View(gameViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetSelectList();
                model.Devices = _devicesService.GetSelctList();
                return View(model);
            }

            await _gamesServices.Edit(model);

            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            var isDeleted = _gamesServices.Delete(id);
            return isDeleted? Ok(): BadRequest();
        }
    }
}

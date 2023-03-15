﻿using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home.University;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class UniversityFormController : Controller
    {
        private IAztobirService _aztobirService;
        public UniversityFormController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        [Route("/admin/university/form/index")]
        public async Task<IActionResult> Index()
        {
            UniversityViewVM uni = new UniversityViewVM()
            {
                UniversityForms = await _aztobirService.UniversityFormService.GetAll(),
            };
            return View(uni);
        }
        [Route("/admin/university/form/detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                UniversityViewVM uni = new UniversityViewVM()
                {
                    UniversityFormOdd = await _aztobirService.UniversityFormService.Get(id),
                };
                return View(uni);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        [Route("/admin/university/form/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aztobirService.UniversityFormService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }
        }
        [Route("/admin/university/form/sendMessage/{id}")]
        public IActionResult SendMessage()
        {
            return View();
        }
        [Route("/admin/university/form/sendMessage/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(int id, SendMessageVM message)
        {
            try
            {
                var model = await _aztobirService.UniversityFormService.SendMessage(id, message);
                if (model != "ok")
                {
                    return RedirectToAction("CustomBadRequest", "Error", new { area = "null" });
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }
        }
    }
}

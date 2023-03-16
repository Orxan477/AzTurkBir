using AutoMapper;
using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels;
using Aztobir.Business.ViewModels.Home.Contact;
using Aztobir.Business.ViewModels.Home.University;
using Aztobir.Core.Models;
using Aztobir.Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class ContactFormController : Controller
    {
        private IAztobirService _aztobirService;
        private AppDbContext _context;
        private IMapper _mapper;

        public ContactFormController(IAztobirService aztobirService,AppDbContext context,IMapper mapper)
        {
            _aztobirService = aztobirService;
            _context = context;
            _mapper = mapper;
        }
        [Route("/admin/contact/index")]
        public async Task<IActionResult> Index(int page=1)
        {
            int takeCount = int.Parse("8");
            //int count = int.Parse(GetSetting("TakeCount"));
            ViewBag.TakeCount = takeCount;
            var model = await _aztobirService.ContactService.GetPaginete(page, takeCount);
            return View(model);
        }
        private int GetPageCount(int take, List<ContactVM> contacts)
        {
            var prodCount = contacts.Count();
            return (int)Math.Ceiling((decimal)prodCount / take);
        }
        private List<ContactVM> GetProductList(List<Contact> contact)
        {
            List<ContactVM> model = new List<ContactVM>();
            foreach (var item in contact)
            {
                ContactVM feedback = _mapper.Map<ContactVM>(item);
                model.Add(feedback);
            }
            return model;
        }
        [Route("/admin/contact/detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                var contact = await _aztobirService.ContactService.Get(id);
                return View(contact);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        [Route("/admin/contact/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aztobirService.ContactService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }
        }
        [Route("/admin/contact/sendmessage/{id}")]
        public IActionResult SendMessage()
        {
            return View();
        }
        [Route("/admin/contact/sendmessage/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(int id, SendMessageVM message)
        {
            if (!ModelState.IsValid)
            {
                return View(message);
            }
            try
            {
                var model = await _aztobirService.ContactService.SendMessage(id, message);
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

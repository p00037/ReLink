using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReLink.Server.Dao;
using ReLink.Server.Entiy.DbEntity;
using ReLink.Server.Models;
using ReLink.Server.Models;

namespace ReLink.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel indexViewModel)
        {
            return RedirectToAction( "Chat", "Home", indexViewModel);
        }

        public IActionResult Chat(IndexViewModel indexViewModel)
        {
            DaoD_Message daoD_Message = new DaoD_Message();
            var list = daoD_Message.GetList(1);

            ChatViewModel chatViewModel = new ChatViewModel();
            chatViewModel.UserName = indexViewModel.UserName;
            chatViewModel.MessageEntitys = list;

            return View(chatViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

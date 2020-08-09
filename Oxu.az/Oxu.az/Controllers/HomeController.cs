using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Oxu.az.Abstractions;
using Oxu.az.Models;

namespace Oxu.az.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsRepository _newsRepository;

        public HomeController(ILogger<HomeController> logger, INewsRepository newsRepository)
        {
            _logger = logger;
            _newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            var listOfPosts = _newsRepository.GetAllPosts();
            return View(listOfPosts);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        //================== SEE DETAILED INFO ABOUT POST
        public IActionResult Detail(int id)
        {
            var post = _newsRepository.GetPost(id);

            return View(post);
        }


        //========================= INCREASE LIKE DISLIKE AND VISITED AMOUNT
        public IActionResult IncreasePostAffect(PostAffect postAffect)
        {
            var changedPost = _newsRepository.IncreasePostAffect(postAffect);
            
            if (changedPost != null)
            {
                var json = JsonConvert.SerializeObject(changedPost);
                return Content(json);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

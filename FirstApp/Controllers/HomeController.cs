using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstApp.Controllers
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
            var sliderList = new HomePageModel
            {
                HomePageSlider = new List<HomePageSliderModel>
                {
                    new HomePageSliderModel
                    {
                        Order = 1,
                        Title = "Deneme 1",
                        Description = "Deneme Açıklama 1",
                        Image = "/img/hero-carousel/hero-carousel-1.jpg",
                        Active = true
                    },
                    new HomePageSliderModel
                    {
                        Order = 2,
                        Title = "Deneme 2",
                        Description = "Deneme Açıklama 2",
                        Image = "/img/hero-carousel/hero-carousel-2.jpg",
                        Active = false
                    },
                    new HomePageSliderModel
                    {
                        Order = 3,
                        Title = "Deneme 3",
                        Description = "Deneme Açıklama 3",
                        Image = "/img/hero-carousel/hero-carousel-3.jpg",
                        Active = false
                    }
                }
            };

            return View(sliderList);
        }

        public IActionResult Onur()
        {
            var modelList = new List<ContactFormModel>
            {
                new ContactFormModel
                {
                    Id = 1,
                    Name = "Onur",
                    Surname = "Durgun"
                },
                new ContactFormModel
                {
                    Id = 2,
                    Name = "Aziz",
                    Surname = "Durgun"
                },
                new ContactFormModel
                {
                    Id = 3,
                    Name = "Mustafa",
                    Surname = "Durgun"
                }
            };

            return View(modelList);
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
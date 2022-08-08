using FirstApp.Context;
using FirstApp.Entity;
using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FirstApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabeseContext _dbContext;
        private readonly DbSet<Slider> _dataSet;



        public HomeController(ILogger<HomeController> logger, DatabeseContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _dataSet = dbContext.Set<Slider>();
        }

        public async Task<IActionResult> Index()
        {
            var getSlider = await _dataSet.ToListAsync<Slider>();

            var sliderList = new HomePageModel
            {
                HomePageSlider = getSlider
            };
            var modelSlider = new Slider
            {
                Order = 2,
                Title = "Deneme 2",
                Description = "Deneme Açıklama 2",
                Image = "/img/hero-carousel/hero-carousel-2.jpg",
                Active = true
            };

            //await AddSliderAsync(modelSlider);
            await DeleteSliderAsync(getSlider.Find(x => !x.Active));
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

        public async Task<bool> AddSliderAsync(Slider model)
        {
            await _dbContext.AddAsync<Slider>(model);

            var response = await _dbContext.SaveChangesAsync() > 0;
            return response;
        }

        public async Task<bool> DeleteSliderAsync(Slider model)
        {
            _dbContext.Remove<Slider>(model);

            var response = await _dbContext.SaveChangesAsync() > 0;
            return response;
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
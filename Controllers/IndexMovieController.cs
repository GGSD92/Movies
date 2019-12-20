using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Models;
using Movies.ViewModels;
using System.Diagnostics;

namespace PRUEBA.Controllers
{
    public class IndexMovieController : Controller
    {
      
        private readonly ILogger<IndexMovieController> _logger;

        public IndexMovieController(ILogger<IndexMovieController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            MoviesViewModel viewModel = new MoviesViewModel
            {
                Peliculas = Movie.SelectAll()
            };


            return View(viewModel);
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
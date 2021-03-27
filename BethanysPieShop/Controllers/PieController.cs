using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository pieRepository;
        private readonly ICategoryRepository categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            this.pieRepository = pieRepository;
            this.categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            var piesListViewModel = new PiesListViewModel();

            piesListViewModel.Pies = pieRepository.AllPies;
            piesListViewModel.CurrentCategory = "Cheese cakes";

            return View(piesListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = pieRepository.GetPieById(id);

            return pie == null ? NotFound() : View(pie);
        }
    }
}
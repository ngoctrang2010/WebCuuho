using Microsoft.AspNetCore.Mvc;
using WebRong.Repository;

namespace WebRong.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDichvuRepository _DichvuRepository;
        private readonly ILienheRepository _LienheRepository;
        private readonly IBaivietRepository _BaivietRepository;
        public AdminController(IBaivietRepository baivietRepository, IDichvuRepository dichvuRepository, ILienheRepository lienheRepository)
        {
            _BaivietRepository = baivietRepository;
            _DichvuRepository = dichvuRepository;
            _LienheRepository = lienheRepository;
        }
        public async Task<IActionResult> Index()
        {

            var baiviet = await _BaivietRepository.GetallBaiviet();
            var tintuc = await _BaivietRepository.GetallTintuc();
            var dichvu = await _DichvuRepository.GetallDichvu();

            ViewBag.Baiviet = baiviet;
            ViewBag.Tintuc = tintuc;
            ViewBag.Dichvu = dichvu;

            return View();
        }
    }
}

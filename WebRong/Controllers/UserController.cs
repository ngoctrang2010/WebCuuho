using Microsoft.AspNetCore.Mvc;
using WebRong.Repository;

namespace WebRong.Controllers
{
    public class UserController : Controller
    {
        private readonly IDichvuRepository _DichvuRepository;
        private readonly ILienheRepository _LienheRepository;
        private readonly IBaivietRepository _BaivietRepository;
        public UserController( IBaivietRepository baivietRepository, IDichvuRepository dichvuRepository, ILienheRepository lienheRepository) {
            _BaivietRepository = baivietRepository;
            _DichvuRepository = dichvuRepository;
            _LienheRepository = lienheRepository;
        }
        public async Task<IActionResult> Index() { 

            var baiviet = await  _BaivietRepository.GetallBaiviet();
            var tintuc = await _BaivietRepository.GetallTintuc();    
            var dichvu = await _DichvuRepository.GetallDichvu();

            ViewBag.Baiviet = baiviet;
            ViewBag.Tintuc = tintuc;
            ViewBag.Dichvu = dichvu;

            return View(); 
        }
        public async Task<IActionResult> about()
        {

            var baiviet = await _BaivietRepository.GetallBaiviet();
            var tintuc = await _BaivietRepository.GetallTintuc();
            var dichvu = await _DichvuRepository.GetallDichvu();

            ViewBag.Baiviet = baiviet;
            ViewBag.Tintuc = tintuc;
            ViewBag.Dichvu = dichvu;

            return View();
        }
        public async Task<IActionResult> contact()
        {

            var baiviet = await _BaivietRepository.GetallBaiviet();
            var tintuc = await _BaivietRepository.GetallTintuc();
            var dichvu = await _DichvuRepository.GetallDichvu();

            ViewBag.Baiviet = baiviet;
            ViewBag.Tintuc = tintuc;
            ViewBag.Dichvu = dichvu;

            return View();
        }
        public async Task<IActionResult> project()
        {

            var baiviet = await _BaivietRepository.GetallBaiviet();
            var tintuc = await _BaivietRepository.GetallTintuc();
            var dichvu = await _DichvuRepository.GetallDichvu();

            ViewBag.Baiviet = baiviet;
            ViewBag.Tintuc = tintuc;
            ViewBag.Dichvu = dichvu;

            return View();
        }
        public async Task<IActionResult> service()
        {

            var baiviet = await _BaivietRepository.GetallBaiviet();
            var tintuc = await _BaivietRepository.GetallTintuc();
            var dichvu = await _DichvuRepository.GetallDichvu();

            ViewBag.Baiviet = baiviet;
            ViewBag.Tintuc = tintuc;
            ViewBag.Dichvu = dichvu;

            return View();
        }
        public async Task<IActionResult> testimonial()
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

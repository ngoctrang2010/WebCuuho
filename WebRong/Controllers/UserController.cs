using Microsoft.AspNetCore.Mvc;
using PagedList;
using WebRong.Models;
using WebRong.Repository;

namespace WebRong.Controllers
{
    public class UserController : Controller
    {
        private readonly IDichvuRepository _DichvuRepository;
        private readonly ILienheRepository _LienheRepository;
        private readonly IBaivietRepository _BaivietRepository;
        public UserController(IBaivietRepository baivietRepository, IDichvuRepository dichvuRepository, ILienheRepository lienheRepository)
        {
            _BaivietRepository = baivietRepository;
            _DichvuRepository = dichvuRepository;
            _LienheRepository = lienheRepository;
        }
        public async Task<IActionResult> Index()
        {
            var baiviet = await _BaivietRepository.GetallBaiviet();
            var dichvu = await _DichvuRepository.GetallDichvu();

            ViewBag.Baiviet = baiviet;
            ViewBag.Dichvu = dichvu;

            return View();
        }
        public async Task<IActionResult> service(int? page)
        {
			var dichvu = await _DichvuRepository.GetallDichvu();
			var baiviet = await _BaivietRepository.GetallBaiviet();

			
			ViewBag.Dichvu = dichvu;
			ViewBag.Baiviet = baiviet;

			return View();
		}
        public async Task<IActionResult> about()
        {
            return View();
        }
        public async Task<IActionResult> contact()
        {
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
        
        public async Task<IActionResult> testimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SubmitContact( LienHe lienhe)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Dữ liệu không hợp lệ!";
                TempData["MessageType"] = "error";
                return RedirectToAction("contact", "User");
            }

            lienhe.Ngaytao = DateTime.Now;

            bool checkAdd = await _LienheRepository.AddLienhe(lienhe);
            if (checkAdd)
            {
                TempData["Message"] = "Thêm liên hệ thành công!";
                TempData["MessageType"] = "success";
            }
            else
            {
                TempData["Message"] = "Xảy ra lỗi!";
                TempData["MessageType"] = "error";
            }

            return RedirectToAction("contact", "User");
        }
		public async Task<IActionResult> DetailBaiviet(int id)
		{
            var allbaiviet = await _BaivietRepository.GetallBaiviet();
			var baiviet = await _BaivietRepository.GetBaivietByIdBaiviet(id);
			var noidung = baiviet.Noidung;
			var result = new List<string>();

			var temp = "";
			var index = 0;

			while (index < noidung.Length)
			{

				if (noidung.Substring(index).StartsWith("hinhanh:"))
				{
					if (!string.IsNullOrEmpty(temp))
					{
						result.Add(temp);
						temp = ""; // Reset biến tạm
					}
					// Tách chuỗi "hinhanh:" và phần sau nó (nếu có)
					var endOfHinhanh = noidung.Substring(index).IndexOf('\n') == -1 ? noidung.Length : noidung.Substring(index).IndexOf('\n');
					result.Add(noidung.Substring(index, endOfHinhanh).Trim()); // Thêm "hinhanh:" vào kết quả
					index += endOfHinhanh; // Di chuyển qua phần đã xử lý
				}
				else
				{
					// Nếu không phải "hinhanh:", thêm ký tự vào biến tạm
					temp += noidung[index];
					index++;
				}
			}

			// Thêm phần còn lại nếu có
			if (!string.IsNullOrEmpty(temp))
			{
				result.Add(temp);
			}
            ViewBag.Baiviet = baiviet;
            ViewBag.AllBaiviet = allbaiviet;
            return View(result);
		}


	}
}

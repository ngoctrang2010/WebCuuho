using Microsoft.EntityFrameworkCore;
using WebRong.Models;

namespace WebRong.Repository
{
    public interface IBaivietRepository
    {
        //baiviet
        public Task<List<BaiViet>> GetallBaiviet();
        public Task<BaiViet> GetBaivietByIdDichvu(int id);
        public Task<BaiViet> GetBaivietByIdBaiviet(int id);
        //tintuc
        public Task<List<BaiViet>> GetallTintuc();
        public Task<BaiViet> GetTintucById(int id);
        //
        public Task<bool> DeleteBaiviet(int id);
        public Task<bool> UpdateBaiviet(BaiViet baiviet);
        public Task<bool> AddBaiviet(BaiViet baiviet);
    }
}

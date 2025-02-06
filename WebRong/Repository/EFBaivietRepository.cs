using Microsoft.EntityFrameworkCore;
using WebRong.Models;

namespace WebRong.Repository
{
    public class EFBaivietRepository : IBaivietRepository
    {
        private readonly CuuhoWebContext _context;
        public EFBaivietRepository(CuuhoWebContext context)
        {
            _context = context;
        }
        //bài viết
        public async Task<List<BaiViet>> GetallBaiviet()
        {
            return await _context.BaiViets.Where(p=>p.IsTintuc == false).ToListAsync();
        }
        public async Task<BaiViet> GetBaivietByIdDichvu(int id) //lấy bài viết bằng id dich vu
        {
            return await _context.BaiViets.Where(p => p.IsTintuc == false).FirstAsync(p => p.IdDichvu == id);
        }
        public async Task<BaiViet> GetBaivietByIdBaiviet(int id) //lấy bài viết bằng id bai viet
        {
            return await _context.BaiViets.Where(p => p.IsTintuc == false).FirstAsync(p => p.IdBaiviet == id);
        }
        //tintuc
        public async Task<List<BaiViet>> GetallTintuc()
        {
            return await _context.BaiViets.Where(p => p.IsTintuc == true).ToListAsync();
        }
        public async Task<BaiViet> GetTintucById(int id) 
        {
            return await _context.BaiViets.Where(p => p.IsTintuc == true).FirstAsync(p => p.IdBaiviet == id);
        }

        public async Task<bool> DeleteBaiviet(int id)
        {
            var baiviet = await _context.BaiViets.FirstAsync(p => p.IdBaiviet == id);
            if (baiviet != null)
            {
                _context.BaiViets.Remove(baiviet);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateBaiviet(BaiViet baiviet)
        {
            if (baiviet != null)
            {
                _context.BaiViets.Update(baiviet);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> AddBaiviet(BaiViet baiviet)
        {
            if (baiviet != null)
            {
                _context.BaiViets.Add(baiviet);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

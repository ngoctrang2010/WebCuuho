using Microsoft.EntityFrameworkCore;
using WebRong.Models;

namespace WebRong.Repository
{
    public class EFDichvuRepository : IDichvuRepository
    {
        private readonly CuuhoWebContext _context;
        public EFDichvuRepository(CuuhoWebContext context)
        {
            _context = context;
        }
        public async Task<List<DichVu>> GetallDichvu()
        {
            return await _context.DichVus.ToListAsync();
        }
        public async Task<DichVu> GetDichvutById(int id)
        {
            return await _context.DichVus.FirstAsync(p => p.IdDichvu == id);
        }
        public async Task<bool> DeleteDichvu(int id)
        {
            var divhvu = await _context.DichVus.FirstAsync(p => p.IdDichvu == id);
            if (divhvu != null)
            {
                _context.DichVus.Remove(divhvu);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateDichvu(DichVu dichvu)
        {
            if (dichvu != null)
            {
                _context.DichVus.Update(dichvu);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> AddDichvu(DichVu dichvu)
        {
            if (dichvu != null)
            {
                _context.DichVus.Add(dichvu);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

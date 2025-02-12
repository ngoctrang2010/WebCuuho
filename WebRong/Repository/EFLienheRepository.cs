using Microsoft.EntityFrameworkCore;
using WebRong.Models;

namespace WebRong.Repository
{
    public class EFLienheRepository : ILienheRepository
    {
        private readonly CuuhoWebContext _context;
        public EFLienheRepository(CuuhoWebContext context)
        {
            _context = context;
        }
        public async Task<List<LienHe>> GetallLienhe()
        {
            return await _context.LienHes.ToListAsync();
        }
        public async Task<LienHe> GetLienheById(int id)
        {
            return await _context.LienHes.FirstAsync(p => p.IdLienhe == id);
        }
        public async Task<List<LienHe>> GetallLienheHoanthanh()
        {
            return await _context.LienHes.Where(p => p.Hoanthanh == true).ToListAsync();
        }
        public async Task<List<LienHe>> GetallLienheChuaHoanthanh()
        {
            return await _context.LienHes.Where(p => p.Hoanthanh == false).ToListAsync();
        }
        public async Task<bool> UpdateLienhe(LienHe lienHe)
        {
            if (lienHe != null)
            {
                _context.LienHes.Update(lienHe);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> AddLienhe(LienHe lienHe)
        {
            if (lienHe != null)
            {
                _context.LienHes.Add(lienHe);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

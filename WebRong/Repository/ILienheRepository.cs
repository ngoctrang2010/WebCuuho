using Microsoft.EntityFrameworkCore;
using WebRong.Models;

namespace WebRong.Repository
{
    public interface ILienheRepository
    {
        public Task<List<LienHe>> GetallLienhe();
        public Task<LienHe> GetLienheById(int id);
        public Task<List<LienHe>> GetallLienheHoanthanh();
        public Task<List<LienHe>> GetallLienheChuaHoanthanh();
        public Task<bool> UpdateLienhe(LienHe lienHe);
        public Task<bool> AddLienhe(LienHe lienHe);
    }
}

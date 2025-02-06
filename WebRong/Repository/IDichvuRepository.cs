using Microsoft.EntityFrameworkCore;
using WebRong.Models;

namespace WebRong.Repository
{
    public interface IDichvuRepository
    {
        public Task<List<DichVu>> GetallDichvu();
        public Task<DichVu> GetDichvutById(int id);
        public Task<bool> DeleteDichvu(int id);
        public Task<bool> UpdateDichvu(DichVu dichvu);
        public Task<bool> AddDichvu(DichVu dichvu);
    }
}

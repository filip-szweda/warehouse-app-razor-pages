using warehouse_app.Data;
using warehouse_lib.Model;
using Microsoft.EntityFrameworkCore;

namespace warehouse_app.Services
{
    public class Api
    {
        private readonly ApplicationDbContext _context;

        public Api(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            return users.Select(u => u.Email).ToList();
        }

        public async Task<List<string>> GetAllWatersAsync()
        {
            var waters = await _context.WaterTypes.ToListAsync();

            return waters.Select(w => w.Type).ToList();
        }
    }
}

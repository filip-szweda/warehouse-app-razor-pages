using warehouse_app.Data;
using Microsoft.EntityFrameworkCore;
using warehouse_lib.DTO;

namespace warehouse_app.Services
{
    public class Api
    {
        private readonly ApplicationDbContext _context;

        public Api(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<warehouse_lib.DTO.User>> GetRegisteredUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            return users.Select(u => new warehouse_lib.DTO.User
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email
            }).ToList();
        }

        public async Task<List<string>> GetWaterTypesAsync()
        {
            var waters = await _context.WaterTypes.ToListAsync();

            return waters.Select(w => w.Type).ToList();
        }

        public async Task<List<warehouse_lib.DTO.Water>> GetWatersAsync()
        {
            var waters = await _context.Waters
                .Include(w => w.Packaging)
                .Include(w => w.Producer)
                .Include(w => w.Type)
                .Include(w => w.Cations)
                .Include(w => w.Anions)
                .Include(water => water.DeliveryDetails)
                .Include(water => water.SaleDetails)
                .ToListAsync();

            return waters.Select(w => new warehouse_lib.DTO.Water
            {
                Id = w.Id,
                Name = w.Name,
                TypeId = w.Type.Id,
                ProducerId = w.Producer.Id,
                pH = w.pH,
                CationsIds = w.Cations.Select(c => c.Id).ToList(),
                AnionsIds = w.Anions.Select(a => a.Id).ToList(),
                Mineralization = w.Mineralization,
                PackingTypeId = w.Packaging.Id,
                DeliveryDetailsIds = w.DeliveryDetails.Select(d => d.Id).ToList(),
                SaleDetailsIds = w.SaleDetails.Select(s => s.Id).ToList()
            }).ToList();
        }
    }
}

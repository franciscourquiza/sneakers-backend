using BeIceProyect.Server.Dtos;
using BeIceProyect.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeIceProyect.Server.Repositories
{
    public class CapRepository
    {
        private readonly Context _context;
        public CapRepository(Context context) 
        {
            _context = context;
        }
        public async Task<Cap?> GetById(int id)
        {
            Cap? cap = await _context.Caps.FirstOrDefaultAsync(s => s.Id == id);
            return cap;
        }
        public async Task<List<Cap>> GetByName(string name)
        {
            var caps = await _context.Caps.Where(s => EF.Functions.Like(s.Name, $"%{name}%") && s.IsInDiscount == false).ToListAsync();
            return caps;
        }
        public async Task<List<Cap>> GetAll()
        {
            var caps = await _context.Caps.AsNoTracking().ToListAsync();
            return caps;
        }
        public async Task<Cap> Create(EditCapDto body)
        {
            if (body == null)
            {
                throw new InvalidOperationException("Completa el formulario correctamente.");
            }
            var cap = new Cap
            {
                Name = body.Name,
                Price = body.Price,
                ImageUrl = body.ImageUrl,
                IsInDiscount = body.IsInDiscount,
                Category = "cap",
            };

            await _context.Caps.AddAsync(cap);
            await _context.SaveChangesAsync();
            return cap;
        }
        public async Task<Cap?> EditById(int id, EditCapDto updatedCapDto)
        {
            if (updatedCapDto == null)
            {
                throw new ArgumentException("Datos inválidos.");
            }

            Cap? existingCap = await _context.Caps
                .FirstOrDefaultAsync(s => s.Id == id);
            if (existingCap == null)
            {
                return null; // Devuelve null si no encuentra la sneaker
            }

            // Actualiza los campos
            existingCap.Name = updatedCapDto.Name;
            existingCap.Price = updatedCapDto.Price;
            existingCap.ImageUrl = updatedCapDto.ImageUrl;
            existingCap.IsInDiscount = updatedCapDto.IsInDiscount;

            await _context.SaveChangesAsync();
            return existingCap;
        }
        public async Task Delete(int id)
        {
            Cap? cap = await GetById(id);
            if (cap == null)
            {
                throw new ArgumentNullException("No se encontró un producto con ese ID.");
            }
            _context.Caps.Remove(cap);
            await _context.SaveChangesAsync();
        }
    }
}

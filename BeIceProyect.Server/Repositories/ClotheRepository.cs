using BeIceProyect.Server.Dtos;
using BeIceProyect.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeIceProyect.Server.Repositories
{
    public class ClotheRepository
    {
        private readonly Context _context;
        public ClotheRepository(Context context) 
        {
            _context = context;
        }
        public async Task<Clothe?> GetById(int id)
        {
            Clothe? clothe = await _context.Clothes.FirstOrDefaultAsync(s => s.Id == id);
            return clothe;
        }
        public async Task<List<Clothe>> GetByName(string name)
        {
            var clothes = await _context.Clothes.Where(s => EF.Functions.Like(s.Name, $"%{name}%") && s.IsInDiscount == false).ToListAsync();
            return clothes;
        }
        public async Task<List<Clothe>> GetAll()
        {
            var clothes = await _context.Clothes.AsNoTracking().ToListAsync();
            return clothes;
        }
        public async Task<Clothe> Create(EditClotheDto body)
        {
            if (body == null)
            {
                throw new InvalidOperationException("Completa el formulario correctamente.");
            }
            var clothe = new Clothe
            {
                Name = body.Name,
                Price = body.Price,
                ImageUrl = body.ImageUrl,
                Sizes = body.Sizes,
                IsInDiscount = body.IsInDiscount,
            };

            await _context.Clothes.AddAsync(clothe);
            await _context.SaveChangesAsync();
            return clothe;
        }
        public async Task<Clothe?> EditById(int id, EditClotheDto updatedClotheDto)
        {
            if (updatedClotheDto == null)
            {
                throw new ArgumentException("Datos inválidos.");
            }

            Clothe? existingClothe = await _context.Clothes
                .FirstOrDefaultAsync(s => s.Id == id);
            if (existingClothe == null)
            {
                return null; // Devuelve null si no encuentra la sneaker
            }

            // Actualiza los campos
            existingClothe.Name = updatedClotheDto.Name;
            existingClothe.Price = updatedClotheDto.Price;
            existingClothe.ImageUrl = updatedClotheDto.ImageUrl;
            existingClothe.IsInDiscount = updatedClotheDto.IsInDiscount;

            await _context.SaveChangesAsync();
            return existingClothe;
        }
        public async Task Delete(int id)
        {
            Clothe? clothe = await GetById(id);
            if (clothe == null)
            {
                throw new ArgumentNullException("No se encontró un producto con ese ID.");
            }
            _context.Clothes.Remove(clothe);
            await _context.SaveChangesAsync();
        }
    }
}

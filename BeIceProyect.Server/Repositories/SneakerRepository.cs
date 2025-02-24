using BeIceProyect.Server.Dtos;
using BeIceProyect.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace BeIceProyect.Server.Repositories
{
    public class SneakerRepository
    {
        private readonly Context _context;
        public SneakerRepository(Context context)
        {
            _context = context;
        }
        public async Task<Sneaker?> GetById(int id)
        {
            Sneaker? sneaker = await _context.Sneakers.Include(s => s.Sizes).FirstOrDefaultAsync(s => s.Id == id);
            return sneaker;
        }
        public async Task<List<Sneaker>> GetByName(string name)
        {
            var sneakers = await _context.Sneakers.Where(s => EF.Functions.Like(s.Name, $"%{name}%") && s.IsInDiscount == false).Include(s => s.Sizes).ToListAsync();
            return sneakers;
        }
        public async Task<List<Sneaker>> GetByNameInDiscount(string name)
        {
            var sneakers = await _context.Sneakers.Where(s => EF.Functions.Like(s.Name, $"%{name}%") && s.IsInDiscount == true).Include(s => s.Sizes).ToListAsync();
            return sneakers;
        }
        public async Task<List<Sneaker>> GetAll()
        {
            var sneakers = await _context.Sneakers.AsNoTracking().Include(s => s.Sizes).Where(s => !s.IsInDiscount).ToListAsync();
            return sneakers;
        }

        public async Task<List<Sneaker>> GetAllInDiscount()
        {
            var sneakers = await _context.Sneakers.AsNoTracking().Include(s => s.Sizes).Where(s => s.IsInDiscount).ToListAsync();
            return sneakers;
        }

        public async Task<List<Sneaker>> GetBySize(int size)
        {
            var sneakers = await _context.Sneakers.Where(s => s.Sizes.Any(sz => sz.Size == size)).Include(s => s.Sizes).ToListAsync();
            return sneakers;
        }

        public async Task<Sneaker> Create(EditProductDto body)
        {
            if (body == null)
            {
                throw new InvalidOperationException("Completa el formulario correctamente.");
            }
            var sneaker = new Sneaker
            {
                Name = body.Name,
                Price = body.Price,
                ImageUrl = body.ImageUrl,
                Sizes = body.Sizes.Select(size => new SneakersSize { Size = size }).ToList(),
                IsInDiscount = body.IsInDiscount,
            };

            await _context.Sneakers.AddAsync(sneaker);
            await _context.SaveChangesAsync();
            return sneaker;
        }

        public async Task<Sneaker?> EditById(int id, EditProductDto updatedSneakerDto)
        {
            if (updatedSneakerDto == null)
            {
                throw new ArgumentException("Datos inválidos.");
            }

            Sneaker? existingSneaker = await _context.Sneakers
                .Include(s => s.Sizes) // Asegúrate de cargar la relación Sizes
                .FirstOrDefaultAsync(s => s.Id == id);
            if (existingSneaker == null)
            {
                return null; // Devuelve null si no encuentra la sneaker
            }

            // Actualiza los campos
            existingSneaker.Name = updatedSneakerDto.Name;
            existingSneaker.Price = updatedSneakerDto.Price;
            existingSneaker.ImageUrl = updatedSneakerDto.ImageUrl;
            existingSneaker.IsInDiscount = updatedSneakerDto.IsInDiscount;

            _context.SneakersSizes.RemoveRange(existingSneaker.Sizes);

            existingSneaker.Sizes = updatedSneakerDto.Sizes.Select(size => new SneakersSize { Size = size }).ToList();

            await _context.SaveChangesAsync();
            return existingSneaker;
        }

        public async Task Delete(int id)
        {
            Sneaker? sneaker = await GetById(id);
            if (sneaker == null)
            {
                throw new ArgumentNullException("No se encontró un producto con ese ID.");
            }
            _context.Sneakers.Remove(sneaker);
            await _context.SaveChangesAsync();
        }
    }
}

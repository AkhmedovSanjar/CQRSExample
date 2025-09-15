using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CQRSExample.CQRS.Commands
{
    public class UpdateProductCommandHandler
    {
        private readonly AppDbContext _context;
        public UpdateProductCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateProductCommand command)
        {
            var product = await _context.Products.FindAsync(command.Id);
            if (product == null) return false;
            product.Name = command.Name;
            product.Price = command.Price;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

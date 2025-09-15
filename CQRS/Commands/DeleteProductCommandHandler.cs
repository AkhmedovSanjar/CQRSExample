using System.Threading.Tasks;

namespace CQRSExample.CQRS.Commands
{
    public class DeleteProductCommandHandler
    {
        private readonly AppDbContext _context;
        public DeleteProductCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteProductCommand command)
        {
            var product = await _context.Products.FindAsync(command.Id);
            if (product == null) return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

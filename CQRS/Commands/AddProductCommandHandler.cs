using System.Threading.Tasks;

namespace CQRSExample.CQRS.Commands
{
    public class AddProductCommandHandler
    {
        private readonly AppDbContext _context;
        public AddProductCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddProductCommand command)
        {
            var product = new Product { Name = command.Name, Price = command.Price };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}

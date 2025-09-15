using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CQRSExample.CQRS.Queries
{
    public class GetProductByIdQueryHandler
    {
        private readonly AppDbContext _context;
        public GetProductByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> Handle(GetProductByIdQuery query)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == query.Id);
        }
    }
}

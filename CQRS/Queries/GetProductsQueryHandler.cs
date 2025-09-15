using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CQRSExample.CQRS.Queries
{
    public class GetProductsQueryHandler
    {
        private readonly AppDbContext _context;
        public GetProductsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Handle(GetProductsQuery query)
        {
            return await _context.Products.ToListAsync();
        }
    }
}

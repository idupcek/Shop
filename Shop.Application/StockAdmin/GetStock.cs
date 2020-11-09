using Microsoft.EntityFrameworkCore;
using Shop.Database;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.StockAdmin
{
    public class GetStock
    {
        private readonly ApplicationDbContext _ctx;

        public GetStock(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ProductViewModel> Do()
        {
            var stock = _ctx.Products
                .Include(s => s.Stock)
                .Select(p => new ProductViewModel
                { 
                    Id = p.Id,
                    Description = p.Description,
                    Stock = p.Stock.Select(s => new StockViewModel
                    {
                        Id = s.Id,
                        Description = s.Description,
                        Qty = s.Qty
                    })
                })
                .ToList();

            return stock;
        }

        public class StockViewModel
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public string Description { get; set; }
            public string Qty { get; set; }
        }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public IEnumerable<StockViewModel> Stock { get; set; }
        }
    }
}

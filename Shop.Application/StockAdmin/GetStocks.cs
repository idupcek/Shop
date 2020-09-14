using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.StockAdmin
{
    public class GetStocks
    {
        private readonly ApplicationDbContext _ctx;

        public GetStocks(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<StockViewModel> Do(int productId)
        {
            var stock = _ctx.Stock
                .Where(s => s.ProductId == productId)
                .Select(s => new StockViewModel
                { 
                    Id = s.Id, 
                    Description = s.Description, 
                    Qty = s.Qty
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
    }
}

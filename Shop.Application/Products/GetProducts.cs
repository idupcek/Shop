using Shop.Database;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.GetProducts
{
    public class GetProducts
    {
        private readonly ApplicationDbContext _ctx;

        public GetProducts(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ProductViewModel> Do() => 
            _ctx.Products.ToList().Select(p => new ProductViewModel 
            { 
                Name = p.Name, 
                Description = p.Description, 
                Value = $"$ {p.Value.ToString("N2")}" // 1100.50 => 1,100.50 => $ 1,100.50
            }); 
        
    }

    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }
}

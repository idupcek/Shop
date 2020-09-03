using Shop.Database;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.ProductsAdmin
{
    public class GetProduct
    {
        private readonly ApplicationDbContext _ctx;

        public GetProduct(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ProductViewModel Do(int id) => 
            _ctx.Products.Where(p => p.Id == id).Select(p => new ProductViewModel 
            { 
                Id = p.Id,
                Name = p.Name, 
                Description = p.Description, 
                Value = $"$ {p.Value.ToString("N2")}" // 1100.50 => 1,100.50 => $ 1,100.50
            }).FirstOrDefault(); 
        
        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
        }
    }

}

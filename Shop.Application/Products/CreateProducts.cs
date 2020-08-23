using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CreateProducts
{
    public class CreateProducts
    {
        private readonly ApplicationDbContext _ctx;

        public CreateProducts(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Do(ProductViewModel vm)
        {
            _ctx.Products.Add(new Product 
            { 
                Name = vm.Name, 
                Description = vm.Description,
                Value = vm.Value

            });

            await _ctx.SaveChangesAsync();
        }

    }
        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
}

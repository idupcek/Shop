using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.ProductAdmin;
using Shop.Application.ProductsAdmin;
using Shop.Database;

namespace Shop.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;

        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<GetProduct.ProductViewModel> Products { get; set; }
       
        public void OnGet()
        {
            Products = (IEnumerable<GetProduct.ProductViewModel>)new GetProducts(_ctx).Do();
        }

    }
}

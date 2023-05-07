using DesignPattern.Composite.CompositePattern;
using DesignPattern.Composite.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Composite.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Context _context;

        public DefaultController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.Include(x => x.Products).ToList();
            var values = Rekursive(categories, new Category { Name = "firs category", Id = 0 }, new ProductComposite(0, "first composite"));
            ViewBag.v = values;
            return View();
        }

        public ProductComposite Rekursive(List<Category> categories, Category firsCategory, ProductComposite firstComposite, ProductComposite leaf = null)
        {
            categories.Where(x => x.UpperCategoryId == firsCategory.Id).ToList().ForEach(y =>
            {
                var productsComposite = new ProductComposite(y.Id, y.Name);

                y.Products.ToList().ForEach(z =>
                {
                    productsComposite.Add(new ProductComponent(z.Id, z.Name));
                });

                if (leaf != null)
                {
                    leaf.Add(productsComposite);
                }
                else
                {
                    firstComposite.Add(productsComposite);
                }
                Rekursive(categories, y, firstComposite, productsComposite);
            });
            return firstComposite;
        }
    }
}

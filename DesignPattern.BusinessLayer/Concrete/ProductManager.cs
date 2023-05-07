using DesignPattern.BusinessLayer.Abstract;
using DesignPattern.DataAccessLayer.Abstract;
using DesignPattern.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productService;

        public ProductManager(IProductDal productService)
        {
            _productService = productService;
        }

        public void TDelete(Product t)
        {
            _productService.Delete(t);
        }

        public Product TGetById(int id)
        {
            return _productService.GetById(id);
        }

        public List<Product> TGetList()
        {
            return _productService.GetList();
        }

        public void TInsert(Product t)
        {
            _productService.Insert(t);
        }

        public List<Product> TProductListWithCategory()
        {
            return _productService.ProductListWithCategory();
        }

        public void TUpdate(Product t)
        {
            _productService.Update(t);
        }
    }
}

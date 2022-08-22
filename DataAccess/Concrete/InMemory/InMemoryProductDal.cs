using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product> {
            new Product { ProductId = 1,BrandId = 1, ColorId=1, ModelYear=2020, DailyPrice=2000, Description="aile arabası"},
            new Product { ProductId = 2,BrandId = 2,ColorId=2, ModelYear=2018, Description="düğünlük",DailyPrice=2500},
            new Product { ProductId = 3,BrandId = 3,ColorId=3, ModelYear=2017, DailyPrice =3500, Description="ticari"},
            new Product{ ProductId = 4,BrandId = 4,ColorId=4, ModelYear=2015,Description="nakliye", DailyPrice=4500}
            };
        }

    

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByProduct(int ProductId)
        {
            return _products.Where(p => p.ProductId == ProductId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.BrandId = product.BrandId;
            productToUpdate.ModelYear = product.ModelYear;
            productToUpdate.ColorId = product.ColorId;  
            productToUpdate.Description = product.Description;
        }
    }
}

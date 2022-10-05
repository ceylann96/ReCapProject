using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarDal
    {
        List<Car> _products;

        public InMemoryProductDal()
        {
            _products = new List<Car> {
            new Car { CarId = 1,BrandId = 1, ColorId=1, ModelYear=2020, DailyPrice=2000, Description="aile arabası"},
            new Car { CarId = 2,BrandId = 2,ColorId=2, ModelYear=2018, Description="düğünlük",DailyPrice=2500},
            new Car { CarId = 3,BrandId = 3,ColorId=3, ModelYear=2017, DailyPrice =3500, Description="ticari"},
            new Car{ CarId = 4,BrandId = 4,ColorId=4, ModelYear=2015,Description="nakliye", DailyPrice=4500}
            };
        }

    

        public void Add(Car product)
        {
            _products.Add(product);
        }

        public void Delete(Car product)
        {
            Car productToDelete = _products.SingleOrDefault(p => p.CarId == product.CarId);
            _products.Remove(productToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _products;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByProduct(int ProductId)
        {
            return _products.Where(p => p.CarId == ProductId).ToList();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car product)
        {
            Car productToUpdate = _products.SingleOrDefault(p => p.CarId == product.CarId);
            productToUpdate.CarId = product.CarId;
            productToUpdate.BrandId = product.BrandId;
            productToUpdate.ModelYear = product.ModelYear;
            productToUpdate.ColorId = product.ColorId;  
            productToUpdate.Description = product.Description;
        }
    }
}

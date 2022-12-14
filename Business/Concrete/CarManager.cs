using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }



        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarAdded);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=> p.ColorId == id)); 
        }

        [SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        [PerformanceAspect(20)]
        public IResult Add(Car car)
        {
         
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
           
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUptated);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);

        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<Car> GetCarById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailsById(int carId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(h => h.CarId == carId));
        }

        //public IDataResult<List<CarDetailsDto>> GetCarDetailsByBrandId(int brandId)
        //{
        //    return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(p => p.BrandId == brandId));
        //}

        //public IDataResult<List<CarDetailsDto>> GetCarDetailsByColorId(int colorId)
        //{
        //    return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId));
        //}
    }
}

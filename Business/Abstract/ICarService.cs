using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetCarById(int carId);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        


        
        IResult Add(Car car); 
        IResult Update(Car car);
        IResult Delete(Car car);


        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<List<CarDetailsDto>> GetCarDetailsById(int carId);
        //IDataResult<List<CarDetailsDto>> GetCarDetailsByBrandId(int brandId);
        //IDataResult<List<CarDetailsDto>> GetCarDetailsByColorId(int colorId);
    }
}

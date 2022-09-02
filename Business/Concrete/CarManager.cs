using Business.Abstract;
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
     

     

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p=> p.ColorId == id); 
        }

        public void Add(Car car)
        {
            if (car.DailyPrice>=0 && car.Description.Length>= 2)
            {
                _carDal.Add(car);
                Console.WriteLine("Arac Eklendi");
            }
            else
            {
                Console.WriteLine("eklenemz");
            }
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Secilen arac güncellendi");
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Arac silindi");

        }

        public List<CarDetailsDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
        
        Car ICarService.GetCarById(int id)
        {
            return _carDal.Get(c => c.CarId == id);
        }
    }
}

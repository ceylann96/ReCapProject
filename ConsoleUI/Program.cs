using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Data.SqlClient;


namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();




















        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var colors in colorManager.GetAll())
            {
                Console.WriteLine(colors.ColorId + " " + colors.ColorName);
            }
            colorManager.Add(new Color { ColorName = "yeni renk" });
            colorManager.Delete(new Color { ColorId = 7 });
            colorManager.Update(new Color { ColorId = 6, ColorName = "yepyeni" });
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brands in brandManager.GetAll())
            {
                Console.WriteLine(brands.BrandId + " / " + brands.BrandName);
            }

            brandManager.Add(new Brand { BrandName = "Only Testing" });
            brandManager.Delete(new Brand { BrandId = 1007 });
            brandManager.Update(new Brand { BrandId = 7, BrandName = "Lamboo" });
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var cars in carManager.GetCarDetails())
            {
                Console.WriteLine(cars.CarName + " / " + cars.BrandName + " / " + cars.ColorName + " / " + cars.DailyPrice);
            }
            carManager.Add(new Car
            {
                CarName = "kadir",
                ColorId = 2,
                BrandId = 2,
                DailyPrice = 5895,
                Description = "yeni eklendi",
                ModelYear = 1998

            });

            carManager.Delete(new Car
            {
                CarId = 2002

            });

            carManager.Update(new Car
            {
                CarId = 4,
                BrandId = 1551,
                CarName = "şako",
                ColorId = 11,
                DailyPrice = 155,
                Description = "test",
                ModelYear = 1980
            });
        }
    }

}




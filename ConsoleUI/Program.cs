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
            CarTest();
            //BrandTest();
            //ColorTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var cars in result.Data)
                {
                    Console.WriteLine(cars.CarName + "/" + cars.BrandName + "/" + cars.ColorName + "/" + cars.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            carManager.Add(new Car { CarName = "Testing22", BrandId = 2, ColorId = 2, DailyPrice = 7950,
                Description = "Testing22", ModelYear = 1996 });
            
        }





        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if(result.Success == true)
            {
                foreach (var colors in result.Data)
                {
                    Console.WriteLine(colors.ColorName+ colors.ColorId);
                }
            }
            colorManager.Add(new Color { ColorName = "yeni renk79" });
            colorManager.Delete(new Color { ColorId = 7 });
            colorManager.Update(new Color { ColorId = 6, ColorName = "yepyeni" });
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var Result = brandManager.GetAll();
            if (Result.Success == true)
            {
                foreach (var brands in Result.Data)
                {
                    Console.WriteLine(brands.BrandName);
                }
            }


            brandManager.Add(new Brand { BrandName = "Only Testing" });
            brandManager.Delete(new Brand { BrandId = 1007 });
            brandManager.Update(new Brand { BrandId = 2, BrandName = "Lamboo2" });
        }

       
    }

}




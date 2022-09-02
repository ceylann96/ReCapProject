using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapSql>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (ReCapSql context = new ReCapSql())
            {
                var result = from c in context.Carss
                             join b in context.Brandss
                             on c.BrandId equals b.BrandId
                             join c2 in context.Colorss
                             on c.ColorId equals c2.ColorId
                             select new CarDetailsDto
                             { CarName=c.CarName , BrandName=b.BrandName , 
                                 ColorName=c2.ColorName, DailyPrice=c.DailyPrice

                             };
                return result.ToList();

            }
        }
    }
}

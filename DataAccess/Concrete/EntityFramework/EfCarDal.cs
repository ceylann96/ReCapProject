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
        public List<CarDetailsDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {

            using (ReCapSql context = new ReCapSql())
            {
                var result = from c in filter is null? context.Carss : context.Carss.Where(filter)
                             join b in context.Brandss
                             on c.BrandId equals b.BrandId
                             join c2 in context.Colorss
                             on c.ColorId equals c2.ColorId
                             join i in context.CarImagess
                             on c.CarId equals i.CarId
                             select new CarDetailsDto
                             { CarId=c.CarId,BrandName=b.BrandName , 
                                 ColorName=c2.ColorName, DailyPrice=c.DailyPrice,
                                 ModelYear=c.ModelYear,
                                 BrandId=c.BrandId,
                                 ColorId=c.ColorId,
                                 Description=c.Description,
                                 ImagePath=i.ImagePath,

                             };
                return result.ToList();
               

            }
        }
    }
}

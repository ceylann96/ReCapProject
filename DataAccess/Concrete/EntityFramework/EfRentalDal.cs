using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapSql>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (ReCapSql context = new ReCapSql())
            {
                var result = from a in context.Rentalss
                             join b in context.Carss
                             on a.CarId equals b.CarId
                             join b2 in context.Userss
                             on a.CustomerId equals b2.Id
                             select new RentalDetailsDto
                             {
                                 RentalId = a.RentalId,
                                 BrandName = b.CarName,
                                 RentDate = a.RentDate,
                                 ReturnDate = a.ReturnDate,
                                 FirstName = b2.FirstName,
                                 LastName = b2.LastName
                             };
                             return result.ToList();



            }
        }
    }
}

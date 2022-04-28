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
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RecapContext context = new RecapContext())
            {
                var result =from car in context.Cars
                            join b in context.Brands
                            on car.BrandId equals b.BrandId
                            join c in context.Colors
                            on car.ColorId equals c.ColorId
                            select new CarDetailDto 
                            { 
                                CarName = car.Descriptions,
                                ColorName=c.ColorName,
                                BrandName=b.BrandName,
                                DailyPrice=car.DailyPrice
                                                            
                            };

                return result.ToList();
                

            }
        }
    }
}

using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {BrandId=1,CarId=1, ColorId=2, DailyPrice=1000, ModelYear=new DateTime(1998), Description="BMW 320" },
                new Car {BrandId=2,CarId=1, ColorId=4, DailyPrice=800, ModelYear=new DateTime(1998), Description="PASSAT" },
                new Car {BrandId=3,CarId=1, ColorId=1, DailyPrice=750, ModelYear=new DateTime(1998), Description="GOLF" },
                new Car {BrandId=4,CarId=1, ColorId=2, DailyPrice=500, ModelYear=new DateTime(1998), Description="POLO" },
                new Car {BrandId=5,CarId=1, ColorId=3, DailyPrice=250, ModelYear=new DateTime(1998), Description="EGEA" },

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.FirstOrDefault(c => c.CarId == car.CarId); // gönderilen car ıd ile listedeki(database) car ıd eşleşiyorsa referanslarını eşitle
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c=>c.BrandId==brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToDelete = _cars.FirstOrDefault(c => c.CarId == car.CarId);
            carToDelete.DailyPrice = car.DailyPrice;
            carToDelete.ModelYear  =car.ModelYear;
            carToDelete.BrandId = car.BrandId;
        }
    }
}

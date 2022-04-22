using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{

    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { DailyPrice=350, Descriptions="sahibinden satılık", ModelYear= "2015", ColorId=1, BrandId=2});
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Descriptions);
            }

        }
    }
}
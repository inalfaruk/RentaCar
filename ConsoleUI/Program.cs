using Business.Concrete;
using Core.Concrete.EntityFramework;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //   BrandTest();
            //  CarDetailsTest();

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetByDailyPrice(30, 100)) 
            {
                Console.WriteLine(car.CarName);

            }




            static void CarDetailsTest()
            {
                CarManager carManager = new CarManager(new EfCarDal());

                foreach (var car in carManager.GetCarDetails())
                {
                    Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName);

                }
            }

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBandDal());

            foreach (var category in brandManager.GetAll())
            {
                Console.WriteLine(category.BrandName);
            }
        }
    }
}

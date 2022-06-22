using Business.Concrete;

using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
             // BrandTest();
         //     CarDetailsTest();

            //GetDailyPrice();

        //    static void CarDetailsTest()
        //    {
        //      ////  CarManager carManager = new CarManager(new EfCarDal());

        //      //var result=   carManager.GetCarDetails();

        //      //  if (result.Success==true)
        //      //  {
        //      //      foreach (var car in carManager.GetCarDetails().Data)
        //      //      {
        //      //           Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName);
        //      //      }
                    

        //        else
        //        {
        //            Console.WriteLine(result.Message);
        //        }
                 
               
        //    }

        //}

        //private static void GetDailyPrice()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetByDailyPrice(30, 100).Data)
        //    {
        //        Console.WriteLine(car.CarName);

        //    }
        //}

        //private static void BrandTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBandDal());

        //    foreach (var category in brandManager.GetAll().Data)
        //    {
        //        Console.WriteLine(category.BrandName);
        //    }
        }
    }
}

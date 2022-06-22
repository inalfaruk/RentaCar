using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;
        IColorService _colorService;
        public CarManager(ICarDal carDal, IColorService colorService)
        {
            _carDal = carDal;
            _colorService = colorService;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //  ValidationTool.Validate(new CarValidator(), car);

         IResult result =    BusinessRules.Run(CheckIfCarCountOfColorCorrect(car.ColorId),
             CheckIfCarNameExists(car.CarName),
             CheckIfColorLimitExceded());

            if (result!=null )
            {
                return result;

            }
            _carDal.Add(car);

                return new SuccessDataResult<List<Car>>(Messages.CarAdded);

            


        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessDataResult<List<Car>>(Messages.CarDeleted); ;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        //public IDataResult<List<Car>> GetAllByCategoryId(int categoryId)
        //{
        //    return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.CategoryId == categoryId));
        //}

        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == Id));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice <= min && p.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IResult Update(Car car)
        {


         IResult result =   BusinessRules.Run(CheckIfCarCountOfColorCorrect(car.ColorId), 
             CheckIfCarNameExists(car.CarName),
             CheckIfColorLimitExceded());


            //BusinessRules ile
            if (result!=null)
            {
                return result;
            }
            _carDal.Update(car);

                return new SuccessDataResult<List<Car>>(Messages.CarUpdated);


            //BusinessRules'dan önce
            //if (CheckIfCarCountOfColorCorrect(car.ColorId).Success)
            //{
            //if (CheckIfCarNameExists(car.CarName).Success)
           // {
            //    _carDal.Update(car);

            //    return new SuccessDataResult<List<Car>>(Messages.CarUpdated);
            //}
            //}

            //return new ErrorResult();
        }



        public IResult CheckIfCarCountOfColorCorrect(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarCountOfColorError);

            }
            return new SuccessResult();
        }


        public IResult CheckIfCarNameExists(string carName)
        {

            var result = _carDal.GetAll(c => c.CarName == carName).Any();

            if (result)
            {

                return new ErrorResult(Messages.CarNameAlreadyExists);


            }

            return new SuccessResult();
        }


        public IResult CheckIfColorLimitExceded()
        {
            var result = _colorService.GetAll().Data.Count();
            if (result>15)
            {
                return new ErrorResult(Messages.ColorLimitExceded);
            }

            return new SuccessResult();

        }
            
            }
}

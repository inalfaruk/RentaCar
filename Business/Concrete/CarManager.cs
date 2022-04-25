using Business.Abstract;
using Business.Constants;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager :ICarService
    {

        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);

            }
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result();
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new DataResult<List<Car>>(_carDal.GetAll(),true);
        }

        public IDataResult<List<Car>> GetAllByCategoryId(int categoryId)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(p => p.CategoryId == categoryId),true);
        }

        public IDataResult<Car> GetById(int Id)
        {
            return new DataResult<Car>(_carDal.Get(c => c.Id == Id),true);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice <= min && p.DailyPrice <= max),true);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public List<Car> GetCarsByColorId(int colorId )
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new Result();

        }
    }
}

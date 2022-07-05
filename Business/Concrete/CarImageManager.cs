using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {

        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
          
           IResult result =  BusinessRules.Run(CheckIfCarCountOfImageCorrect(carImage.CarId));
            if (result!=null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(file,ImagesPath());
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult("resim eklendi");
        }

        public IResult Delete(CarImage carImage)
        {

         
            _fileHelper.Delete(ImagesPath()+carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();



        }
        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == imageId));
        }
        public IResult Update(IFormFile file,CarImage carImage)
        {
           carImage.ImagePath= _fileHelper.Update(file, ImagesPath()+ carImage.ImagePath, ImagesPath());
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
         
            return new SuccessResult();
        }



        public IResult CheckIfCarCountOfImageCorrect(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result>=5)
            {
                return new ErrorResult(Messages.CarCountOfImageError);
            }

            return new SuccessResult();
        
        
        }

        public IDataResult<List<CarImage>> GetCarImages(int carId)
        {
          return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
         
        }



        //private IDataResult<List<>>


        public string ImagesPath()
        {
            string imagePath= "wwwroot\\Uploads\\Images\\";
            return imagePath ;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
    }
}

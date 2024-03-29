﻿using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {

        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetCarImages(int carId);
        IResult Add(IFormFile file,CarImage carImage); 
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile file,CarImage carImage);
        public IDataResult<CarImage> GetByImageId(int imageId);


    }
}

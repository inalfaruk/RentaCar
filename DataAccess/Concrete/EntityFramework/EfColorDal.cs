﻿using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, RentaCarContext>, IColorDal
    {
       
    }
}
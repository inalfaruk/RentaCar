using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();

        IDataResult<List<Customer>> GetByUserId(int userId);

        Customer Get(int id);


    }
}

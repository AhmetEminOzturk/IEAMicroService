﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEAMicroService.BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        Task TCreateAsync(T entity);
        Task TUpdateAsync(T entity);
        Task TDeleteAsync(T entity);
        Task<T> TGetByIdAsync(int id);
        Task<List<T>> TGetAllAsync();
    }
}

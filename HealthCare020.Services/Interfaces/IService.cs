﻿using HealthCare020.Services.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface IService<TEntity, TResourceParameters>
    {
        Task<ServiceSequenceResult> Get(TResourceParameters resourceParameters);

        IQueryable<TEntity> GetWithEagerLoad(int? id = null);

        Task<ExpandoObject> GetById(int id, TResourceParameters resourceParameters);

        Task<PagedList<TEntity>> FilterAndPrepare(IQueryable<TEntity> result, TResourceParameters resourceParameters);


        IEnumerable<ExpandoObject> PrepareDataForClient(IEnumerable<TEntity> data, TResourceParameters resourceParameters);

        bool ShouldEagerLoad(TResourceParameters resourceParameters);
    }
}
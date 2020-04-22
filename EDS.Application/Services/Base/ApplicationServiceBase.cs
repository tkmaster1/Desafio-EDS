using EDS.Application.Interfaces.Base;
using EDS.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;

namespace EDS.Application.Services.Base
{
    public class ApplicationServiceBase<TEntity> : IDisposable, IApplicationServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public ApplicationServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}

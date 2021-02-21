using System;
using System.Collections.Generic;

namespace ArandaSoftwareData.Helpers
{
    public interface IRepositoryBase<T, T2> where T : class
    {
        T Add(T obj);
        T Update(T obj, T2 id);
        bool Delete(T2 id);
        List<T> GetAll();

        T GetById(T2 id);

        List<T> GetByParam(Func<T, bool> pre);

        void Save(T obj, T2 id);
    }
}
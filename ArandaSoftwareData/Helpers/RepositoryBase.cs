using ArandaSoftwareData.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArandaSoftwareData.Helpers
{
    public class RepositoryBase<T, T2> : IRepositoryBase<T, T2> where T : class
    {
        private readonly ArandaModel context;
        public RepositoryBase(ArandaModel context)
        {
            this.context = context;
        }
        ArandaModel d = new ArandaModel();
        public T Add(T obj)
        {

            context.Set<T>().Add(obj);
            context.SaveChanges();
            context.Dispose();
            return obj;

        }

        public bool Delete(T2 id)
        {
            var result = false;

            var item = context.Set<T>().Find(id);
            if (item != null)
            {
                context.Set<T>().Remove(item);
                context.SaveChanges();
                result = true;
            }

            return result;
        }

        public List<T> GetAll()
        {

            var item = context.Set<T>();
            return item.ToList();

        }

        public T GetById(T2 id)
        {

            return context.Set<T>().Find(id);

        }

        public List<T> GetByParam(Func<T, bool> pre)
        {

            var item = context.Set<T>().Where(pre);
            return item.ToList();

        }
        public T GetByParamFirst(Func<T, bool> pre)
        {

            var item = context.Set<T>().Where(pre);
            return item.FirstOrDefault();

        }
        public void Save(T obj, T2 id)
        {

            context.SaveChanges();

        }

        public T Update(T obj, T2 id)
        {

            var x = context.Entry(obj);
            context.Set<T>().Attach(obj);
            x.State = EntityState.Modified;
            context.SaveChanges();

            return obj;

        }
    }
}


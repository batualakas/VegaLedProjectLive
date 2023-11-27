﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Respositories
{
    public class GenericRespository<T> : IGenericDal<T> where T : class
    {
        protected Context c= new Context();
        public void Add(T entity)
        {
            c.Add(entity);
            c.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            c.Remove(entity);
            c.SaveChanges();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return c.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return c.Set<T>().Where(filter).ToList();
        }

        public T GetById(int id)
        {
            return c.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            c.Update(entity);
            c.SaveChanges();
        }

      
    }
}

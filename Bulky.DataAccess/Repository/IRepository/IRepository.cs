﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    //Generic Interface where T is class
    internal interface IRepository<T> where T : class
    {
        //T-Category, Where T is a Category Class
        //Different method related to it

        //Get All the Category from db
        IEnumerable<T> GetAll(); //COllections

        //Get a single category
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        void Remove(T entity);
        void Add(T entity);
        void RemoveRange(IEnumerable<T> entities);

       


    }
}

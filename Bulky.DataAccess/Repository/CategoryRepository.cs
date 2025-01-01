using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
 //Inherited Generic Repository class to use base methods[Add,getAll ,remove,RemoveRange]
 //and Implemented ICategoryRepository to use [update and save method]
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        //Db connectio n used from application DbContext
        //Passes the db to the base class REpository
        public CategoryRepository(ApplicationDbContext db) : base(db) {
           _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category obj)
        {
           _db.Categories.Update(obj);
        }
    }
}

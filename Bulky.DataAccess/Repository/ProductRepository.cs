using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
    //Inherited Generic Repository class to use base methods[Add,getAll ,remove,RemoveRange]
    //and Implemented ICategoryRepository to use [update and save method]
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
           _db = db;
        }

        public void Update(Product obj)
        {
            _db.Product.Update(obj);
        }
    }
}

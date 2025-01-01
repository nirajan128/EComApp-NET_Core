using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.Models;

//This inter face implments IRepository interface and gets all its base method [getAll, getfirstorDefault, Remove, REove Range]
//Since its a Interface it does not need implement the base method
namespace Bulky.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category> //Where the type is Category class
    {
        //IN Addition to the base method [Update and Save method are added to this Interface]
        public void Update(Category obj);
      
    }
}

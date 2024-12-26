using E_Web_NET_CORE.Data;
using E_Web_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Web_NET_CORE.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        //Connects to the database using the services from program.cs adn applicationDbContext.cs
        public CategoryController(ApplicationDbContext db)
        {
            _db  = db; //connection
        }
        public IActionResult Index()
        {
            //_db is the connection while Categories is the Table name in the database, .toList is the method used
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Used for post requests/method
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            _db.Categories.Add(obj); //Method of entity fame work: Keeps track of the changes
            _db.SaveChanges(); //Goes to the db and make changes
            return RedirectToAction("Index"); //Redirects to Index ation of category controller
        }
    }
}

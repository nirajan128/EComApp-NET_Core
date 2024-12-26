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
            //Customer error handling and validation
            //checks if both field has same value
            if (obj.Name == obj.DisplayOrder.ToString()) {
                ModelState.AddModelError("Name", "DisplayOrder cannot match the category Name");
            }

            //IF state of the category Model is valid meaning it completes all validation requirements
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj); //Method of entity fame work: Keeps track of the changes
                _db.SaveChanges(); //Goes to the db and make changes
                return RedirectToAction("Index"); //Redirects to Index ation of category controller
            }
          return View(); //if model is not valid it stays on the create view
        }
    }
}

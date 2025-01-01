using Microsoft.AspNetCore.Mvc;
using Bulky.DataAccess.Data;
using Bulky.Models;
using Bulky.DataAccess.Repository.IRepository;

namespace E_Web_NET_CORE.Controllers
{
    public class CategoryController : Controller
    {
        //ICategory Repository from Repository is used to replace the application DB context in controller [Same REpository can be used for different controller]
        //All the method except for [Update and Save ] are derived from base Interface Irepository
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db; //connection
        }
        public IActionResult Index()
        {
            //_db is the connection while Categories is the Table name in the database, .toList is the method used
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }

        //http get
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
                _categoryRepo.Add(obj); //Method of entity fame work: Keeps track of the changes
                _categoryRepo.Save(); //Goes to the db and make changes
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index"); //Redirects to Index ation of category controller
            }
            return View(); //if model is not valid it stays on the create view
        }


        //http get
        public IActionResult Edit(int? id) {

            //Checks if the provided paramenter is valid
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _categoryRepo.GetFirstOrDefault(u => u.Id == id); //find the category onject in db based on the id
            if (categoryFromDb == null) {
                return NotFound();
            }


            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid) {
                _categoryRepo.Update(obj); //Method of entity fame work: Keeps track of the changes
                _categoryRepo.Save();
                TempData["success"] = "Category Edited Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        //http get
        public IActionResult Delete(int? id)
        {

            //Checks if the provided paramenter is valid
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _categoryRepo.GetFirstOrDefault(u => u.Id == id); //find the category onject in db based on the id
            if (categoryFromDb == null)
            {
                return NotFound();
            }


            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")] //Specifies the name of the action since we have a different actionName
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _categoryRepo.GetFirstOrDefault(u => u.Id == id);
            if (obj == null) 
            {
                return NotFound();
            }
            _categoryRepo.Remove(obj); //Method of entity fame work: Keeps track of the changes
            _categoryRepo.Save();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}

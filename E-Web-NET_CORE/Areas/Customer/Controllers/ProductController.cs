﻿using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Web_NET_CORE.Areas.Customer.Controllers
{
    [Area("Customer")] //Tag helper to specify where ProductController belong to
    public class ProductController : Controller
    {
        //ICategory Repository from Repository is used to replace the application DB context in controller [Same REpository can be used for different controller]
        //All the method except for [Update and Save ] are derived from base Interface Irepository
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; //connection
        }
        public IActionResult Index()
        {
            //_db is the connection while Categories is the Table name in the database, .toList is the method used
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj) {
            //IF state of the category Model is valid meaning it completes all validation requirements
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj); //Method of entity fame work: Keeps track of the changes
                _unitOfWork.Save(); //Goes to the db and make changes
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index"); //Redirects to Index ation of category controller
            }
            return View(); //if model is not valid it stays on the create view
        }
    }
}

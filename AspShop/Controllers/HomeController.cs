using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopWebApp.Core.Interfaces;
using ShopWebApp.Core.Entities;

namespace ShopWebApp
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var model = new BaseViewModel("Shop");
            
            if (User.Identity.IsAuthenticated)
            {
                var users = await _unitOfWork.Repository<User>().ListAllAsync();
                var user = users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();

                model.User.Name = user.Name;
                model.User.Surname = user.Surname;
                model.User.Email = user.Email;
            }
            var products = await _unitOfWork.Repository<Product>().ListAllAsync();
            if (products.Where(p => p.Enabled && p.Stock != 0).Count() > 0)
            {
                int maxId = products.Max(p => p.ProductId), id;
                Random random = new Random();
                do
                {
                    id = random.Next(maxId + 1);
                }
                while (products.Where(p => p.ProductId == id && p.Enabled && p.Stock != 0).Count() == 0);
                ViewBag.product = products.Where(p => p.ProductId == id).FirstOrDefault();
                ViewBag.productExists = true;
            }
            else
            {
                ViewBag.productExists = false;
            }

            Dictionary<string, string> Categories = new Dictionary<string, string>();
            var categories = await _unitOfWork.Repository<Category>().ListAllAsync();

            foreach (Category category in categories)
            {
                Categories.Add(category.Name, category.Code);
            }

            ViewBag.categoriesExist = Categories.Count > 0 ? true : false;
            ViewBag.categories = Categories;


            return View(model);
        }

        [Route("/Error/{code:int}")]
        public async Task<IActionResult> Error(int code)
        {
            var model = new BaseViewModel("Shop");
            if (User.Identity.IsAuthenticated)
            {
                var users = await _unitOfWork.Repository<User>().ListAllAsync();
                var user = users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
            }
            ViewData["errorCode"] = code;
            ViewData["aboutError"] = "";
            if(code == 404)
            {
                ViewData["aboutError"] = "We're sorry, but the page with the given address does not exist";
            }
            model.Title = "An error occured";
            return View(model);
        }
    }
}

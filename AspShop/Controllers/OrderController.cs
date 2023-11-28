using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using ShopWebApp.Core.Entities;
using ShopWebApp.Core.Interfaces;
using System.Threading.Tasks;

namespace ShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index(OrderModel input)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_Cart")))
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                HttpContext.Session.SetString("_Cart", JsonSerializer.Serialize(dict));
            }
            Dictionary<string, int> cartDict = JsonSerializer.Deserialize<Dictionary<string, int>>(HttpContext.Session.GetString("_Cart"));
            var model = new OrderModel();
            model.Cart = cartDict;
            if (User.Identity.IsAuthenticated)
            {
                var users = await _unitOfWork.Repository<User>().ListAllAsync();
                var user = users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
                model.User.Name = user.Name;
                model.User.Surname = user.Surname;
                model.User.Email = user.Email;

            }
            if (model.Order == null)
                model.Order = new Order();
            if (input.Order != null)
                model.Order = input.Order;
            if(User.Identity.IsAuthenticated)
            {
                model.Order.ClientName = model.Order.ClientName == null || model.Order.ClientName == string.Empty ? model.User.Name : model.Order.ClientName;
                model.Order.ClientSurname = model.Order.ClientSurname == null || model.Order.ClientSurname == string.Empty ? model.User.Surname : model.Order.ClientSurname;
                model.Order.ClientPhone = model.Order.ClientPhone == null || model.Order.ClientPhone == string.Empty ? model.User.Phone : model.Order.ClientPhone;
                model.Order.ClientEmail = model.Order.ClientEmail == null || model.Order.ClientEmail == string.Empty ? model.User.Email : model.Order.ClientEmail;
                model.Order.Address = model.Order.Address == null || model.Order.Address == string.Empty ? model.User.Address : model.Order.Address;
            }

            if (input.Message != null && input.Message != string.Empty)
                model.Message = input.Message;
            model.Title = "Twoje zamówienie";
            return View(model);
        }
    }
}

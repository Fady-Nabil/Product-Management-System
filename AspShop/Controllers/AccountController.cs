using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using System;
using System.Text;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ShopWebApp.Core.Entities;
using ShopWebApp.Core.Interfaces;

namespace ShopWebApp
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var model = new AccountModel("Fady Nabil");
            if (User.Identity.IsAuthenticated)
            {
                var users = await _unitOfWork.Repository<User>().ListAllAsync();
                var user = users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
                model.User.Name = user.Name;
                model.User.Surname = user.Surname;
                model.User.Email = user.Email;

                var data = await _unitOfWork.Repository<Order>().ListAllAsync();
                var orders = data.Where(o => o.UserId == user.UserId).FirstOrDefault();
                ViewBag.orders = orders;
                
            }
            
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(AccountModel model)
        {
            if (model == null)
                model = new AccountModel();

            model.Title = "Fady Nabil";
            if (User.Identity.IsAuthenticated)
            {
                var users = await _unitOfWork.Repository<User>().ListAllAsync();
                var user = users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
                model.User.Name = user.Name;
                model.User.Surname = user.Surname;
                model.User.Email = user.Email;
                model.User.Address = user.Address;
                model.User.Phone = user.Phone;
            }
            return View(model);
        }
        
        [HttpPost]
        [Authorize]
        [ActionName("Edit")]
        public async Task<IActionResult> TryEdit(AccountModel input)
        {
            string currentEmail = User.Identity.Name;
            var currentUser = await _unitOfWork.Repository<User>().GetByIdAsync(input.User.UserId);
            bool needRelog = false, changedPass = false, changedEmail = false;
            if (input.User.Name != null && input.User.Name.Length >= 3 && input.User.Name.Length <= 128)
                currentUser.Name = input.User.Name;
            if (input.User.Surname != null && input.User.Surname.Length >= 3 && input.User.Surname.Length <= 128)
                currentUser.Surname = input.User.Surname;
            if (input.User.Phone != null && input.User.Phone.Length >= 9 && input.User.Phone.Length <= 16)
                currentUser.Phone = input.User.Phone;
            if (input.User.Phone == null || (input.User.Phone.Length >= 9 && input.User.Phone.Length <= 16))
                currentUser.Phone = input.User.Phone == null ? "" :input.User.Phone;
            if (input.User.Address == null || input.User.Address.Length <= 256)
                currentUser.Address = input.User.Address == null ? "" : input.User.Address;
            if (input.User.Email != null && input.User.Email.Contains('@') && input.User.Email.Length < 128)
            {
                currentUser.Email = input.User.Email; needRelog = true;
                changedEmail = true;
            }
            if (input.Password!=null && input.ConfirmPassword != null && input.OldPassword != null && input.Password == input.ConfirmPassword && input.Password.Length >= 8 && input.Password.Length <= 128 && Sha256Hash(input.OldPassword) == currentUser.Password)
            {
                currentUser.Password = Sha256Hash(input.Password);  needRelog = true;
                changedPass = true;
            }
            _unitOfWork.Repository<User>().Update(currentUser);
            if (needRelog)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var claims = new[]
                {
                 new Claim(ClaimTypes.Email, currentUser.Email),
                 new Claim(ClaimTypes.Role, currentUser.Role),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Email, ClaimTypes.Role);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                input.Title = "Edit account";
                if(changedPass && changedEmail)
                    input.Message = "You have successfully changed your email address and password";
                else if (changedEmail)
                    input.Message = "Your email address has been successfully changed";
                else
                    input.Message = "Password changed successfully";
                return View(input);
            }
            return Redirect(Url.Action("index", "account"));
        }

        [HttpGet]
        public IActionResult Login(AccountModel input)
        {
            if (input == null)
                input = new AccountModel();
            input.Title = "Login";
            return View(input);
        }
        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> TryLogin(AccountModel input, [FromQuery] string ReturnUrl)
        {
            input.Title = "Login";
          
                var users = await _unitOfWork.Repository<User>().ListAllAsync();
                var user = users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
                var claims = new[]
                {
                    new Claim("Email", user.Email),
                    new Claim("Role", user.Role),
                };
                bool rememberMe = input.RememberMe;
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Email, ClaimTypes.Role);
                if (rememberMe) {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddMonths(1)
                    }) ;
                }
                else { await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity)); }
                if(ReturnUrl == null)
                    return Redirect(Url.Action("index", "home"));
            return Redirect(ReturnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect(Url.Action("index", "home"));
        } 

        [HttpGet]
        public IActionResult Register(AccountModel input)
        {
            if(User.Identity.IsAuthenticated)
                return Redirect(Url.Action("index", "home"));
            var model = new AccountModel("Zarejestruj się");
            return View(model);
        }
        [HttpPost]
        [ActionName("Register")]
        public async Task<IActionResult> TryRegister(AccountModel input)
        {

                if(input.Password != input.ConfirmPassword)
                {
                    input.Message = "The passwords do not match";
                }
                else
                {
                    if(input.User.Email == null || !input.User.Email.Contains('@')
                        || input.User.Email.Length > 128 || input.User.Name == null 
                        || input.User.Name.Length > 64 || input.User.Surname == null
                        || input.User.Surname.Length > 64 || input.Password == null 
                        || input.Password.Length > 128)
                    {
                        input.Message = "Incorrect data";
                        input.Title = "Register";
                        return View(input);
                    }
                    var user = new User();
                    user.Email = input.User.Email;
                    user.Name = input.User.Name;
                    user.Surname = input.User.Surname;
                    user.Password = Sha256Hash(input.Password);
                    user.Role = "user";
                    if (input.User.Address == null || input.User.Address.Length > 256)
                        user.Address = "";
                    else
                        user.Address = input.User.Address;
                    if (input.User.Phone == null || input.User.Phone.Length > 16 || input.User.Phone.Length < 7)
                        user.Phone = "";
                    else
                        user.Phone = input.User.Phone;
                    await _unitOfWork.Repository<User>().AddAsync(user);
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Email, ClaimTypes.Role);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                    return Redirect(Url.Action("index", "home"));
                }
            
            input.Title = "register";
            return View(input);
        }

     
        private string Sha256Hash(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hashed;
            string hashedString = String.Empty;
            using (SHA256 hasher = SHA256.Create())
            {
                hashed = hasher.ComputeHash(bytes);
            }
            foreach(byte b in hashed)
            {
                hashedString += b.ToString("X");
            }
            return hashedString;
        }
    }
}

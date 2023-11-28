using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

using ShopWebApp.Core.Entities;
using ShopWebApp.Core.Interfaces;
using System.Threading.Tasks;

namespace ShopWebApp.Controllers
{
    public class ShopController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private static int productsPerPage = 30;
        public ShopController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("/shop")]
        public IActionResult Index()
        {
            return Redirect(Url.Action("index", "home"));
        }
        [Route("shop/{categoryId}/")]
        public async Task<IActionResult> Category(int categoryId, [FromQuery] int page = 1, [FromQuery] string sort = "popularity")
        {
            var model = new CategoryModel();
            if (User.Identity.IsAuthenticated)
            {
                var users = await _unitOfWork.Repository<User>().ListAllAsync();
                var user = users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
                model.User.Name = user.Name;
                model.User.Surname = user.Surname;
                model.User.Email = user.Email;
            }
            var category  = await _unitOfWork.Repository<Category>().GetByIdAsync(categoryId);
            if (category == null) return Redirect("/Error/404");
               
                model.Subcategories = category.Subcategories.ToList();
                model.Category = category;
                model.CategoryId = category.CategoryId;

                var productList = new List<Product>();
                foreach (Subcategory subcategory in category.Subcategories)
                {
                    foreach (Product product in subcategory.Products.Where(p => p.Enabled))
                        productList.Add(product);
                }
                switch (sort) {
                    case "name":
                        productList = productList.OrderBy(p => (p.Brand + " " + p.Name)).ToList(); break;
                    case "-name":
                        productList = productList.OrderByDescending(p => (p.Brand + " " + p.Name)).ToList(); break;
                    case "price":
                        productList = productList.OrderBy(p => p.Price).ToList(); break;
                    case "-price":
                        productList = productList.OrderByDescending(p => p.Price).ToList(); break;
                    case "rating":
                        productList = productList.OrderByDescending(p => (p.RatingVotes == 0 ? 0 : (double)p.RatingSum / (double)p.RatingVotes)).ToList(); break;
                    default: productList = productList.OrderByDescending(p => p.RatingVotes).ToList(); break;
                }
                var cutProductList = new List<Product>();
                if (page <= 0 || page > productList.Count / productsPerPage + (productList.Count % productsPerPage != 0 ? 1 : 0) && page != 1)
                    return Redirect("/Error/404");
                for (int i = (page - 1) * productsPerPage; i < Math.Min(page * productsPerPage, productList.Count); i++)
                {
                    cutProductList.Add(productList[i]);
                }
                model.LastPage = productList.Count / productsPerPage;
                if (productList.Count % productsPerPage != 0)
                    model.LastPage++;
                model.Page = page;
                ViewData["sort"] = sort;
                model.Products = cutProductList;
                model.Title = category.Name;


            return View(model);
        }
        [Route("/shop/{subCategoryId}/")]
        public async Task<IActionResult> Subcategory(int subCategoryId, [FromQuery] Dictionary<string, string> filters, [FromQuery] int page = 1, [FromQuery] string sort = "popularity")
        {
            var model = new SubcategoryModel();
            if (User.Identity.IsAuthenticated)
            {
                var users = await _unitOfWork.Repository<User>().ListAllAsync();
                var user = users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
                model.User.Name = user.Name;
                model.User.Surname = user.Surname;
                model.User.Email = user.Email;
            }

            var subcategory = await _unitOfWork.Repository<Subcategory>().GetByIdAsync(subCategoryId);

            if (subcategory == null)
                    return Redirect("/Error/404");
               

                var productList = subcategory.Products.Where(p => p.Enabled).ToList();
                List<Product> newProductList = new List<Product>();
                List<Product> incompatible = new List<Product>();
                List<Product> intIncompatible = new List<Product>();

                Dictionary<string, string> tags = new Dictionary<string, string>();

                Dictionary<string, Dictionary<string, string>> productTags = new Dictionary<string, Dictionary<string, string>>();
                Dictionary<string, Dictionary<string, int>> tagTypes = new Dictionary<string, Dictionary<string, int>>();
                Dictionary<string, bool> isStringFiltered = new Dictionary<string, bool>();
                foreach (Product product in productList)
                {
                    string[] productsTagStrings = product.Tags.Split(';');
                    Dictionary<string, string> oneProductTags = new Dictionary<string, string>();
                    foreach (string tagString in productsTagStrings)
                    {
                        string[] tag = tagString.Split(':');
                        if (tag.Count() >= 2)
                        {
                            oneProductTags.Add(tag[0], tag[1]);
                            if (tagTypes.ContainsKey(tag[0]))
                            {
                                if (tagTypes[tag[0]].ContainsKey(tag[1]))
                                    tagTypes[tag[0]][tag[1]]++;
                                else
                                    tagTypes[tag[0]].Add(tag[1], 1);
                            }
                            else
                            {
                                tagTypes.Add(tag[0], new Dictionary<string, int>() { { tag[1], 1 } });
                            }
                        }
                    }
                    productTags.Add(product.Code, oneProductTags);
                }

                string[] tagsTab = subcategory.Tags.Split(';');
                foreach (string tagString in tagsTab)
                {
                    string[] tag = tagString.Split(':');
                    if (tag.Length >= 2)
                    {
                        tags.Add(tag[0], tag[1]);
                        filters[tag[0]] = filters.ContainsKey(tag[0]) ? filters[tag[0]] : "";
                        if(tag[1] == "int")
                        {
                            filters[tag[0] + "from"] = filters.ContainsKey(tag[0]+ "from") && filters[tag[0]] + "from" != null ? filters[tag[0]+"from"] : "";
                            filters[tag[0] + "to"] = filters.ContainsKey(tag[0] + "to") && filters[tag[0]] + "to" != null ? filters[tag[0] + "to"] : "";
                        }
                        else if(tagTypes.ContainsKey(tag[0]))
                        {
                            isStringFiltered.Add(tag[0], false);
                            foreach(KeyValuePair<string, int> kvp in tagTypes[tag[0]])
                            {
                                filters[tag[0] + ":" + kvp.Key] = filters.ContainsKey(tag[0] + ":" + kvp.Key) && filters[tag[0] + ":" + kvp.Key] != null ? filters[tag[0] + ":" + kvp.Key] : "";
                                if (filters[tag[0] + ":" + kvp.Key] != "")
                                    isStringFiltered[tag[0]] = true;
                            }
                        }
                    }
                }
                double priceFrom = -1, priceTo = -1; bool filtered = false;

                filters["pricefrom"] = filters.ContainsKey("pricefrom") && filters["pricefrom"]!=null ? filters["pricefrom"] : "";
                filters["priceto"] = filters.ContainsKey("priceto") && filters["priceto"] != null ? filters["priceto"] : "";

                // Change ',' to '.' because double format with dot bugs the parse function
                filters["pricefrom"] = filters["pricefrom"].Replace('.', ',');
                filters["priceto"] = filters["priceto"].Replace('.', ',');

                if (filters.ContainsKey("pricefrom")) { double.TryParse(filters["pricefrom"], out priceFrom); };
                if (filters.ContainsKey("priceto")) { double.TryParse(filters["priceto"], out priceTo); };


                if(priceFrom > 0)
                {
                    productList = productList.Where(p => p.Price >= priceFrom*100).ToList();
                }
                if(priceTo > 0)
                {
                    productList = productList.Where(p => p.Price <= priceTo*100).ToList();
                }

                foreach(KeyValuePair<string, string> tag in tags)
                {
                    if(tag.Value == "int")
                    {
                        int from = -1, to = -1;
                        if (filters.ContainsKey(tag.Key + "from")){ int.TryParse(filters[tag.Key + "from"], out from); };
                        if (filters.ContainsKey(tag.Key + "to")) { int.TryParse(filters[tag.Key + "to"], out to); };
                        foreach(Product product in productList)
                        {
                            if (!productTags.ContainsKey(product.Code) || !productTags[product.Code].ContainsKey(tag.Key))
                            {
                                continue;
                            }
                            int value;
                            int.TryParse(productTags[product.Code][tag.Key], out value);
                            if((value >= from || from <= 0) && (value <= to || to <= 0) && (from > 0 || to > 0))
                            {
                                if(!newProductList.Contains(product))
                                    newProductList.Add(product);
                                filtered = true;
                            }
                            else if((from > 0 || to > 0))
                            {
                                if (!intIncompatible.Contains(product))
                                    intIncompatible.Add(product);
                                filtered = true;
                            }
                        }
                    }
                    else
                    {
                        foreach(Product product in productList)
                        {

                            if (!productTags.ContainsKey(product.Code) || !productTags[product.Code].ContainsKey(tag.Key))
                            {
                                if(isStringFiltered[tag.Key])
                                    if (!incompatible.Contains(product))
                                        incompatible.Add(product);
                                continue;
                            }
                            List<Product> compatible = new List<Product>();
                            List<Product> localIncompatible = new List<Product>();
                            foreach(KeyValuePair<string, int> kvp in tagTypes[tag.Key])
                            {
                                string tagName = tag.Key + ":" + kvp.Key;
                                if (filters[tagName] == "true" && productTags[product.Code][tag.Key] == kvp.Key)
                                {
                                    if (newProductList.Where(p => p.Code == product.Code).FirstOrDefault() == null)
                                        newProductList.Add(product);
                                    if (!compatible.Contains(product))
                                        compatible.Add(product);
                                    filtered = true;
                                }
                                else if(filters[tagName] == "true")
                                {
                                    if (!localIncompatible.Contains(product))
                                        localIncompatible.Add(product);
                                }
                            }
                            foreach (Product prod in compatible)
                                localIncompatible.Remove(prod);
                            foreach (Product prod in localIncompatible)
                                if (!incompatible.Contains(prod))
                                    incompatible.Add(prod);
                        }
                    }
                }
                foreach (Product prod in incompatible)
                    newProductList.Remove(prod);
                foreach (Product prod in intIncompatible)
                    if (newProductList.Contains(prod))
                        newProductList.Remove(prod);
                if (filtered)
                    productList = newProductList;
                
                switch (sort)
                {
                    case "name":
                        productList = productList.OrderBy(p => (p.Brand + " " + p.Name)).ToList(); break;
                    case "-name":
                        productList = productList.OrderByDescending(p => (p.Brand + " " + p.Name)).ToList(); break;
                    case "price":
                        productList = productList.OrderBy(p => p.Price).ToList(); break;
                    case "-price":
                        productList = productList.OrderByDescending(p => p.Price).ToList(); break;
                    case "rating":
                        productList = productList.OrderByDescending(p => (p.RatingVotes == 0 ? 0 : (double)p.RatingSum / (double)p.RatingVotes)).ToList(); break;
                    default: productList = productList.OrderByDescending(p => p.RatingVotes).ToList(); break;
                }

                var cutProductList = new List<Product>();
                if (page <= 0 || page > productList.Count / productsPerPage + (productList.Count % productsPerPage != 0 ? 1 : 0) && productList.Count != 0)
                    return Redirect("/Error/404");
                for(int i = (page-1)*productsPerPage; i < Math.Min(page*productsPerPage, productList.Count); i++)
                {
                    cutProductList.Add(productList[i]);
                }

                model.LastPage = productList.Count / productsPerPage;
                if (productList.Count % productsPerPage != 0)
                    model.LastPage++;

                model.Page = page;
                ViewData["sort"] = sort;
                ViewBag.filters = filters;
                ViewBag.tags = tags;
                ViewBag.tagTypes = tagTypes;
                model.Products = cutProductList;
                model.Subcategory = subcategory;
                model.SubcategoryId = subcategory.SubcategoryId;
            
            model.Title = model.Subcategory.Name;
            return View(model);
        }
       
        [Route("/shop/{productId}")]
        public async Task<IActionResult> Product(int productId)
        {
            var model = new BaseViewModel();
            var product = new Product();
            if (User.Identity.IsAuthenticated)
            {
                var users = await _unitOfWork.Repository<User>().ListAllAsync();
                var user = users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
                model.User.Name = user.Name;
                model.User.Surname = user.Surname;
                model.User.Email = user.Email;
            }

            var products = await _unitOfWork.Repository<Product>().GetByIdAsync(productId);


            if (product == null)
                    return Redirect("/Error/404");
            
            ViewBag.Product = product;
            model.Title = product.Brand + " " + product.Name;
            return View(model);
        }

        [Route("/cart")]
        public async Task<IActionResult> Cart()
        {
            var model = new BaseViewModel();
            if (User.Identity.IsAuthenticated)
            {

                var users = await _unitOfWork.Repository<User>().ListAllAsync();
                var user = users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
                model.User.Name = user.Name;
                model.User.Surname = user.Surname;
                model.User.Email = user.Email;


            }

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_Cart")))
            {
                Dictionary<string, int> cartDict = new Dictionary<string, int>();
                HttpContext.Session.SetString("_Cart", JsonSerializer.Serialize(cartDict));
            }
            ViewBag.Cart = JsonSerializer.Deserialize<Dictionary<string, int>>(HttpContext.Session.GetString("_Cart"));
            
            model.Title = "Fady";
            return View(model);
        }

        [HttpGet]
        [Route("/cart/list")]
        public IActionResult GetCartList()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_Cart")))
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                HttpContext.Session.SetString("_Cart", JsonSerializer.Serialize(dict));
            }
            Dictionary<string, int> cartDict = JsonSerializer.Deserialize<Dictionary<string, int>>(HttpContext.Session.GetString("_Cart"));
            ViewBag.Cart = cartDict;
            if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("/Views/Shop/Partial/pv_cartlist.cshtml");
            else
                return Redirect("/Error/404");
        }

        [Route("/search")]
        public async Task<IActionResult> Search([FromQuery] string name = " ", [FromQuery] int page = 1, [FromQuery] string sort = "popularity")
        {
            if (name == null)
                return Redirect("/Error/404");
            var model = new SearchModel();
            model.SearchFor = name;
            if (User.Identity.IsAuthenticated)
            {
                var users = await _unitOfWork.Repository<User>().ListAllAsync();
                var user = users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
                model.User.Name = user.Name;
                model.User.Surname = user.Surname;
                model.User.Email = user.Email;
            }

            var data = await _unitOfWork.Repository<Product>().ListAllAsync();
            var products = data.Where(p => (p.Name.Contains(name) || p.Brand.Contains(name)) && p.Enabled);
     
                products = products.Where(p => p.Enabled).ToList();
                model.Count = products.Count();
                if(products.Count() == 0)
                {
                    ViewData["message"] = "Brak wyników! Polecamy inne produkty dostępne w naszym sklepie";
                    products = products.Where(p => p.Enabled).ToList();
                }
                else if (page <= 0 || page > products.Count() / productsPerPage + (products.Count() % productsPerPage != 0 ? 1 : 0))
                    return Redirect("/Error/404");
                switch (sort)
                {
                    case "name":
                        products = products.OrderBy(p => (p.Brand + " " + p.Name)).ToList(); break;
                    case "-name":
                        products = products.OrderByDescending(p => (p.Brand + " " + p.Name)).ToList(); break;
                    case "price":
                        products = products.OrderBy(p => p.Price).ToList(); break;
                    case "-price":
                        products = products.OrderByDescending(p => p.Price).ToList(); break;
                    case "rating":
                        products = products.OrderByDescending(p => (p.RatingVotes == 0 ? 0 : (double)p.RatingSum / (double)p.RatingVotes)).ToList(); break;
                    default: products = products.OrderByDescending(p => p.RatingVotes).ToList(); break;
                }

                 model.LastPage++;
                model.Page = page;
                ViewData["sort"] = sort;
                model.Products = products.ToList();
            
            model.Title = "Search: " + name;
            return View(model);
        }

    }
}

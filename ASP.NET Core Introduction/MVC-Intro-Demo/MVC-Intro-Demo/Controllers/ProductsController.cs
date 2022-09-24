using Microsoft.AspNetCore.Mvc;
using MVC_Intro_Demo.Models;
using System.Text;
using System.Text.Json;

namespace MVC_Intro_Demo.Controllers
{
    public class ProductsController : Controller
    {
        private IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id=1,
                Name="Cheese",
                Price=7.00
            },
            new ProductViewModel()
            {
                Id=2,
                Name="Ham",
                Price=5.50
            },
            new ProductViewModel()
            {
                Id=3,
                Name="Bread",
                Price=1.50
            },
        };

        /*should only return a view with the products collection*/
        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword!=null)
            {
                var foundProducts = this.products.Where(p => p.Name.ToLower().Contains(keyword.ToLower()));

                return View(foundProducts);

            }
            return View(this.products);
        }
        /*It should pass a product by a given id to the view, if it exists. If it does not, it should return a BadRequest*/
        public IActionResult ById(int id)
        {
            var product=this.products.FirstOrDefault(p => p.Id == id);
            if (product==null)
            {
                return BadRequest();
            }
            return View(product);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return Json(products,options);
        }
        public IActionResult AllAsText()
        {
            StringBuilder text = new StringBuilder();
            foreach (var pr in products)
            {
                text.AppendLine( $"Product {pr.Id}: {pr.Name} - {pr.Price}lv");
                
            }
            
            return Content(text.ToString());
        }

        public void AllAsTextFile()
        {
            //TODO:

        }
    }
}

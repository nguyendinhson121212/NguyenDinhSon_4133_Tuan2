using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenDinhSon_4133_Tuan2.Models;

namespace NguyenDinhSon_4133_Tuan2.Controllers
{

    public class ProductController : Controller
    {
        private readonly IPProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductController(IPProductRepository productRepository,
        ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepository.GetALLCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public IActionResult Update(Product product)
        {
            if(ModelState.IsValid)
            {
                _productRepository.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }  
        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetById(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);  
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _productRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Display(int id)
        {
            var product = _productRepository.GetById(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}


using app6_web.Data;
using app6_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace app6_web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        //index
        public IActionResult Index()
        {
            IEnumerable<Category> CtaegoryList = _db.Categories;
            return View(CtaegoryList);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        //post
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("Name", "مقدار هر دو قیلد نباید یکی باشد");

            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "دسته با موفقیت ایجاد شد";
                return RedirectToAction("Index");
            }
            return View(obj);


        }
        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
            //var categorySingel = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //post
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("Name", "مقدار هر دو قیلد نباید یکی باشد");

            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "دسته با موفقیت  ویرایش شد";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
            //var categorySingel = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {

            var obj = _db.Categories.Find(id);

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "دسته با موفقیت  حذف شد";
            return RedirectToAction("Index");


        }



    }
}

using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = categoryService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            categoryService.TInsert(category);
            return RedirectToAction("Index");
        }

        //id almasının sebebi sadece güncellenecek olanı almak için
        public IActionResult DeleteCategory(int id)
        {
            var values = categoryService.TGetById(id);
            //parametre örtüşmesi için yapılan adım
            categoryService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var values = categoryService.TGetById(id);
            return View(values);
        }

        [HttpPost] // bunları demezsek eğer multiple hatası döner aynı isimde olan methodlardan dolayı
        public IActionResult UpdateCategory(Category category)
        {
            categoryService.TUpdate(category);
            return RedirectToAction("Index");
        }

    }
}

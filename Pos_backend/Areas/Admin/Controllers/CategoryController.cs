using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Pos.DataAccess.Data;
using Pos.DataAccess.Repository;
using Pos.DataAccess.Repository.IRepository;
using Pos.Models;
using Pos.Models.ViewModels;

namespace Pos_backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategoryController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Upsert(int? id)
        {
            CategoryVM categoryVM = new()
            {
                Category = new Category()
                {
                    CategoryCode = string.Empty,
                    DeptCode = string.Empty,
                    NameEN = string.Empty,
                    NameKO = string.Empty
                }
            };

            if (id == null || id == 0)
            {
                return View(categoryVM);
            }
            else
            {
                categoryVM.Category = _unitOfWork.Category.Get(u => u.Id == id);
                return View(categoryVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(CategoryVM categoryVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string categoryPath = Path.Combine(wwwRootPath, @"images\category");

                    // file is not null then updating the image with new
                    if (!string.IsNullOrEmpty(categoryVM.Category.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, categoryVM.Category.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(categoryPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    categoryVM.Category.ImageUrl = @"\images\category\" + fileName;
                }

                if (categoryVM.Category.Id == 0)
                {
                    _unitOfWork.Category.Add(categoryVM.Category);
                }
                else
                {
                    _unitOfWork.Category.Update(categoryVM.Category);
                }

                _unitOfWork.Save();
                TempData["success"] = "Item created successfully";
                return RedirectToAction("Index");

            }
            else
            {
                return View(categoryVM);
            }
        }


        // should seprate into own folder and under api module
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return Json(new { data = objCategoryList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var categoryToBeDelted = _unitOfWork.Category.Get(u => u.Id == id);

            // guard clause
            if (categoryToBeDelted == null)
            {
                return Json(new { success = false, Message = "Eroor while deleting" });
            }
            var oldImagePath =
                Path.Combine(_webHostEnvironment.WebRootPath,
                categoryToBeDelted.ImageUrl.TrimStart('\\'));

            // delete image from folder
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Category.Remove(categoryToBeDelted);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete Sucessful" });
        }
        #endregion
    }
}

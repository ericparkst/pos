using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pos.DataAccess.Data;
using Pos.DataAccess.Repository;
using Pos.DataAccess.Repository.IRepository;
using Pos.Models;
using Pos.Models.ViewModels;
using Pos.Utility;

namespace Pos_backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ItemController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Item> objItemList = _unitOfWork.Item.GetAll(includeProperties: "Category").ToList();
            
            return View(objItemList);
        }

        public IActionResult Upsert(int? id)
        {
            ItemVM itemVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.NameEN,
                    Value = u.CategoryCode
                }),
                Item = new Item()
            };

            if(id == null || id == 0)
            {
                // create
                return View(itemVM);
            }
            else
            {
                // update
                itemVM.Item = _unitOfWork.Item.Get(u => u.Id == id);
                return View(itemVM);
            }
        }

        // Add logic to prevent duplicate
        [HttpPost]
        public IActionResult Upsert(ItemVM itemVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    // file is not null then updating the image with new
                    if(!string.IsNullOrEmpty(itemVM.Item.ImageUrl)) 
                    { 
                        // delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, itemVM.Item.ImageUrl.TrimStart('\\'));

                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using(var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    itemVM.Item.ImageUrl = @"\images\product\" + fileName;
                }

                if(itemVM.Item.Id == 0)
                {
                    _unitOfWork.Item.Add(itemVM.Item);
                }
                else
                {
                    _unitOfWork.Item.Update(itemVM.Item);
                }

                _unitOfWork.Save();
                TempData["success"] = "Item created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                itemVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.NameEN,
                    Value = u.CategoryCode
                });
                return View(itemVM);
            } 
        }

        // should seprate into own folder and under api module
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Item> objItemList = _unitOfWork.Item.GetAll(includeProperties: "Category").ToList();
            return Json(new {data = objItemList});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var itemToBeDeleted = _unitOfWork.Item.Get(u => u.Id == id);
            if (itemToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath = 
                Path.Combine(_webHostEnvironment.WebRootPath, 
                itemToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Item.Remove(itemToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}

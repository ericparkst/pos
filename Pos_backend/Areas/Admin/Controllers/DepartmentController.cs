using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Pos.DataAccess.Data;
using Pos.DataAccess.Repository.IRepository;
using Pos.Models;
using Pos.Models.ViewModels;

namespace Pos_backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DepartmentController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Department> departmentList = _unitOfWork.Department.GetAll().ToList();
            return View(departmentList);
        }

        public IActionResult Upsert(int? id)
        {
            DepartmentVM departmentVM = new()
            {
                Department = new Department()
                {
                    DeptCode = string.Empty,
                    NameEN = string.Empty,
                    NameKO = string.Empty
                }
            };

            if(id == null || id == 0)
            {
                return View(departmentVM);
            }
            else
            {
                departmentVM.Department = _unitOfWork.Department.Get(u => u.Id == id);
                return View(departmentVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(DepartmentVM departmentVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string departmentPath = Path.Combine(wwwRootPath, @"images\department");

                    // file is not null then updating the image with new
                    if (!string.IsNullOrEmpty(departmentVM.Department.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, departmentVM.Department.ImageUrl.TrimStart('\\'));

                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }       
                    }

                    using (var fileStream = new FileStream(Path.Combine(departmentPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    departmentVM.Department.ImageUrl = @"\images\department\" + fileName;
                }

                if (departmentVM.Department.Id == 0)
                {
                    _unitOfWork.Department.Add(departmentVM.Department);
                }
                else
                {
                    _unitOfWork.Department.Update(departmentVM.Department);
                }

                _unitOfWork.Save();
                TempData["success"] = "Item created successfully";
                return RedirectToAction("Index");

            }
            else
            {
                return View(departmentVM);
            }
        }

        // should seprate into own folder and under api module
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Department> objDepartmentList = _unitOfWork.Department.GetAll().ToList();
            return Json(new {data =  objDepartmentList});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var departmentToBeDelted = _unitOfWork.Department.Get(u => u.Id == id);

            // guard clause
            if(departmentToBeDelted == null)
            {
                return Json(new { success = false, Message = "Eroor while deleting" });
            }
            var oldImagePath =
                Path.Combine(_webHostEnvironment.WebRootPath,
                departmentToBeDelted.ImageUrl.TrimStart('\\'));

            // delete image from folder
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Department.Remove(departmentToBeDelted);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete Sucessful" });
        }
        #endregion
    }
}

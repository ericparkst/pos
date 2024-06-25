using Microsoft.AspNetCore.Mvc;
using Pos.DataAccess.Repository.IRepository;
using Pos.Models;
using Pos_backend.Services;
using System.Diagnostics;
using System.Text;

namespace Pos_backend.Areas.Customer.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        // Servies
        private readonly IScopedGuidService _scoped1;
        private readonly IScopedGuidService _scoped2;

        private readonly ISingletonGuidService _singleton1;
        private readonly ISingletonGuidService _singleton2;

        private readonly ITransientGuidService _transient1;
        private readonly ITransientGuidService _transient2;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork,
            IScopedGuidService scoped1,
            IScopedGuidService scoped2,
            ISingletonGuidService singleton1,
            ISingletonGuidService singleton2,
            ITransientGuidService transient1,
            ITransientGuidService transient2)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singleton1 = singleton1;
            _singleton2 = singleton2;
            _transient1 = transient1;
            _transient2 = transient2;
        }

        public IActionResult Index()
        {
            IEnumerable<Department> departmentList = _unitOfWork.Department.GetAll().OrderBy(d => d.DeptCode);

            return View(departmentList);
        }
        
        public IActionResult DeptCategories(string? deptCode)
        {
            
            var allCategories = _unitOfWork.Category.GetAll().ToList();
            IEnumerable<Category> categoryList;

            
            if(deptCode == null)
            {
                return View(allCategories);
            }
            else
            {
                categoryList = allCategories.Where(i => i.DeptCode.Trim().ToLower() == deptCode.Trim().ToLower()).ToList();

                if (categoryList == null || !categoryList.Any())
                {
                    return NotFound("No categories found for the given DeptCode."); // send error message to view
                }
            }

            return View(categoryList);
        }

        public IActionResult CategoryItems(string? categoryCode)
        {
            var allItems = _unitOfWork.Item.GetAll().ToList();
            IEnumerable<Item> itemList;

            if (categoryCode == null)
            {
                return View(allItems);
            }

            itemList = allItems.Where(i => i.CategoryCode.Trim().Equals(categoryCode.Trim(), StringComparison.CurrentCultureIgnoreCase)).ToList();
            return View(itemList);
        }

        public IActionResult Details(int itemId)
        {
            Item item = _unitOfWork.Item.Get(u => u.Id == itemId, includeProperties: "Category");
            return View(item);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

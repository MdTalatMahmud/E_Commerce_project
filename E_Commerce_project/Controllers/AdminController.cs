using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce_project.DAL;
using E_Commerce_project.Models;
using E_Commerce_project.Repository;
using Newtonsoft.Json;

namespace E_Commerce_project.Controllers
{
    public class AdminController : Controller
    {
        public GenericUnitOfWork _unitOfWork=new GenericUnitOfWork();
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Categories()
        {
            List<Tbl_Category> allcategories = _unitOfWork.GetRepositoryInstance<Tbl_Category>()
                .GetAllRecordsIQueryable().Where(i => i.IsDelete == false).ToList();
            return View(allcategories);
        }

        public ActionResult AddCategory()
        {
            return UpdateCategory(0);
        }

        public ActionResult UpdateCategory(int categoryId)
        {
            CategoryDetail cd;
            if (categoryId!=null)
            {
                cd = JsonConvert.DeserializeObject<CategoryDetail>(
                    JsonConvert.SerializeObject(_unitOfWork.GetRepositoryInstance<Tbl_Category>()
                        .GetFirstorDefault(categoryId)));
            }
            else
            {
                cd=new CategoryDetail();
            }

            return View("UpdateCategory", cd);
        }

        public ActionResult Product()
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Product>().GetProduct());
        }

        public ActionResult EditProduct(int productId)
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Product>().GetFirstorDefault(productId));
        }
    }
}
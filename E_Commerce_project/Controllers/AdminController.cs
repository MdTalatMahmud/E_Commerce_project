using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce_project.DAL;
using E_Commerce_project.Repository;

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
    }
}
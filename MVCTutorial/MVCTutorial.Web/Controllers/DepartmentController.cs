using MVCTutorial.Web.Models;
using MVCTutorial.Web.ProjectDbContext;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MVCTutorial.Web.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department List View
        public ActionResult Index()
        {
            using (var dbContext = new MyDbContext())
            {
                // 在List View不显示员工信息，所以我们不使用Include("Employees")
                var departments = dbContext.Departments.ToList();
                return View(departments);
            }
        }

        // GET: Department Detail View
        public ActionResult Details(int id)
        {
            using (var dbContext = new MyDbContext())
            {
                // 根据传入的departmentId, 查找一个特定的department，包含它的Employees，建立一个ViewModel
                // 给你departmentId, 帮我寻找第一个满足条件的department记录
                var department = dbContext.Departments
                                           .Include("Employees")
                                           .FirstOrDefault(dept => dept.Id == id);
                
                return View(department);
            }
        }

        // GET 生成Create的页面
        public ActionResult Create()
        {
            return View();
        }

        // POST 实际接受表单传递过来的数据
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            // 检查传入的department对象是否符合要求
            if (!ModelState.IsValid)
            {
                // 如果不符合，则带着错误信息，返回到Edit View
                return View(department);
            }

            using (var dbContext = new MyDbContext())
            {
                // 将新的记录加入到之前已有的记录当中去
                dbContext.Departments.Add(department);

                // 保存到
                dbContext.SaveChanges();

                // 告诉Entity Framework 将新纪录存入数据库
                return RedirectToAction("Index");
            }
        }

        // GET Edit View
        public ActionResult Edit(int id)
        {
            using (var dbContext = new MyDbContext())
            {
                // 根据传入的departmentId, 查找一个特定的department，包含它的Employees，建立一个ViewModel
                // 给你departmentId, 帮我寻找第一个满足条件的department记录
                var department = dbContext.Departments
                                           .Include("Employees")
                                           .FirstOrDefault(dept => dept.Id == id);

                return View(department);
            }
        }

        // 实现增删改查的“改”
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            // 检查传入的department对象是否符合要求
            if (!ModelState.IsValid)
            {
                // 如果不符合，则带着错误信息，返回到Edit View
                return View(department);
            }

            using (var dbContext = new MyDbContext())
            {
                // 根据传入的departmentId, 查找一个特定的department，包含它的Employees，建立一个ViewModel
                // 给你departmentId, 帮我寻找第一个满足条件的department记录
                var departmentInDb = dbContext.Departments
                                           .Include("Employees")
                                           .FirstOrDefault(dept => dept.Id == department.Id);

                // 如果在数据库中找到了对应的记录，则进行下面的操作，即将传入的新的department数据，赋值给数据库中对应的记录
                if (departmentInDb != null)
                {
                    departmentInDb.DepartmentName = department.DepartmentName;
                    departmentInDb.Location = department.Location;
                    departmentInDb.DepartmentHead = department.DepartmentHead;
                    // 告诉Entity Framework 将新纪录存入数据库
                    dbContext.SaveChanges();
                }
                // 返回到Details View
                return RedirectToAction("Index");
            }
        }

        // 实现增删改查的“删”
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id = 0)
        {
            // 检查传入的department对象是否符合要求
            if (id == 0)
            {
                throw new Exception("Invalid request");
            }

            using (var dbContext = new MyDbContext())
            {
                var departmentInDb = dbContext.Departments
                                           .Include("Employees")
                                           .FirstOrDefault(dept => dept.Id == id);

                // 如果在数据库中找到了对应的记录，则进行下面的操作，即将传入的新的department数据，赋值给数据库中对应的记录
                if (departmentInDb != null)
                {
                    dbContext.Departments.Remove(departmentInDb);
                    // 告诉Entity Framework 将新纪录存入数据库
                    dbContext.SaveChanges();
                }
                // 返回到Details View
                return RedirectToAction("Index");
            }
        }

        #region 演示不同的modelBinding的方法

        //// 实现增删改查的“改”
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(FormCollection department)
        //{
        //    using (var dbContext = new MyDbContext())
        //    {
        //        // 根据传入的departmentId, 查找一个特定的department，包含它的Employees，建立一个ViewModel
        //        // 给你departmentId, 帮我寻找第一个满足条件的department记录
        //        var departmentId = int.Parse(department["Id"]);
        //        var departmentInDb = dbContext.Departments
        //                                   .Include("Employees")
        //                                   .FirstOrDefault(dept => dept.Id == departmentId);

        //        // 如果在数据库中找到了对应的记录，则进行下面的操作，即将传入的新的department数据，赋值给数据库中对应的记录
        //        if (departmentInDb != null)
        //        {
        //            departmentInDb.DepartmentName = department["DepartmentName"];
        //            departmentInDb.Location = department["Location"];
        //            departmentInDb.DepartmentHead = department["DepartmentHead"];
        //            // 告诉Entity Framework 将新纪录存入数据库
        //            dbContext.SaveChanges();
        //        }
        //        // 返回到Details View
        //        return RedirectToAction("Index");
        //    }
        //}
        #endregion
    }
}
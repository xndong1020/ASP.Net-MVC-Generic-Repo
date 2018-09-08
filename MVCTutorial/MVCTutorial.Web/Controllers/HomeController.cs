using MVCTutorial.Web.Models;
using MVCTutorial.Web.ProjectDbContext;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCTutorial.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // 获得routeData当中的值
            RouteData routeData = this.RouteData;

            // 获得queryString参数集
            var queryStrs = this.Request.QueryString;
            var name = queryStrs["name"];
            var age = queryStrs["age"];

            // 获得浏览器cookie
            var cookies = this.Request.Cookies;
            var myCookie = cookies["csrftoken"];

            // 将这些信息存入用户的session
            this.Session["name"] = name;
            this.Session["age"] = age;

            this.Session["csrftoken"] = myCookie.Value;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            // 从用户session 当中取出信息
            var name = this.Session["name"];
            var age = this.Session["age"];

            TempData["className"] = "Full Stack .Net";

            return RedirectToAction("MyList");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET /Home/MyList
        public ViewResult MyList()
        {
            var students = new List<string>() { "Han meimei", "Li Lei", "Lei Feng", "Qiang Dong" };

            // 使用ViewData来向View传递数据
            ViewData["subjects"] = new List<string> { "MVC", "WebApi", "React.js" };

            // 使用ViewBag来向View传递数据
            ViewBag.Titles = new List<string>() { "CEO", "Architect", "CTO" };

            return View(students);
        }

        // GET /Home/MyClass
        public ViewResult MyClass()
        {
            var students = new List<Student>()
            {
                new Student() {  Id = 1,  Name = "Joseph", Subject = ".Net full stack" },
                new Student() {  Id = 2,  Name = "Yang Yang", Subject = "Frontend" },
                new Student() {  Id = 3,  Name = "Hao", Subject = ".Net Backend" }
            };

            var Teacher = new List<Teacher>()
            {
                new Teacher() { Id = 1001, Name = "Jermey Gu", Students = students },
                new Teacher() { Id = 1002, Name = "Henry Zhang", Students = students }
            };

            return View(Teacher);
        }

        public ViewResult Company()
        {
            // 新建一个departments的类型的对象
            var dbContext = new MyDbContext();

            // 将departmens的资料读进来
            var departments = dbContext.Departments.Include("Employees").ToList();

            // 使用这个departments list作为viewModel
            return View(departments);
        }
    }
}
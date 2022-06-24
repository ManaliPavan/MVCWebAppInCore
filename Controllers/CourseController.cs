
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Controllers
{
    public class CourseController : Controller
    {
        CourseDAL context = new CourseDAL();
        public IActionResult List()
        {
            ViewBag.CourseList = context.GetAllCourses();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection form)
        {
            Course c = new Course();
            c.Cname = form["cname"];
            c.Fees = Convert.ToDecimal(form["fees"]);
            int res = context.Save(c);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }

        [HttpGet]

        public IActionResult Edit(int cid)
        {
            Course course = context.GetCourseById(cid);
            ViewBag.Cname = course.Cname;
            ViewBag.Fees = course.Fees;
            ViewBag.Cid = course.Cid;
            return View();
        }

        [HttpPost]

        public IActionResult Edit(IFormCollection form)
        {
            Course course = new Course();
            course.Cname = form["cname"];
            course.Fees = Convert.ToDecimal(form["fees"]);
            course.Cid = Convert.ToInt32(form["cid"]);
            int res = context.Update(course);
            if (res == 1)
                return RedirectToAction("List");
            return View();

        }

        [HttpGet]

        public IActionResult Delete(int cid)
        {
            Course course = context.GetCourseById(cid);
            ViewBag.Cname = course.Cname;
            ViewBag.Fees = course.Fees;
            ViewBag.Cid = course.Cid;
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]

        public IActionResult DeleteConfirm(int cid)
        {
            int res = context.Delete(cid);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }




    }
}

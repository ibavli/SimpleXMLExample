using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using XMLExample.Models;

namespace XMLExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            XmlDocument doc = new XmlDocument();
            List<StudentModel> students = new List<StudentModel>();
            //doc.Load(Server.MapPath("~/Files/Students.xml"));
            doc.Load(Server.MapPath("~/Files/StudentsEx.xml"));
            foreach (XmlNode node in doc.SelectNodes("/students/student"))
            {
                students.Add(new StudentModel
                {
                    Name = node["name"].InnerText,
                    Surname = node["surname"].InnerText,
                    Age = Convert.ToInt32(node["age"].InnerText)
                });
            }
            return View(students);
        }
    }
}
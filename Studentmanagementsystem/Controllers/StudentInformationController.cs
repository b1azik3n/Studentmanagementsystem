using Microsoft.AspNetCore.Mvc;
using Studentmanagementsystem.Data;
using Studentmanagementsystem.Models;
using Studentmanagementsystem.Models.Domain;

namespace Studentmanagementsystem.Controllers
{
    public class StudentInformationController : Controller
    {
        private readonly DbStudentContext dbstudentcontext;

        public StudentInformationController(DbStudentContext dbstudentcontext)
        {
            this.dbstudentcontext = dbstudentcontext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            {
                var students = dbstudentcontext.Students.ToList();
                return View(students);

            }
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddStudentModel addStudentRequest)
        {
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Name = addStudentRequest.Name,
                Email = addStudentRequest.Email,
                Percentage = addStudentRequest.Percentage,
                DateOfBirth = addStudentRequest.DateOfBirth,
                Department = addStudentRequest.Department,
            };
            dbstudentcontext.Students.Add(student);
            dbstudentcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult View(Guid id)
        {
            {
                var student = dbstudentcontext.Students.FirstOrDefault(e => e.Id == id);
                if (student != null)
                {
                    var viewmodel = new StudentUpdateModel()
                    {
                        Id = student.Id,
                        Name = student.Name,
                        Email = student.Email,
                        Percentage = student.Percentage,
                        DateOfBirth = student.DateOfBirth,
                        Department = student.Department,
                    };
                    return View("View", viewmodel);
                }
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult View(StudentUpdateModel model)
        {
            var student = dbstudentcontext.Students.Find(model.Id);
            if (student != null)
            {
                student.Name = model.Name;
                student.Email = model.Email;
                student.Percentage = model.Percentage;
                student.DateOfBirth = model.DateOfBirth;
                student.Department = model.Department;

                dbstudentcontext.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Delete(StudentUpdateModel model)
        {
            var student = dbstudentcontext.Students.Find(model.Id);
            if (student != null)
            {
                dbstudentcontext.Students.Remove(student);
                dbstudentcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}  


using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryPattern.Models;
using RepositoryPattern.ViewModels;

namespace RepositoryPattern.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentrepository _studentrepository;
        public StudentController(IStudentrepository studentrepository)
        {
            _studentrepository = studentrepository;
        }
        public IActionResult Index()
        {
          var Model=  _studentrepository.GetAllStudents();
            return View(Model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentCreateViewModel models)
        {
            if(ModelState.IsValid)
            {
                Student obj = new Student
                {
                    Firstname=models.Firstname,
                    Lastname=models.Lastname,
                    Email=models.Email,
                    Age=models.Age,
                    CountryName=models.CountryName,
                    StateName=models.StateName,
                    CityName=models.CityName
                };
                _studentrepository.Add(obj);
                return RedirectToAction("Index","Student");
            }
            return View("Create");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
           Student student= _studentrepository.GetStudent(id);
            StudentEditViewModel obj = new StudentEditViewModel
            {
                Id=student.Id,
                Firstname=student.Firstname,
                Lastname=student.Lastname,
                Email=student.Email,
                Age=student.Age,
                CountryName=student.CountryName,
                StateName=student.StateName,
                CityName=student.CityName
            };
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(StudentEditViewModel models)
        {
            if(ModelState.IsValid)
            {
                Student student = _studentrepository.GetStudent(models.Id);
                student.Firstname = models.Firstname;
                student.Lastname = models.Lastname;
                student.Email = models.Email;
                student.Age = models.Age;
                student.CountryName = models.CountryName;
                student.StateName = models.StateName;
                student.CityName = models.CityName;
                _studentrepository.Update(student);
                return RedirectToAction("Index");
            } 
            return View("Edit");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var  student = _studentrepository.GetStudent(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            _studentrepository.Delete(student);
            return RedirectToAction("Index");
        }
    }
}

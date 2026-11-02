using librarymanagementapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace librarymanagementapp.Controllers
{
    public class StudentController : Controller
    {
        private static List<StudentModel> students = new List<StudentModel>();

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                int newId = 1;
                foreach (var s in students)
                {
                    if (s.Id >= newId)
                    {
                        newId = s.Id + 1;
                    }
                }
                student.Id = newId;
                students.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            foreach (var student in students)
            {
                if (student.Id == id)
                {
                    return View(student);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(StudentModel updatedStudent)
        {
            if (ModelState.IsValid)
            {
                foreach (var student in students)
                {
                    if (student.Id == updatedStudent.Id)
                    {
                        student.Name = updatedStudent.Name;
                        student.Email = updatedStudent.Email;
                        student.Phone = updatedStudent.Phone;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(updatedStudent);
        }
    }
}
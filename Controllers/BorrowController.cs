using librarymanagementapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace librarymanagementapp.Controllers
{
    public class BorrowController : Controller
    {
        private static List<BorrowModel> borrows = new List<BorrowModel>();

        public IActionResult Index()
        {
            return View(borrows);
        }

        public IActionResult Create()
        {
            ViewBag.Students = StudentController.students;
            ViewBag.Books = BookController.books;

            BorrowModel borrow = new BorrowModel();
            borrow.BorrowDate = DateTime.Today;
            return View(borrow);
        }

        [HttpPost]
        public IActionResult Create(BorrowModel borrow)
        {
            foreach (var b in borrows)
            {
                if (b.BookId == borrow.BookId && b.ReturnDate == null)
                {
                    ModelState.AddModelError("BookId", "This book is already borrowed and has not been returned.");
                }
            }

            if (borrow.BorrowDate > DateTime.Today)
            {
                ModelState.AddModelError("BorrowDate", "Borrow date cannot be in the future.");
            }

            if (ModelState.IsValid)
            {
                foreach (var student in StudentController.students)
                {
                    if (student.Id == borrow.StudentId)
                    {
                        borrow.Student = student;
                    }
                }

                foreach (var book in BookController.books)
                {
                    if (book.Id == borrow.BookId)
                    {
                        borrow.Book = book;
                    }
                }

                int newId = 1;
                foreach (var b in borrows)
                {
                    if (b.Id >= newId)
                    {
                        newId = b.Id + 1;
                    }
                }
                borrow.Id = newId;
                borrows.Add(borrow);
                return RedirectToAction("Index");
            }

            ViewBag.Students = StudentController.students;
            ViewBag.Books = BookController.books;
            return View(borrow);
        }

        [HttpPost]
        public IActionResult Return(int id)
        {
            foreach (var borrow in borrows)
            {
                if (borrow.Id == id && borrow.ReturnDate == null)
                {
                    borrow.ReturnDate = DateTime.Today;
                }
            }
            return RedirectToAction("Index");
        }
    }
}
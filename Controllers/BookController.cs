using librarymanagementapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace librarymanagementapp.Controllers
{
    public class BookController : Controller
    {
        private static List<BookModel> books = new List<BookModel>()
        {
            new BookModel { Id = 1, Title = "1984", Author = "George Orwell", Year = 1949 },
            new BookModel { Id = 2, Title = "The Hobbit", Author = "J.R.R. Tolkien", Year = 1937 }
        };

        public IActionResult Index()
        {
            return View(books);
        }

        public IActionResult Details(int id)
        {
            foreach (var book in books)
            {
                if (book.Id == id)
                {
                    return View(book);
                }
            }
            return NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookModel book)
        {
            if (ModelState.IsValid)
            {
                int newId = 1;
                foreach (var b in books)
                {
                    if (b.Id >= newId)
                    {
                        newId = b.Id + 1;
                    }
                }
                book.Id = newId;
                books.Add(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Edit(int id)
        {
            foreach (var book in books)
            {
                if (book.Id == id)
                {
                    return View(book);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(BookModel updatedBook)
        {
            if (ModelState.IsValid)
            {
                foreach (var book in books)
                {
                    if (book.Id == updatedBook.Id)
                    {
                        book.Title = updatedBook.Title;
                        book.Author = updatedBook.Author;
                        book.Year = updatedBook.Year;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(updatedBook);
        }

        public IActionResult Delete(int id)
        {
            foreach (var book in books)
            {
                if (book.Id == id)
                {
                    return View(book);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            BookModel bookToDelete = null;

            foreach (var book in books)
            {
                if (book.Id == id)
                {
                    bookToDelete = book;
                }
            }

            if (bookToDelete != null)
            {
                books.Remove(bookToDelete);
            }

            return RedirectToAction("Index");
        }
    }
}
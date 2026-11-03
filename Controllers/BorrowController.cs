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
    }
}
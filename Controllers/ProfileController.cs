using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;

namespace BookCave.Controllers
{
    public class ProfileController : Controller
    {
        private ProfileService _profileService;

        public ProfileController()
        {
            _profileService = new ProfileService();
        }

        public IActionResult Index(int Id)
        {
            return View();
        }
        public IActionResult PaymentInformation(int Id)
        {
            return View();
        }
        public IActionResult WishList(int Id)
        {
            var MyWishList = _profileService.GetMyWishList(Id);
            return View(MyWishList);
        }
        public IActionResult OrderHistory(int Id)
        {
            return View();
        }
        public IActionResult AddressBook(int Id)
        {
            return View();
        }
        public IActionResult Edit(int Id)
        {
            return View();
        }
    }
}

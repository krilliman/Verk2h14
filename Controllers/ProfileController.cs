using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using BookCave.Models.ViewModels;

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
            var MyPaymentList = _profileService.GetMyPaymentList(Id);
            foreach (var item in MyPaymentList.Addresses)
            {
                Console.WriteLine(item.CardHolder);
            }
            
            return View(MyPaymentList);
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

        public IActionResult AddPayment(PaymentListViewModel Model)
        {
            var UserId = _profileService.AddPayment(Model);
            return RedirectToAction("PaymentInformation", "Profile", new {Id = UserId});
        }
        public IActionResult DeletePayment(int PaymentId, int UserId)
        {
            _profileService.DeletePayment(PaymentId);
            return RedirectToAction("PaymentInformation", "Profile", new {Id = UserId});
        }
       
    }
}

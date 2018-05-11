using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using BookCave.Models.ViewModels;
using BookCave.Models.InputModels;


namespace BookCave.Controllers
{
    public class ProfileController : Controller
    {
        private ProfileService _profileService;
        private IPaymentService _paymentSerivce;
        public ProfileController(IPaymentService Payment)
        {
            _paymentSerivce = Payment;
            _profileService = new ProfileService();
        }
        public IActionResult AddressBook(int Id)
        {
            var MyAddressBook = _profileService.GetMyAddressBook(Id);
            return View(MyAddressBook);
        }
        public IActionResult DeleteAddress(int AddressId, int UserId)
        {
            _profileService.DeleteAddress(AddressId);
            return RedirectToAction("AddressBook", "Profile", new {Id = UserId});
        }

        [HttpPost]
        public IActionResult AddressBook(AddressListViewModel Model)
        {
            if(!ModelState.IsValid)
            {
                ViewData["ErrorMessage"] = "Error";
                return View();
            }
            var UserId = _profileService.AddAddress(Model);
            return RedirectToAction("AddressBook", "Profile", new {Id = UserId});
        }

        public IActionResult Index(int Id)
        {
            var UserInformation = _profileService.GetInformation(Id);
            return View(UserInformation);
        }
        public IActionResult PaymentInformation(int Id)
        {
            var MyPaymentList = _profileService.GetMyPaymentList(Id);
            
            return View(MyPaymentList);
        }
        public IActionResult WishList(int Id)
        {
            var MyWishList = _profileService.GetMyWishList(Id);
            return View(MyWishList);
        }
        public IActionResult OrderHistory(int Id)
        {
            var Orders = _profileService.GetAllOrders(Id);
            return View(Orders);
        }
        public IActionResult Edit(int Id)
        {
            var UserInformation = _profileService.GetInformation(Id);
            return View(UserInformation);
        }
        public IActionResult SaveEdit(UserViewModel Model)
        {
            _profileService.EditUserInformation(Model);

            return RedirectToAction("Index","Profile", new {Id = Model.Id});
        }
       
         
        public IActionResult DeletePayment(int PaymentId, int UserId)
        {
            _profileService.DeletePayment(PaymentId);
            return RedirectToAction("PaymentInformation", "Profile", new {Id = UserId});
        }
        [HttpPost]
        public IActionResult PaymentInformation(PaymentListViewModel Model)
        {
            if(!ModelState.IsValid)
            {
                ViewData["ErrorMessage"] = "Error";
                return View();
            }

            try{
                _paymentSerivce.ProccessPayment(Model.NewPayment);
            }
            catch(Exception e){
                Console.WriteLine("Error: " + e);
            }
            
            var UserId = _profileService.AddPayment(Model);
            return RedirectToAction("PaymentInformation", "Profile", new {Id = UserId});
        }
    }
}

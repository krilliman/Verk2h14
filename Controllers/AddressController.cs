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
    public class AddressController : Controller
    {
        private AddressService _addressService;
        private IAddressService _iAddressSerivce;

        public AddressController(IAddressService AddressService)
        {
            _iAddressSerivce = AddressService;
            _addressService = new AddressService();
        }
        /*

        public IActionResult Index(int Id)
        {
            var MyAddressBook = _addressService.GetMyAddressBook(Id);
            return View(MyAddressBook);
        }
        public IActionResult DeleteAddress(int AddressId, int UserId)
        {
            _addressService.DeleteAddress(AddressId);
            return RedirectToAction("AddressBook", "Profile", new {Id = UserId});
        }
        [HttpPost]
        public IActionResult Index(AddressListViewModel Model)
        {
            if(!ModelState.IsValid)
            {
                ViewData["ErrorMessage"] = "Error";
                return View();
            }
            _iAddressSerivce.ProccessAddress(Model.NewAddress);
            var UserId = _addressService.AddAddress(Model);
            return RedirectToAction("AddressBook", "Profile", new {Id = Model.NewAddress.UserId});
        }
        */
    }
}

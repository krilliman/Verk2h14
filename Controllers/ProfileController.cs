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

        public IActionResult Index(string id)
        {
            return View();
        }
    }
}

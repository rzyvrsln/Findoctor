﻿using FindoctorEntity.Entities;
using FindoctorViewModel.Entities.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FindoctorWeb.Controllers
{
    public class AccountController : Controller
    {
        UserManager<User> _userManager;
        SignInManager<User> _signInManager;
        RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> AccessDenied() => View(nameof(UserLogin));

        [HttpGet]
        public async Task<IActionResult> Login() => View(nameof(UserLogin));

        [HttpGet]
        public async Task<IActionResult> UserOrDoctorLogIn() => View();

        [HttpGet]
        public async Task<IActionResult> UserOrDoctor() => View();

        [HttpGet]
        public async Task<ActionResult> UserRegister() => View();

        [HttpPost]
        public async Task<IActionResult> UserRegister(CreateUserRegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();
            User AppUser = await _userManager.FindByNameAsync(registerVM.Email);
            if (AppUser != null) { ModelState.AddModelError("Email", "Bu email artıq mövcuddur."); return View(); }

            User appUser = new User
            {
                Email = registerVM.Email,
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.UserName,
                Phone = registerVM.Phone
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            //await _userManager.AddToRoleAsync(appUser, "Admin");
            await _signInManager.SignInAsync(appUser, true);
            return RedirectToAction(nameof(UserLogin), "Account");
        }

        [HttpGet]
        public async Task<IActionResult> UserLogin() =>  View();

        [HttpPost]
        public async Task<IActionResult> UserLogin(CreateUserLoginVM loginVM)
        {
            if (!ModelState.IsValid) return View();
            var user = await _userManager.FindByNameAsync(loginVM.UserName);
            if (user is null) { ModelState.AddModelError("UserName", "Bele bir istifadəçi yoxdur."); return View(); }

            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.IsParsistance, true);
            if (!result.Succeeded) { ModelState.AddModelError("UserName", "Bele bir istifadəçi yoxdur."); return View(); }

            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }


        [HttpGet]
        public ActionResult DoctorRegister() => View();

        //[HttpGet]
        //public async Task<IActionResult> AddRole()
        //{
        //    await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    return View();
        //}


    }
}

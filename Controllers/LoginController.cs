using KBS_Proje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace KBS_Proje.Controllers
{
    public class LoginController : Controller
    {

        public LoginController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> LogUserIn([FromForm]string username, [FromForm]string password){
            if(username == "KBSkalite" && password == "KBSkalite"){
               List<Claim> claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, username)
                };
                ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");

                // create principal  
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("CookieSchema", principal);
                return "ok";
             }
             else{
                return "notok";
             }

            // foreach (var item in userScreenDTO.Screens)
            //     claims.Add(new Claim(ClaimTypes.Role, item));
            
            // create identity  
        
        }
        public async Task<IActionResult>  Logout(){
            await HttpContext.SignOutAsync("CookieSchema");
            return RedirectToAction("Index");
        }

        [Authorize]
        public string AccessDenied() {
            return "Bu sayfaya yetkiniz bulunmuyor.";
        }
    }
}

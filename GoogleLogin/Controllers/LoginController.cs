using GoogleLogin.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Google.Apis.YouTube.v3;

namespace GoogleLogin.Controllers
{
    public class LoginController : Controller
    {
        YouTubeApiClient _youTubeApiClient;
        public LoginController(YouTubeApiClient youTubeApiClient)
        {
            _youTubeApiClient = youTubeApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task Login()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
        }
        public async Task<IActionResult> GoogleResponse()
        {

            
            if (true)
            {
                TempData["sub"] = "true";
                return RedirectToAction("Index", "Home", TempData["sub"]);
            }
            else
            {
                TempData["sub"] = "false";
                return RedirectToAction("Index", "Home", TempData["sub"]);
            }
            
        }
    }
}

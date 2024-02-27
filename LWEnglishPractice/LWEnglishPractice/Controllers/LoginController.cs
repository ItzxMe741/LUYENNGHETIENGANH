using LWEnglishPractice.Entities;
using LWEnglishPractice.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Macs;
using QuanLySanXuat.Entities;
using QuanLySanXuat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace LWEnglishPractice.Controllers
{
    public class LoginController : Controller
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ListenAndWriteContext _context;
        public LoginController(ListenAndWriteContext context)
        {
            _context = context;
          
        }
        //public LoginController(
        //    UserManager<ApplicationUser> userManager,
        //    SignInManager<ApplicationUser> signInManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //}
        [HttpGet]
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Learning", "Home");

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Account model)
        {
            //if (ModelState.IsValid)
            //{
            //    var user = await _userManager.FindByNameAsync(model.Email);

            //    if (user != null)
            //    {
            //        var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            //        if (result.Succeeded)
            //        {
            //            return RedirectToLocal(returnUrl);
            //        }
            //    }
            //}

            //ModelState.AddModelError("", "Invalid login attempt");
            //return View(model);

            try
            {
                Learner l = _context.Learner.Where(tk => tk.Email.Equals(model.Email)).Where(tk => tk.Password.Equals(model.Password)).FirstOrDefault();
                if (l != null)
                {
                    Response.Cookies.Append("HienCaCookie", l.Email);
                    List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, l.Email),
                    new Claim("OtherProperties", "Example Role")
                };
                    ClaimsIdentity claimIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        IsPersistent = model.KeepLoggedIn
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity), properties);

                    if (l.Email != "darkheross74@gmail.com")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Lessons");
                    }
                       

                }
                

                else
                {
                    TempData["ErrorLogin"] = "This account is not valid!";
                    return View();

                }
            }
            catch
            {
                return View();
            }
        }

        
        public async Task<IActionResult> Logout()
        {
            if (Request.Cookies["HienCaCookie"] != null)
            {
                Response.Cookies.Delete("HienCaCookie");

            }
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Register(Account model)
        {


            //var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            //var result = await _userManager.CreateAsync(user, model.Password);
            //if (result.Succeeded)
            //{
            //    await _signInManager.SignInAsync(user, isPersistent: false);
            //    Learner learner = new Learner();
            //    learner.Email = model.Email;
            //    learner.Password = model.Password;
            //    learner.Fullname = "No Name";
            //    learner.Joindate = DateTime.Now;
            //    learner.Sex = "Khác";
            //    _context.Learner.Add(learner);
            //    await _context.SaveChangesAsync();

            //    return RedirectToAction(nameof(HomeController.Index), "Home");
            //}
            //foreach (var error in result.Errors)
            //{
            //    ModelState.AddModelError(string.Empty, error.Description);
            //}
            try
            {
                Learner checkLearner = _context.Learner.Where(nv => nv.Email == model.Email).FirstOrDefault();
                if(checkLearner == null)
                {
                    Learner learner = new Learner();
                    learner.Email = model.Email;
                    learner.Password = model.Password;
                    learner.Fullname = "No Name";
                    learner.Joindate = DateTime.Now;
                    learner.Sex = "Khác";
                    _context.Learner.Add(learner);
                    await _context.SaveChangesAsync();
                   
                }
                else
                {
                    TempData["existEmail"] = "Email already exists!";
                }
                return RedirectToAction("Login", "Login");

            }
            catch
            {
                return RedirectToAction("Login", "Login");

            }


        }
        public IActionResult GetPassword()
        {
            return View();
        }
        public string GenerateToken(int length)
        {
            using (RNGCryptoServiceProvider cryptRNG = new RNGCryptoServiceProvider())
            {
                byte[] tokenBuffer = new byte[length];
                cryptRNG.GetBytes(tokenBuffer);
                return Convert.ToBase64String(tokenBuffer);
            }
        }
        [HttpPost]
        public async Task<IActionResult> GetPassword(Account account)
        {

            var newPassword = GenerateToken(12);
            string errorMessage = "Email không chính xác. Vui lòng kiểm tra lại email!";


            try
            {
                Learner learner = await _context.Learner.Where(e => e.Email.Equals(account.Email)).FirstOrDefaultAsync();


                string message = "";
                var address = account.Email;

                var subject = "Reset your password";

                var mailContent = new MailContent();
                mailContent.Subject = subject;
                if (learner != null)
                {
                    message = "Xin Chào '" + learner.Fullname + "' Mật khẩu mới của bạn là " + newPassword;
                    learner.Password = newPassword;
                    mailContent.To = learner.Email;
                }
                
                else
                {
                    ViewData["errorMessage"] = errorMessage;
                }
                mailContent.Body = "<h1>From: Listen And Write </h1><br/>" + message;

                //sendmail(từ mail, đến mail, tiêu đề, nội dung, mail gửi, mật khẩu ứng dụng)


                //mailContent.To = "dtny050601@gmail.com";   



                //IConfiguration _configuration = null;

                //_configuration.GetSection("MailSettings");

                ////khai báo lấy cấu hình trong appsetting.json ra
                //IOptions<MailSettings> mailSettings = mailSettings.;
                //SendMailService c = new SendMailService(mailSettings);
                SendMailService c = new SendMailService();
                c.SendMail(mailContent);

                _context.SaveChanges();

                TempData["SuccessMessage"] = "Chúng tôi đã gửi mail xác nhận đến cho bạn. Vui lòng kiểm tra mail!";

                //return RedirectToAction("Login", "Access");


            }
            catch (Exception e)
            {
                ViewData["errorMessage"] = "Email không khả dụng " + e;
            }



            return View();
        }

        public static string RandomNumber(int numberRD)
        {
            string randomStr = "";
            try
            {

                int[] myIntArray = new int[numberRD];
                int x;
                //that is to create the random # and add it to string
                Random autoRand = new Random();
                for (x = 0; x < numberRD; x++)
                {
                    myIntArray[x] = System.Convert.ToInt32(autoRand.Next(0, 9));
                    randomStr += (myIntArray[x].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return randomStr;
        }

    }

}

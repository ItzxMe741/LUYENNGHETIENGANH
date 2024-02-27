using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LWEnglishPractice.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Cryptography;
using QuanLySanXuat.Service;
using QuanLySanXuat.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using LWEnglishPractice.Models;

namespace LWEnglishPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ListenAndWriteContext _context;

        public HomeController(ListenAndWriteContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Learning(int id, Track track)
        {



            List<Track> mytrack = await _context.Track.Where(a => a.Idlesson == id).Include(l => l.IdlessonNavigation).Include(l => l.IdlessonNavigation.IdlevelNavigation).ToListAsync();
            Track getLevel = await _context.Track.Where(a => a.Idlesson == id).Include(l => l.IdlessonNavigation).Include(l => l.IdlessonNavigation.IdlevelNavigation).FirstOrDefaultAsync();
            TempData["LevelLesson"] = getLevel;// get level of the lesson
            TempData["track"] = mytrack;
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };
            ViewBag.CookieValue = JsonConvert.SerializeObject(mytrack, settings);
            //ViewBag.LevelLesson = JsonConvert.SerializeObject(mytrack., settings);
            return View(await _context.Track.Where(a => a.Idlesson == id).Include(l => l.IdlessonNavigation).Include(l => l.IdlessonNavigation.IdlevelNavigation).FirstOrDefaultAsync());

        }
        public async Task<IActionResult> Profile()
        {

            string employeeEmail = Request.Cookies["HienCaCookie"];
            Learner learner = await _context.Learner.Where(nv => nv.Email == employeeEmail).FirstOrDefaultAsync();

            if (learner == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View(learner);
            }

        }
        public async Task<IActionResult> Ranking()
        {

            string employeeEmail = Request.Cookies["HienCaCookie"];
            Learner learner = await _context.Learner.Where(nv => nv.Email == employeeEmail).FirstOrDefaultAsync();


            var ranking = _context.Learner
    .SelectMany(l => l.History, (l, h) => new { Learner = l, History = h })
    .Join(_context.Lesson, lh => lh.History.Idlesson, l => l.Idlesson, (lh, l) => new { Learner = lh.Learner, Lesson = l, Score = lh.History.Score })
    .GroupBy(x => new { x.Learner.Idlearner, x.Learner.Fullname, x.Learner.Sex, x.Learner.Image })
    .Select(g => new
    {
        Fullname = g.Key.Fullname,
        Sex = g.Key.Sex,
        Image = g.Key.Image,
        Scores = g.Sum(x => x.Score),

    })
    .OrderByDescending(x => x.Scores)
    .ToList();
            List<History> rankedResult = new List<History>();
            foreach (var item in ranking)
            {
                History h = new History();
                h.IdlearnerNavigation = new Learner();
                h.IdlearnerNavigation.Fullname = item.Fullname;
                h.IdlearnerNavigation.Sex = item.Sex;
                h.IdlearnerNavigation.Image = item.Image;
                h.Score = item.Scores;
                rankedResult.Add(h);
            }
            if (rankedResult.Count >= 1)
            {
                TempData["TopOne"] = rankedResult[0];

            }
            if (rankedResult.Count >= 2)
            {
                TempData["TopTwo"] = rankedResult[1];

            }
            if (rankedResult.Count >= 3)
            {
                TempData["TopThree"] = rankedResult[2];

            }
            if (rankedResult.Count >= 4)
            {
                List<History> OtherTops = new List<History>();

                foreach (var item in ranking.GetRange(3, ranking.Count - 3))
                {
                    History h = new History();
                    h.IdlearnerNavigation = new Learner();
                    h.IdlearnerNavigation.Fullname = item.Fullname;
                    h.IdlearnerNavigation.Sex = item.Sex;
                    h.IdlearnerNavigation.Image = item.Image;
                    h.Score = item.Scores;
                    OtherTops.Add(h);

                }
                TempData["OtherTops"] = OtherTops;

            }


            return View(rankedResult);


        }

        public async Task<IActionResult> Statistics()
        {

            string employeeEmail = Request.Cookies["HienCaCookie"];
            Learner learner = await _context.Learner.Where(nv => nv.Email == employeeEmail).FirstOrDefaultAsync();

            if (learner != null)
            {
                var reusults = _context.Learner
    .SelectMany(l => l.History, (l, h) => new { Learner = l, History = h })
    .Join(_context.Lesson, lh => lh.History.Idlesson, l => l.Idlesson, (lh, l) => new { Learner = lh.Learner, Lesson = l, Score = lh.History.Score, his = lh.History })
    .Where(l => l.Learner.Idlearner == learner.Idlearner)
    .GroupBy(x => new { x.Learner.Idlearner, x.Learner.Fullname, x.his.Finishdate })
    .Select(g => new
    {
        Finishdate = g.Key.Finishdate,
        Fullname = g.Key.Fullname,
        Idlearner = g.Key.Idlearner,
        Scores = g.Sum(x => x.Score),

    })
    .OrderByDescending(x => x.Finishdate)
    .ToList();
                List<History> Results = new List<History>();
                foreach (var item in reusults)
                {
                    History h = new History();
                    h.IdlearnerNavigation = new Learner();
                    h.IdlearnerNavigation.Fullname = item.Fullname;
                    h.IdlearnerNavigation.Idlearner = item.Idlearner;
                    h.Finishdate = item.Finishdate;
                    h.Score = item.Scores;
                    //h.Idhistory = item.Idhistory;
                    Results.Add(h);
                }
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                };
                ViewBag.dataStatistics = JsonConvert.SerializeObject(Results, settings);

                return View(Results);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }



        }
        public async Task<IActionResult> Index(int? id, string? search)
        {
            if (id != null && search == null)
            {

                var listenAndWriteContext = await _context.Lesson.Where(a => a.Active == 1).Include(l => l.IdlevelNavigation).Where(a => a.IdlevelNavigation.Level1.Equals(id)).ToListAsync();

                return View(listenAndWriteContext);

            }
            else if (id != null && search != null )
            {

                var listenAndWriteContext = await _context.Lesson.Where(a => a.Active == 1).Where(n => n.Lessonanme.Contains(search)).Include(l => l.IdlevelNavigation).Where(a => a.IdlevelNavigation.Level1.Equals(id)).ToListAsync();

                return View(listenAndWriteContext);

            }
            else if(id == null && search != null )
            {

                var listenAndWriteContext = await _context.Lesson.Where(a => a.Active == 1).Where(n => n.Lessonanme.Contains(search)).Include(l => l.IdlevelNavigation).ToListAsync();

                return View(listenAndWriteContext);

            }
            else
            {
                var listenAndWriteContext = _context.Lesson.Include(l => l.IdlevelNavigation);
                return View(await listenAndWriteContext.Where(a => a.Active == 1).ToListAsync());
            }

        }
        //public IActionResult Index()
        //{
        //    ClaimsPrincipal claimUser = HttpContext.User;
        //    if (claimUser.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Learning", "Home");

        //    }
        //    return View();
        //}
        public async Task<IActionResult> Logout()
        {
            if (Request.Cookies["HienCaCookie"] != null)
            {
                Response.Cookies.Delete("HienCaCookie");

            }
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(Account account)
        {
            Learner learner = new Learner();
            learner.Email = account.Email;
            learner.Password = account.Password;
            learner.Fullname = "Bimat";
            learner.Sex = "Khác";
            learner.Joindate = DateTime.Now;
            _context.Learner.Add(learner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Login));

        }
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Account account)
        {

            Learner l = _context.Learner.Where(tk => tk.Email.Equals(account.Email)).Where(tk => tk.Password.Equals(account.Password)).FirstOrDefault();
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
                    IsPersistent = account.KeepLoggedIn
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimIdentity), properties);


                return RedirectToAction("Learning", "Home");

            }
            else
            {
                ViewData["ValidateMessage"] = "Tài khoản đăng nhập không hợp lệ";

            }

            return View();
        }
        public IActionResult ForgotPassword()
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
        public IActionResult ForgotPassword(Learner learner)
        {

            var newPassword = GenerateToken(12);
            string errorMessage = "Email không chính xác. Vui lòng kiểm tra lại email!";


            try
            {
                Learner l = _context.Learner.Where(tk => tk.Email.Equals(learner.Email)).FirstOrDefault();

                string message = "";
                var address = learner.Email;

                var subject = "Reset your password";

                var mailContent = new MailContent();
                mailContent.Subject = subject;
                if (l != null)
                {
                    message = "Xin Chào '" + l.Fullname + "' Mật khẩu mới của bạn là " + newPassword;
                    l.Password = newPassword;
                    mailContent.To = l.Email;
                }

                else
                {
                    ViewData["errorMessage"] = errorMessage;
                }
                mailContent.Body = "<h1>From HienCa Production</h1><br/>" + message;


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

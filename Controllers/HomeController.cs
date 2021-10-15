using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Wedding.Models;


namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View("LoginReg");
        }

        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(user => user.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in system!");
                    return View("LoginReg");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);

                _context.Add(newUser);
                _context.SaveChanges();

                HttpContext.Session.SetInt32("LoggedUserId", newUser.UserId);


                return RedirectToAction("dashboard");
            }
            return View("LoginReg");
        }


        [HttpPost("login")]
        public IActionResult Login(LoginUser checkMe)
        {
            if(ModelState.IsValid)
            {
                User userInDb = _context.Users.FirstOrDefault(use => use.Email == checkMe.LoginEmail);
                if(userInDb == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Login!");
                    return View("LoginReg");
                }

                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();

                var result = hasher.VerifyHashedPassword(checkMe, userInDb.Password, checkMe.LoginPassword);

                if(result ==0)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Login!");
                    return View("LoginReg");
                }

                HttpContext.Session.SetInt32("LoggedUserId", userInDb.UserId);
                return RedirectToAction("dashboard");
            }
            return View("LoginReg");
        }

        [HttpGet("/dashboard")]
        public IActionResult Dashboard()
        {
            int? loggedUserId = HttpContext.Session.GetInt32("LoggedUserId");
            if(loggedUserId==null) return RedirectToAction("Index");
            ViewBag.User = _context.Users.FirstOrDefault(user => user.UserId == loggedUserId);

            ViewBag.AllWeddings = _context.Weddings
                .Include(wed => wed.RSVPs)
                .OrderBy(wed => wed.Date)
                .ToList();


            return View();
        }
        [HttpGet("/newwedding")]
        public IActionResult NewWedding()
        {
            int? loggedUserId = HttpContext.Session.GetInt32("LoggedUserId");
            if(loggedUserId==null) return RedirectToAction("Index");
            ViewBag.User = _context.Users.FirstOrDefault(user => user.UserId == loggedUserId);
            return View();
        }

        [HttpPost("CreateWedding")]
        public IActionResult CreateWedding(WeddingModel newWedding)
        {
            if(ModelState.IsValid)
            {
            _context.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
            }
            int? loggedUserId = HttpContext.Session.GetInt32("LoggedUserId");
            if(loggedUserId==null) return RedirectToAction("Index");
            ViewBag.User = _context.Users.FirstOrDefault(user => user.UserId == loggedUserId);
            return View("NewWedding");
        }

        [HttpGet("DeleteWedding/{WeddingId}")]
        public IActionResult DeleteWedding(int weddingId)
        {
            WeddingModel deletedWedding = _context.Weddings
                .FirstOrDefault(wed => wed.WeddingId == weddingId);
            _context.Weddings.Remove(deletedWedding);
            _context.SaveChanges();
            return RedirectToAction("Deleted");
        }

        [HttpGet("rsvp/{WeddingId}")]
        public IActionResult RSVP(int weddingId)
        {
            int? loggedUserId = HttpContext.Session.GetInt32("LoggedUserId");
            if(loggedUserId==null) return RedirectToAction("Index");
            bool rsvpExists = _context.RSVPs.Any(rsvp => rsvp.UserId == loggedUserId && rsvp.WeddingId == weddingId);
            if(!rsvpExists){
                RSVP newRSVP = new RSVP();
                newRSVP.UserId = (int)loggedUserId;
                newRSVP.WeddingId = weddingId;
                _context.Add(newRSVP);  
                _context.SaveChanges();

            }
            else
            {
                RSVP delete = _context.RSVPs.FirstOrDefault(rsvp => rsvp.UserId == loggedUserId && rsvp.WeddingId == weddingId);
                _context.RSVPs.Remove(delete);
                _context.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }


        [HttpGet("ReadWedding/{WeddingId}")]
        public IActionResult ReadWedding(int weddingId)
        {
            int? loggedUserId = HttpContext.Session.GetInt32("LoggedUserId");
            if(loggedUserId==null) return RedirectToAction("Index");
            ViewBag.User = _context.Users.FirstOrDefault(user => user.UserId == loggedUserId);

            ViewBag.OneModel = _context.Weddings
                .FirstOrDefault(wed => wed.WeddingId == weddingId);

            ViewBag.GuestList = _context.RSVPs
                .Include(rsvp => rsvp.User)
                .Where(rsvp => rsvp.WeddingId == weddingId)
                .ToList();

            return View();
        }

        [HttpGet("Deleted")]
        public IActionResult Deleted()
        {
            int? loggedUserId = HttpContext.Session.GetInt32("LoggedUserId");
            if(loggedUserId==null) return RedirectToAction("Index");
            ViewBag.User = _context.Users.FirstOrDefault(user => user.UserId == loggedUserId);
            return View();
        }


        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Link.Data;
using Link.Models;
using Link.Models.AddSitesViewModels;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Link.Controllers
{
    [Route("sisesta")]
    public class AddSitesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AddSitesController> _logger;
        public AddSitesController(ApplicationDbContext context, ILogger<AddSitesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FormSubmissionViewModel fsViewModel)
        {
            if (UserExists(fsViewModel.User)) {
                ViewData["errorString"] = "See kasutaja on juba andmeid sisestanud.";
                return View();
            }
            IEnumerable<ValidationResult> errors = fsViewModel.Validate(new ValidationContext(fsViewModel));
            if (errors.Count() == 0)
            {
                _context.Add(fsViewModel.User);
                _context.SaveChanges();
                List<WebSiteInfo> wsInfos = fsViewModel.WebSiteInfos.Where(wsi => Validator.TryValidateObject(wsi, new ValidationContext(wsi), new List<ValidationResult>())).ToList();
                wsInfos.ForEach(wsi =>
                {
                    wsi.User = fsViewModel.User;
                    _context.Add(wsi);
                });
                _context.SaveChanges();
                TempData["successMessage"] = "Saitide lisamine õnnestus";
                return RedirectToAction("Index", "DisplaySites");
            }
            ViewData["errorString"] = errors.Aggregate((err1, err2) => new ValidationResult(err1 + " " + err2)).ErrorMessage;
            return View();
        }
        private bool UserExists(User newUser)
        {
            return _context.Users.Any(usr => usr.Equals(newUser));
        }
    }
}

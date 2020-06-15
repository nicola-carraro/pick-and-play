using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using PickAndPlay.Models;

namespace PickAndPlay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly PickAndPlayContext _context;

        public HomeController(ILogger<HomeController> logger, PickAndPlayContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Jeu>jeux = _context.Jeu.Include(j => j.JeuImage).ThenInclude(ji => ji.IdImageNavigation);
            
            foreach (Jeu jeu in jeux)
            {
                if (jeu.JeuImage != null)
                {
                    jeu.ImagePrincipale = (from ji in jeu.JeuImage
                                where ji.ImagePrincipale == true
                                select ji.IdImageNavigation).FirstOrDefault();
                   
                }
            }


            ViewData["NouveautesJeux"] = jeux;


            return View();
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

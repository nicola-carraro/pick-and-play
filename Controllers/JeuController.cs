using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PickAndPlay.Models;

namespace PickAndPlay.Controllers
{
    public class JeuController : Controller
    {


        private readonly ILogger<HomeController> _logger;

        private readonly PickAndPlay.Models.PickAndPlayContext _context;

        Jeu jeu;

        Image image;

        public JeuController(ILogger<HomeController> logger, PickAndPlay.Models.PickAndPlayContext context)
        {
            _logger = logger;
            _context = context;
        }




            // GET: JeuController/Fiche
            public ActionResult Fiche(int? id)
        {
            var query = (from j in _context.Jeux
                         where j.Id == id
                         select j).Include(j => j.JeuxImages)
                                    .ThenInclude(ji => ji.Image);

            jeu = query.FirstOrDefault();

            if (jeu == null)
            {
                return NotFound();
            }

            foreach (JeuImage item in jeu.JeuxImages)
            {
                if (item.IdImage != null && item.Image.Largeur >= 1000)
                {
                    image = item.Image;
                }
            }

            ViewData["Jeu"] = jeu;
            ViewData["Image"] = image;

            return View();
        }

        // GET: JeuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JeuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JeuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JeuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JeuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JeuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JeuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

using Projeto.Context;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class FilmeController : Controller
    {
        private readonly Contexto _contexto = new Contexto();

        // GET: Filme
        public ActionResult Index()
        {
            var filmes = _contexto.Filmes.ToList();
            return View(filmes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FilmeModel filme)
        {
            if (ModelState.IsValid)
            {
                _contexto.Filmes.Add(filme);
                _contexto.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FilmeModel filme = _contexto.Filmes.Where(f => f.Id == id).FirstOrDefault();

            if (filme == null)
            {
                return HttpNotFound();
            }

            return View(filme);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FilmeModel filme = _contexto.Filmes.Where(f => f.Id == id).FirstOrDefault();

            if (filme == null)
            {
                return HttpNotFound();
            }

            return View(filme);
        }

        [HttpPost]
        public ActionResult Edit(FilmeModel filme)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Entry(filme).State = EntityState.Modified;
                    _contexto.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(filme);
                }
            }

            return View(filme);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FilmeModel filme = _contexto.Filmes.Where(f => f.Id == id).FirstOrDefault();

            if (filme == null)
            {
                return HttpNotFound();
            }

            return View(filme);
        }

        [HttpPost]
        public ActionResult Delete(FilmeModel filme)
        {
            try
            {
                _contexto.Entry(filme).State = EntityState.Deleted;
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(filme);
            }
        }
    }
}
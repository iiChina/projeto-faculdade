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
    public class ClienteController : Controller
    {
        private readonly Contexto _contexto = new Contexto();

        // GET: Cliente
        public ActionResult Index()
        {
            var clientes = _contexto.Clientes.ToList();
            return View(clientes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClienteModel clienteModel)
        {
            if (ModelState.IsValid)
            {
                _contexto.Clientes.Add(clienteModel);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(clienteModel);
        }

        [HttpGet]
        public ActionResult Details (int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClienteModel clienteModel = _contexto.Clientes.Where(c => c.Id == id).FirstOrDefault();

            if(clienteModel == null)
            {
                return HttpNotFound();
            }

            return View(clienteModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClienteModel clienteModel = _contexto.Clientes.Where(c => c.Id == id).FirstOrDefault();

            if(clienteModel == null)
            {
                return HttpNotFound();
            }

            return View(clienteModel);
        }

        [HttpPost]
        public ActionResult Edit(ClienteModel clienteModel)
        {
            if (ModelState.IsValid)
            {
                _contexto.Entry(clienteModel).State = EntityState.Modified;
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(clienteModel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClienteModel clienteModel = _contexto.Clientes.Where(c => c.Id == id).FirstOrDefault();

            if(clienteModel == null)
            {
                return HttpNotFound();
            }

            return View(clienteModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClienteModel clienteModel = _contexto.Clientes.Find(id);
            _contexto.Clientes.Remove(clienteModel);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
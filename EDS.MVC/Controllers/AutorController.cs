using AutoMapper;
using EDS.Application.Interfaces;
using EDS.Domain.Entities;
using EDS.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EDS.MVC.Controllers
{
    public class AutorController : Controller
    {
        #region Propriedades

        private readonly IAutorApplicationService _autorApp;

        #endregion

        #region Construtor

        public AutorController(IAutorApplicationService autorApp)
        {
            _autorApp = autorApp;
        }

        #endregion

        #region Actions
        // GET: Autor
        public ActionResult Index()
        {
            var autorView = Mapper.Map<IEnumerable<Autor>, IEnumerable<AutorViewModel>>(_autorApp.GetAllForAtivo());
            return View(autorView);
        }

        // GET: Autor/Details/5
        public ActionResult Details(int id)
        {
            var autorView = Mapper.Map<Autor, AutorViewModel>(_autorApp.GetById(id));
            return View(autorView);
        }

        // GET: Autor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AutorViewModel autor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var autorDomain = Mapper.Map<AutorViewModel, Autor>(autor);
                    _autorApp.Add(autorDomain);

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return PartialView("Create", autor);
                }
            }

            return PartialView(autor);
        }

        // GET: Autor/Edit/5
        public ActionResult Edit(int id)
        {
            var autorView = Mapper.Map<Autor, AutorViewModel>(_autorApp.GetById(id));
            return View(autorView);
        }

        // POST: Autor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AutorViewModel autor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    autor.Ativo = autor.Ativo ?? "S";

                    var autorDomain = Mapper.Map<AutorViewModel, Autor>(autor);
                    _autorApp.Update(autorDomain);

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return PartialView("Edit", autor);
                }
            }

            return PartialView(autor);
        }

        // POST: Autor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            LivroViewModel autorView = new LivroViewModel();

            if (ModelState.IsValid)
            {
                try
                {
                    var autorDomain = _autorApp.GetById(id);
                    autorDomain.Ativo = "N";
                    _autorApp.Update(autorDomain);

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return PartialView("Delete", autorView);
                }
            }
            else
            {
                ViewBag.Error = "Sem dados de formulário preenchidos!";
            }

            return PartialView(autorView);
        }

        #endregion
    }
}

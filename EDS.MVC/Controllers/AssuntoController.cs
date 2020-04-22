using AutoMapper;
using EDS.Application.Interfaces;
using EDS.Domain.Entities;
using EDS.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EDS.MVC.Controllers
{
    public class AssuntoController : Controller
    {
        #region Propriedades

        private readonly IAssuntoApplicationService _assuntoApp;

        #endregion

        #region Construtor

        public AssuntoController(IAssuntoApplicationService assuntoApp)
        {
            _assuntoApp = assuntoApp;
        }

        #endregion

        #region Actions
        // GET: Assunto
        public ActionResult Index()
        {
            var assuntoView = Mapper.Map<IEnumerable<Assunto>, IEnumerable<AssuntoViewModel>>(_assuntoApp.GetAllForAtivo());
            return View(assuntoView);
        }

        // GET: Assunto/Details/5
        public ActionResult Details(int id)
        {
            var assuntoView = Mapper.Map<Assunto, AssuntoViewModel>(_assuntoApp.GetById(id));
            return View(assuntoView);
        }

        // GET: Assunto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assunto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssuntoViewModel assunto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var assuntoDomain = Mapper.Map<AssuntoViewModel, Assunto>(assunto);
                    _assuntoApp.Add(assuntoDomain);

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return PartialView("Create", assunto);
                }
            }

            return PartialView(assunto);
        }

        // GET: Assunto/Edit/5
        public ActionResult Edit(int id)
        {
            var assuntoView = Mapper.Map<Assunto, AssuntoViewModel>(_assuntoApp.GetById(id));
            return View(assuntoView);
        }

        // POST: Assunto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AssuntoViewModel assunto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    assunto.Ativo = assunto.Ativo ?? "S";

                    var assuntoDomain = Mapper.Map<AssuntoViewModel, Assunto>(assunto);
                    _assuntoApp.Update(assuntoDomain);

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return PartialView("Edit", assunto);
                }
            }

            return PartialView(assunto);
        }

        // POST: Assunto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            AssuntoViewModel assuntoView = new AssuntoViewModel();

            if (ModelState.IsValid)
            {
                try
                {
                    var assuntoDomain = _assuntoApp.GetById(id);
                    assuntoDomain.Ativo = "N";
                    _assuntoApp.Update(assuntoDomain);

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return PartialView("Delete", assuntoView);
                }
            }
            else
            {
                ViewBag.Error = "Sem dados de formulário preenchidos!";
            }

            return PartialView(assuntoView);
        }

        #endregion
    }
}

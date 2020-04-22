using AutoMapper;
using EDS.Application.Interfaces;
using EDS.Domain.Entities;
using EDS.MVC.ViewModels;
using PagedList;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EDS.MVC.Controllers
{
    public class LivroController : Controller
    {
        #region Propriedades

        private readonly IAssuntoApplicationService _assuntoApp;
        private readonly IAutorApplicationService _autorApp;
        private readonly ILivroApplicationService _livroApp;
        private readonly ILivroAssuntoApplicationService _livroAssuntoApp;
        private readonly ILivroAutorApplicationService _livroAutorApp;

        #endregion

        #region Construtor

        public LivroController(IAssuntoApplicationService assuntoApp, IAutorApplicationService autorApp, ILivroApplicationService livroApp, ILivroAssuntoApplicationService livroAssuntoApp, ILivroAutorApplicationService livroAutorApp)
        {
            _assuntoApp = assuntoApp;
            _autorApp = autorApp;
            _livroApp = livroApp;
            _livroAssuntoApp = livroAssuntoApp;
            _livroAutorApp = livroAutorApp;
        }

        #endregion

        #region Actions

        // GET: Livro
        public ActionResult Index()
        {
            var livroView = Mapper.Map<IEnumerable<Livro>, IEnumerable<LivroViewModel>>(_livroApp.GetAllForAtivo());
            return View(livroView);
        }

        // GET: Livro/Details/5
        public ActionResult Details(int id)
        {
            var livroView = Mapper.Map<Livro, LivroViewModel>(_livroApp.GetForLivroId(id));

            PopularCombos();

            foreach (var it in livroView.LivroAssuntos)
            {
                livroView.AssuntoId = it.AssuntoId;
            }

            foreach (var it in livroView.LivroAutores)
            {
                livroView.AutorId = it.AutorId;
            }

            return View(livroView);
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            PopularCombos();
            return View();
        }

        // POST: Livro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LivroViewModel livro)
        {
            if (ModelState.IsValid)
            {
                int idLivro = 0;

                try
                {
                    livro.Ativo = "S";

                    var livroDomain = Mapper.Map<LivroViewModel, Livro>(livro);
                    _livroApp.Add(livroDomain);

                    var livroView = Mapper.Map<Livro, LivroViewModel>(_livroApp.GetAllDescending());

                    if (livroView != null)
                    {
                        idLivro = livroView.LivroId;

                        var rAssunto = IncluirAlterarLivroAssunto(livro.AssuntoId, idLivro);
                        if (rAssunto != "Sucesso")
                        {
                            return Json(new { success = false, error = rAssunto });
                        }

                        var rAutor = IncluirAlterarLivroAutor(livro.AutorId, idLivro);
                        if (rAutor != "Sucesso")
                        {
                            return Json(new { success = false, error = rAutor });
                        }
                    }
                    else
                    {
                        PopularCombos();
                        return Json(new { success = false, error = "Error|Livro sem código ainda!" });
                    }

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return PartialView("Create", livro);
                }
            }

            PopularCombos();
            return PartialView(livro);
        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int id)
        {
            var livroView = Mapper.Map<Livro, LivroViewModel>(_livroApp.GetForLivroId(id));

            PopularCombos();

            foreach (var it in livroView.LivroAssuntos)
            {
                livroView.AssuntoId = it.AssuntoId;
            }

            foreach (var it in livroView.LivroAutores)
            {
                livroView.AutorId = it.AutorId;
            }

            return View(livroView);
        }

        // POST: Livro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LivroViewModel livro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    livro.Ativo = livro.Ativo ?? "S";

                    var livroDomain = Mapper.Map<LivroViewModel, Livro>(livro);
                    _livroApp.Update(livroDomain);

                    var rAssunto = IncluirAlterarLivroAssunto(livro.AssuntoId, livro.LivroId);
                    if (rAssunto != "Sucesso")
                    {
                        return Json(new { success = false, error = rAssunto });
                    }

                    var rAutor = IncluirAlterarLivroAutor(livro.AutorId, livro.LivroId);
                    if (rAutor != "Sucesso")
                    {
                        return Json(new { success = false, error = rAutor });
                    }

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return PartialView("Edit", livro);
                }
            }

            PopularCombos();
            return PartialView(livro);
        }

        // POST: Livro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            LivroViewModel livroView = new LivroViewModel();

            if (ModelState.IsValid)
            {
                try
                {
                    var livroDomain = _livroApp.GetById(id);
                    livroDomain.Ativo = "N";
                    _livroApp.Update(livroDomain);

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return PartialView("Delete", livroView);
                }
            }
            else
            {
                ViewBag.Error = "Sem dados de formulário preenchidos!";
            }

            return PartialView(livroView);
        }

        public ActionResult RelatorioPDF(int? pagina, bool? pdf)
        {
            var livroView = Mapper.Map<List<Livro>, List<LivroViewModel>>(_livroApp.GetAllForRelatorioPDF());
            if (livroView.Count == 0)
            {
                ViewBag.Error = "Nem registro encontrado!";
                return View(livroView);
            }
            else
            {
                if (pdf != true)
                {
                    int numeroRegistros = 3;
                    int numeroPagina = (pagina ?? 1);
                    return View(livroView.ToPagedList(numeroPagina, numeroRegistros));
                }
                else
                {
                    const int pagNumero = 1;

                    return new ViewAsPdf
                    {
                        ViewName = "RelatorioPDF",
                        IsGrayScale = true,
                       // FileName = "RelatorioLivrosPDF",
                        Model = livroView.ToPagedList(pagNumero, livroView.Count)
                    };
                }
            }
        }

        #endregion

        #region Privados

        private void PopularCombos()
        {
            ViewBag.ddlAssunto = new SelectList(_assuntoApp.GetAllForAtivo(), "AssuntoId", "Descricao");
            ViewBag.ddlAutor = new SelectList(_autorApp.GetAllForAtivo(), "AutorId", "Nome");
        }

        /// <summary>
        /// Método que realiza a inclusão/alteração do LivroAssunto
        /// </summary>
        /// <param name="AssuntoId">Identificação do Assunto</param>
        /// <param name="CodId">Identificação do Livro</param>
        /// <returns>Retorna uma mensgem de sucesso ou erro</returns>
        private string IncluirAlterarLivroAssunto(int AssuntoId, int CodId)
        {
            string retorno = string.Empty;

            try
            {
                var result = Mapper.Map<List<LivroAssunto>, List<LivroAssuntoViewModel>>(_livroAssuntoApp.GetForLivroAssuntoIdLivro(CodId));

                if (result != null)
                {
                    if (result.Count == 0)
                    {
                        var rLivroAssunto = new LivroAssuntoViewModel()
                        {
                            AssuntoId = AssuntoId,
                            LivroId = CodId
                        };

                        var livroAssuntoDomain = Mapper.Map<LivroAssuntoViewModel, LivroAssunto>(rLivroAssunto);
                        _livroAssuntoApp.Add(livroAssuntoDomain);
                        retorno = "Sucesso";
                    }
                    else
                    {
                        retorno = "Sucesso";
                    }
                }
                else
                {
                    retorno = "Error|Objeto de referência";
                }
            }
            catch (Exception ex)
            {
                retorno = "Error|" + ex.Message;
            }

            return retorno;
        }

        /// <summary>
        /// Método que realiza a inclusão/alteração de LivroAutor
        /// </summary>
        /// <param name="AutorId">Identificação do Autor</param>
        /// <param name="CodId">Identificação do Livro</param>
        /// <returns>Retorna uma mensgem de sucesso ou erro</returns>
        private string IncluirAlterarLivroAutor(int AutorId, int CodId)
        {
            string retorno = string.Empty;

            try
            {
                var livroAutorView = Mapper.Map<List<LivroAutor>, List<LivroAutorViewModel>>(_livroAutorApp.GetForLivroAutorIdLivro(CodId));

                if (livroAutorView != null)
                {
                    if (livroAutorView.Count == 0)
                    {
                        var rLivroAutor = new LivroAutorViewModel()
                        {
                            AutorId = AutorId,
                            LivroId = CodId
                        };

                        var livroAutorDomain = Mapper.Map<LivroAutorViewModel, LivroAutor>(rLivroAutor);
                        _livroAutorApp.Add(livroAutorDomain);
                        retorno = "Sucesso";
                    }
                    else
                    {
                        retorno = "Sucesso";
                    }
                }
                else
                {
                    retorno = "Error|Objeto de referência";
                }
            }
            catch (Exception ex)
            {
                retorno = "Error|" + ex.Message;
            }

            return retorno;
        }

        #endregion
    }
}

using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using DietCareDDD.Application.Interface;
using DietCareDDD.Domain.Entities;
using DietCareDDD.MVC.ViewModels;

namespace DietCareDDD.MVC.Controllers
{
    public class AlimentosController : Controller
    {
        private readonly IAlimentoAppService _alimentoApp;

        public AlimentosController(IAlimentoAppService alimentoApp)
        {
            _alimentoApp = alimentoApp;
        }

        // GET: Alimentos
        public ActionResult Index()
        {
            var alimentos = Mapper.Map<IEnumerable<Alimento>, IEnumerable<AlimentoViewModel>>(_alimentoApp.GetAll()); 
            return View(alimentos);
        }

        // GET: Alimentos/Details/5
        public ActionResult Details(int id)
        {
            var alimento = _alimentoApp.GetById(id);
            var alimentoViewModel = Mapper.Map<Alimento, AlimentoViewModel>(alimento);
            return View(alimentoViewModel);
        }

        // GET: Alimentos/Create
        public ActionResult Create()
        {
            /*
            ViewBag.Alimentos = new SelectList(
                _alimentoApp.GetAll(),
                "id_u"
            );
            */

            return View();
        }

        // POST: Alimentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlimentoViewModel alimento)
        {
            if (ModelState.IsValid)
            {
                var alimentoDomain = Mapper.Map<AlimentoViewModel, Alimento>(alimento);
                _alimentoApp.Add(alimentoDomain);

                return RedirectToAction("Index");
            }

            return View(alimento);
        }

        // GET: Alimentos/Edit/5
        public ActionResult Edit(int id)
        {
            var alimento = _alimentoApp.GetById(id);
            var alimentoViewModel = Mapper.Map<Alimento, AlimentoViewModel>(alimento);
            return View(alimentoViewModel);
        }

        // POST: Alimentos/Edit/5
        [HttpPost]
        public ActionResult Edit(AlimentoViewModel alimento)
        {
            if (ModelState.IsValid)
            {
                var alimentoDomain = Mapper.Map<AlimentoViewModel, Alimento>(alimento);
                _alimentoApp.Update(alimentoDomain);

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("ErroEdit", "Não foi possível alterar o Registro!"); // Testando mensagens de erro
            return View(alimento);
        }

        // GET: Alimentos/Delete/5
        public ActionResult Delete(int id)
        {
            var alimento = _alimentoApp.GetById(id);
            var alimentoViewModel = Mapper.Map<Alimento, AlimentoViewModel>(alimento);
            return View(alimentoViewModel);
        }

        // POST: Alimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var alimento = _alimentoApp.GetById(id);
            _alimentoApp.Remove(alimento);

            return RedirectToAction("Index");
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces;
using DietCareDDD.Infra.Data.Repositories;
using DietCareDDD.MVC.ViewModels;

namespace DietCareDDD.MVC.Controllers
{
    public class AlimentosController : Controller
    {
        private readonly AlimentoRepository _alimentoRepository = new AlimentoRepository();
        // GET: Alimentos
        public ActionResult Index()
        {
            var alimentos = Mapper.Map<IEnumerable<Alimento>, IEnumerable<AlimentoViewModel>>(_alimentoRepository.GetAll()); 
            return View(alimentos);
        }

        // GET: Alimentos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Alimentos/Create
        public ActionResult Create()
        {
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
                _alimentoRepository.Add(alimentoDomain);

                return RedirectToAction("Index");
            }

            return View(alimento);
        }

        // GET: Alimentos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Alimentos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alimentos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Alimentos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

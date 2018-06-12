using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DietCareDDD.Application.Interface;
using DietCareDDD.API.Clarifai;
using DietCareDDD.Domain.Entities;
using DietCareDDD.FatSecret;
using DietCareDDD.MVC.ViewModels;
using FatSecretSharp.Services;
using FatSecretSharp.Services.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DietCareDDD.MVC.Controllers
{
    public class AlimentosController : Controller
    {
        private readonly IAlimentoAppService _alimentoApp;
        private readonly IUnidadeAppService  _unidadeApp;

        public AlimentosController(IAlimentoAppService alimentoApp, IUnidadeAppService unidadeApp)
        {
            _alimentoApp = alimentoApp;
            _unidadeApp = unidadeApp;
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
            ViewBag.id_unid = new SelectList(
                _unidadeApp.GetAll(), // Todas as unidades
                "id_unid",            // Valor de cada objeto na lista - Referencia a classe Unidade
                "unid_simbolo"        // Valor a ser exibido na lista - Referencia a classe Unidade
            );

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
            ViewBag.id_unid = new SelectList(
                _unidadeApp.GetAll(), // Todas as unidades
                "id_unid",            // Valor de cada objeto na lista - Referencia a classe Unidade
                "unid_simbolo",       // Valor a ser exibido na lista - Referencia a classe Unidade
                alimento.id_unid      // Valor selecionado no Drop Down
            );
            return View(alimento);
        }

        // GET: Alimentos/Edit/5
        public ActionResult Edit(int id)
        {
            var alimento = _alimentoApp.GetById(id);
            var alimentoViewModel = Mapper.Map<Alimento, AlimentoViewModel>(alimento);

            ViewBag.id_unid = new SelectList(
                _unidadeApp.GetAll(), // Todas as unidades
                "id_unid",            // Valor de cada objeto na lista - Referencia a classe Unidade
                "unid_simbolo"        // Valor a ser exibido na lista - Referencia a classe Unidade
            );

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

        // GET: Alimentos/Photo
        public ActionResult Photo()
        {
            return View();
        }

        // POST: Alimentos/Photo
        [HttpPost]
        public async Task<ActionResult> Photo(string imageData)
        {
            var caminho = Path.Combine(Server.MapPath("~/Imagens"), "foto.png");
            byte[] data = Convert.FromBase64String(imageData);

            /*var json = await ClarifaiCall.Predict(data); TODO: DESCOMENTAR */
            
            //System.IO.File.WriteAllText(caminhoJson, json);

            /* JObject jsonObject = JObject.FromObject(JsonConvert.DeserializeObject(json)); TODO: DESCOMENTAR
            var nomeAlimento = jsonObject["outputs"][0]["data"]["concepts"][0]["name"].ToString();
            ViewBag.Alimento = nomeAlimento; */

            //Constant consumer Key and Shared Secret for FatSecret API
            //const string consumerKey = "89a75f2dda9748d08cc87d573992fecb";
            //const string consumerSecret = "5e1b6dc6e9e84451bc265d633b9fc0de";

            //var foodSearch = new FoodSearch(consumerKey, consumerSecret);

            //var response = foodSearch.GetResponseSynchronously(new FoodSearchRequest()
            //{
            //    SearchExpression = nomeAlimento
            //});

            FatSecretAPI fatsecret = new FatSecretAPI();

            string response = await fatsecret.buscarAlimento(""/*nomeAlimento*/);

            //ViewBag.FatSecret = response.foods.food[0].food_name;

            return View();
        }
    }
}

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

        //POST: Alimentos/Photo
        [HttpPost]
        public ActionResult Photo(string nomeDoAlimento, int numeroDeResultados)
        {
            var alimentoJson = @"
                                    {
                            'food': {
                                'food_id': '38212',
                                'food_name': 'Tilapia (Fish)',
                                'food_type': 'Generic',
                                'food_url': 'http://www.fatsecret.com/calories-nutrition/usda/tilapia-(fish)',
                                'servings': {
                                    'serving': [
                                        {
                                            'calcium': '0',
                                            'calories': '27',
                                            'carbohydrate': '0',
                                            'cholesterol': '14',
                                            'fat': '0.48',
                                            'fiber': '0',
                                            'iron': '1',
                                            'measurement_description': 'oz',
                                            'metric_serving_amount': '28.350',
                                            'metric_serving_unit': 'g',
                                            'monounsaturated_fat': '0.138',
                                            'number_of_units': '1.000',
                                            'polyunsaturated_fat': '0.110',
                                            'potassium': '86',
                                            'protein': '5.69',
                                            'saturated_fat': '0.162',
                                            'serving_description': '1 oz',
                                            'serving_id': '45188',
                                            'serving_url': 'http://www.fatsecret.com/calories-nutrition/usda/tilapia-(fish)?portionid=45188&portionamount=1.000',
                                            'sodium': '15',
                                            'sugar': '0',
                                            'vitamin_a': '0',
                                            'vitamin_c': '0'
                                        },
                                        {
                                            'calcium': '4',
                                            'calories': '435',
                                            'carbohydrate': '0',
                                            'cholesterol': '227',
                                            'fat': '7.71',
                                            'fiber': '0',
                                            'iron': '14',
                                            'measurement_description': 'lb',
                                            'metric_serving_amount': '453.600',
                                            'metric_serving_unit': 'g',
                                            'monounsaturated_fat': '2.204',
                                            'number_of_units': '1.000',
                                            'polyunsaturated_fat': '1.755',
                                            'potassium': '1370',
                                            'protein': '91.08',
                                            'saturated_fat': '2.590',
                                            'serving_description': '1 lb',
                                            'serving_id': '48115',
                                            'serving_url': 'http://www.fatsecret.com/calories-nutrition/usda/tilapia-(fish)?portionid=48115&portionamount=1.000',
                                            'sodium': '236',
                                            'sugar': '0',
                                            'vitamin_a': '0',
                                            'vitamin_c': '0'
                                        },
                                        {
                                            'calcium': '1',
                                            'calories': '96',
                                            'carbohydrate': '0',
                                            'cholesterol': '50',
                                            'fat': '1.70',
                                            'fiber': '0',
                                            'iron': '3',
                                            'measurement_description': 'g',
                                            'metric_serving_amount': '100.000',
                                            'metric_serving_unit': 'g',
                                            'monounsaturated_fat': '0.486',
                                            'number_of_units': '100.000',
                                            'polyunsaturated_fat': '0.387',
                                            'potassium': '302',
                                            'protein': '20.08',
                                            'saturated_fat': '0.571',
                                            'serving_description': '100 g',
                                            'serving_id': '60943',
                                            'serving_url': 'http://www.fatsecret.com/calories-nutrition/usda/tilapia-(fish)?portionid=60943&portionamount=100.000',
                                            'sodium': '52',
                                            'sugar': '0',
                                            'vitamin_a': '0',
                                            'vitamin_c': '0'
                                        }
                                    ]
                                }
                            }
                        }";
            JObject alimentojs = JObject.Parse(alimentoJson);

            SingleFoodGetResult result = alimentojs.SelectToken("food", false).ToObject<SingleFoodGetResult>();

            ViewBag.FatSecretSearch = result.Food_name;

            return View();
        }
        /* TODO: DESCOMENTAR METODO DE BUSCA DE ALIMENTOS
        // POST: Alimentos/Photo
        [HttpPost]
        public async Task<ActionResult> Photo(string imageData)
        {
            var caminho = Path.Combine(Server.MapPath("~/Imagens"), "foto.png");
            byte[] data = Convert.FromBase64String(imageData);

            //var json = await ClarifaiCall.Predict(data); TODO: DESCOMENTAR
            
            //System.IO.File.WriteAllText(caminhoJson, json);

            //JObject jsonObject = JObject.FromObject(JsonConvert.DeserializeObject(json)); TODO: DESCOMENTAR
            //var nomeAlimento = jsonObject["outputs"][0]["data"]["concepts"][0]["name"].ToString();
            //ViewBag.Alimento = nomeAlimento;

            //Constant consumer Key and Shared Secret for FatSecret API
            //const string consumerKey = "89a75f2dda9748d08cc87d573992fecb";
            //const string consumerSecret = "5e1b6dc6e9e84451bc265d633b9fc0de";

            //var foodSearch = new FoodSearch(consumerKey, consumerSecret);

            //var response = foodSearch.GetResponseSynchronously(new FoodSearchRequest()
            //{
            //    SearchExpression = nomeAlimento
            //});

            FatSecretAPI fatsecret = new FatSecretAPI();

            //string response = await fatsecret.buscarAlimento(nomeAlimento);

            //ViewBag.FatSecret = response.foods.food[0].food_name;

            return View();
        }*/
    }
}

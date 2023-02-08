using DT191G___Moment2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace DT191G___Moment2.Controllers
{
	public class HomeController : Controller
	{
	
		public IActionResult Index()
		{	//skapar innehåll till viewbag och viewdata
			string welcome = "Välkommen till Gröndals katthem.";
			int i = 15;

			ViewBag.welcome = welcome;
			ViewData["katter"] = i;

			return View();
		}
		[Route("/about")]
		public IActionResult About()
		{	//hämtar data från cats.json och returnerar objekt i view
            var JsonStr = System.IO.File.ReadAllText("./wwwroot/cats.json");
            var JsonObj = JsonConvert.DeserializeObject<List<CatModel>>(JsonStr);
            return View(JsonObj);
		}
        [Route("/cats")]
        public IActionResult Cats()
		{
			return View();
		}

		[HttpPost("/cats")]
		public IActionResult Cats(CatModel model)
		{
			if(ModelState.IsValid)
			{	//skapar lista och desiraliserar objekt till en lista
				var JsonStr = System.IO.File.ReadAllText("./wwwroot/cats.json");
				var JsonObj = JsonConvert.DeserializeObject<List<CatModel>>(JsonStr);

				if(JsonObj != null)
				{
					JsonObj.Add(model); //lägger till model i fil
					System.IO.File.WriteAllText("./wwwroot/cats.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));

					//skickar till about när vi lagt till katt utan felmeddelanden
					return RedirectToAction("About", "Home");
				}
			}
			return View();
		}
	}
}
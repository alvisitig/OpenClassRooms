using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OC_2018_MVC_01.Controllers
{
    public class MeteoController : Controller
    {
        // GET: Meteo
        public ActionResult Index()
        {
            return View();
        }

        public string Afficher(int jour, int mois, int annee)
        {
            return "Il fait soleil le " + jour + "/" + mois + "/" + annee;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OC_2018_MVC_01.Models;

namespace OC_2018_MVC_01.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return View("Error");
            else
            {
                //ViewData["Nom"] = id;
                ViewBag.Nom = id;
                return View();
            }
        }

        public ActionResult ListeClients()
        {
            Clients clients = new Clients();
            ViewData["Clients"] = clients.ObtenirListeClients();
            return View();
        }

        public ActionResult ChercheClient(string id)
        {
            ViewData["Nom"] = id;
            Clients clients = new Clients();
            Client client = clients.ObtenirListeClients().FirstOrDefault(c => c.Nom == id);
            if (client != null)
            {
                ViewData["Age"] = client.Age;
                return View("Trouve");
            }
            return View("NonTrouve");
        }

        /*
        // GET: Home
        public string Index(string id)
        {
            if(id==null)
            {
                id = "inconnu";
            }
            return "Hello " + id;
        }


        public string Index2()
        {
            return "Hello les contrôleurs";
        }*/
    }
}
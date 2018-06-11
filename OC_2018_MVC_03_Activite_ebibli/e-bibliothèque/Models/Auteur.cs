using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_bibliothèque.Models
{
    public class Auteur
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public static List<Auteur> Auteurs
        {
            get
            {
                List<Auteur> auteurs = new List<Auteur>();
                auteurs.Add(new Auteur() { Id = 1, Nom = "TINTIN" });
                auteurs.Add(new Auteur() { Id = 2, Nom = "HADOCK" });
                auteurs.Add(new Auteur() { Id = 3, Nom = "TOURNESOL" });

                return auteurs;
            }
        }

        public List<Auteur> GetAllAuteurs()
        {
            return Auteurs;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_bibliothèque.Models
{
    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public DateTime DateParution { get; set; }

        public Auteur AuteurLivre { get; set; }

        public Client Emprunteur { get; set; }

        public static List<Livre> Livres
        {
            get
            {
                List<Auteur> auteurs = Auteur.Auteurs;
                List<Client> clients = Client.Clients;

                List<Livre> livres = new List<Livre>();
                livres.Add(new Livre() { Titre = "Le livre premier", AuteurLivre = auteurs[0],
                    Emprunteur = clients[0] });
                livres.Add(new Livre() { Titre = "Un deuxième ouvrage", AuteurLivre = auteurs[1],
                    Emprunteur = clients[0]
                });
                livres.Add(new Livre() { Titre = "Du coté de chez trois", AuteurLivre = auteurs[2],
                    Emprunteur = clients[1]
                });
                livres.Add(new Livre() { Titre = "Les quatrièmes", AuteurLivre = auteurs[1] });
                livres.Add(new Livre() { Titre = "Cinq sur cinq", AuteurLivre = auteurs[0] });

                return livres;
            }
        }

        public List<Livre> GetAllLivres()
        {
            return Livres;
        }
    }
}
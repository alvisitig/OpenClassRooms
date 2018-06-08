using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ChoixResto.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;

        public Dal()
        {
            bdd = new BddContext();
        }

        public List<Resto> ObtientTousLesRestaurants()
        {
            return bdd.Restos.ToList();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public void CreerRestaurant(string nom, string telephone)
        {
            bdd.Restos.Add(new Resto { Nom = nom, Telephone = telephone });
            bdd.SaveChanges();
        }

        public void ModifierRestaurant(int id, string nom, string telephone)
        {
            Resto restoTrouve = bdd.Restos.FirstOrDefault(resto => resto.Id == id);
            if (restoTrouve != null)
            {
                restoTrouve.Nom = nom;
                restoTrouve.Telephone = telephone;
                bdd.SaveChanges();
            }
        }

        public bool RestaurantExiste(string nom)
        {
            Resto restoTest = bdd.Restos.FirstOrDefault(resto => resto.Nom == nom);
            return restoTest != null ? true : false;
        }

        public Utilisateur ObtenirUtilisateur(int id)
        {
            Utilisateur u = bdd.Utilisateurs.FirstOrDefault(utilisateur => utilisateur.Id == id);
            return u;          
        }

        public Utilisateur ObtenirUtilisateur(string id)
        {
            if (Type.GetTypeCode(id.GetType()) == TypeCode.Int32)
            {
                int idConvert = Convert.ToInt32(id);
                Utilisateur u = bdd.Utilisateurs.FirstOrDefault(utilisateur => utilisateur.Id == idConvert);
                return u;
            }
            else
            {
                return null;
            }
        }

        public int AjouterUtilisateur(string prenom, string motDePasse)
        {
            string motDePasseEncode = EncodeMD5(motDePasse);
            Utilisateur u =  bdd.Utilisateurs.Add(new Utilisateur { Prenom = prenom, MotDePasse = motDePasseEncode });
            bdd.SaveChanges();
            return u.Id;
        }

        private string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "ChoixResto" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }

        public Utilisateur Authentifier(string prenom, string motDePasse)
        {
            string motDePasseEncode = EncodeMD5(motDePasse);
            Utilisateur uAuth =  bdd.Utilisateurs.FirstOrDefault(u => u.Prenom == prenom && u.MotDePasse == motDePasseEncode);
            return uAuth;
        }


        public int CreerUnSondage()
        {
            Sondage sondage = bdd.Sondages.Add(new Sondage { Date = DateTime.Now });
            bdd.SaveChanges();
            return sondage.Id;
        }

        public void AjouterVote(int idSondage, int idResto, int idUtilisateur)
        {
            Vote vote = new Vote
            {
                Resto = bdd.Restos.First(r => r.Id == idResto),
                Utilisateur = bdd.Utilisateurs.First(u => u.Id == idUtilisateur)
            };
            Sondage sondage = bdd.Sondages.First(s => s.Id == idSondage);
            if (sondage.Votes == null)
                sondage.Votes = new List<Vote>();
            sondage.Votes.Add(vote);
            bdd.SaveChanges();
        }

        public List<Resultats> ObtenirLesResultats(int idSondage)
        {
            List<Resto> restaurants = ObtientTousLesRestaurants();
            List<Resultats> resultats = new List<Resultats>();
            Sondage sondage = bdd.Sondages.First(s => s.Id == idSondage);
            foreach (IGrouping<int, Vote> grouping in sondage.Votes.GroupBy(v => v.Resto.Id))
            {
                int idRestaurant = grouping.Key;
                Resto resto = restaurants.First(r => r.Id == idRestaurant);
                int nombreDeVotes = grouping.Count();
                resultats.Add(new Resultats { Nom = resto.Nom, Telephone = resto.Telephone, NombreDeVotes = nombreDeVotes });
            }
            return resultats;
        }

        public bool ADejaVote(int idSondage, string idUtilisateurString)
        {
            int id;
            if (int.TryParse(idUtilisateurString, out id))
            {
                Sondage sondage = bdd.Sondages.First(s => s.Id == idSondage);
                if (sondage.Votes == null)
                    return false;
                return sondage.Votes.Any(v => v.Utilisateur != null && v.Utilisateur.Id == id);
            }
            return false;
        }
    }
}
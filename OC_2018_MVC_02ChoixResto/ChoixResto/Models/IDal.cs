using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.Models
{
    public interface IDal : IDisposable
    {
        void CreerRestaurant(string nom, string telephone);
        List<Resto> ObtientTousLesRestaurants();
        void ModifierRestaurant(int id, string nom, string telephone);
        bool RestaurantExiste(string nom);


        Utilisateur ObtenirUtilisateur(int id);
        Utilisateur ObtenirUtilisateur(string id);
        int AjouterUtilisateur(string prenom, string motDePasse);
        Utilisateur Authentifier(string prenom, string motDePasse);

        int CreerUnSondage();
        void AjouterVote(int idSondage, int idResto, int idUtilisateur);

        List<Resultats> ObtenirLesResultats(int idSondage);

        bool ADejaVote(int idSondage, string idUtilisateurString);
    }
}

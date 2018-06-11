using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_bibliothèque.Models
{
    public class Client
    {
        public string Nom { get; set; }
        public string Email { get; set; }

        public static List<Client> Clients
        {
            get
            {
                List<Client> clients = new List<Client>();
                clients.Add(new Client() { Nom = "DUPOND", Email = "d.dupond@dom.com" });
                clients.Add(new Client() { Nom = "DUPONT", Email = "t.dupont@dom.com" });

                return clients;
            }
        }

        public List<Client> GetAllClients()
        {
            return Clients;
        }
    }
}
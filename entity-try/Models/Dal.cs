using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace entity_try.Models
{
    
    public class Dal : IDisposable
    {
        protected BddContext db;

        public Dal()
        {
            db = new BddContext();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<Client> GetClients()
        {
            return db.Clients.ToList();
        }

        public List<Client> GetClients(Predicate<Client> _predicate)
        {
            List<Client> result = new List<Client>();
            foreach (Client client in db.Clients)
            {
                if (_predicate(client))
                {
                    result.Add(client);
                }
            }

            return result;

        }
        
        public Client GetClient(int _id)
        {
            return db.Clients.FirstOrDefault(x => x.Id == _id);
        }

        public void AddClient(Client _client)
        {
            db.Clients.Add(_client);
            db.SaveChanges();
        }

        public void UpdateClient(Client _client)
        {
            Client client = GetClient(_client.Id);

            if (client != default(Client))
            {
                client.Firstname = _client.Firstname;
                client.LastName = _client.LastName;
                db.SaveChanges();
            }
            
        }

        public void DeleteClient(int _id)
        {
            Client client = GetClient(_id);

            if (client != default(Client))
            {
                db.Clients.Remove(client);
                db.SaveChanges();
            }
        }

        public void TruncateClients()
        {
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Clients;");
        }
    }
}
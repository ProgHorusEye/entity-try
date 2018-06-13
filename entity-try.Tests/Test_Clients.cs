using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using entity_try.Models;
using System.Collections.Generic;

namespace entity_try.Tests
{
    [TestClass]
    public class Test_Clients
    {

        Dal dal = new Dal();
        Client client1 = new Client() { Firstname = "Greyjoy", LastName = "Theon" };
        Client client2 = new Client() { Firstname = "Stark", LastName = "Ned" };

        [TestMethod]
        public void Test_Ajout_Clients()
        {
            dal.TruncateClients();

            int nb = dal.GetClients().Count;

            Assert.AreEqual(0, nb,"la table n'est pas vide");

            dal.AddClient(client1);

            List<Client> dbClient = dal.GetClients();

            Assert.AreEqual(1, dbClient.Count, "la Client 1 n'est pas créé");
            Assert.AreEqual(client1.Firstname, dbClient[0].Firstname);
            Assert.AreEqual(client1.LastName, dbClient[0].LastName);


            dal.TruncateClients();
        }
    }
}

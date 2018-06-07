using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DemoTests.Tests
{
    class GenerateurTest
    {
        [TestMethod]
        public void ObtenirValeur_AvecUnBouchon_Retourne5()
        {
            Mock<IGenerateur> mock = new Mock<IGenerateur>();
            mock.Setup(generateur => generateur.Valeur).Returns(5);

            Assert.AreEqual(5, mock.Object.Valeur);
        }
    }
}

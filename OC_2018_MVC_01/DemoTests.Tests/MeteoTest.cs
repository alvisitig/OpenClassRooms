using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DemoTests.Tests
{
    class MeteoTest
    {
        [TestMethod]
        public void ObtenirLaMeteoDuJour_AvecUnBouchon_RetourneSoleil()
        {
            Meteo fausseMeteo = new Meteo
            {
                Temperature = 25,
                Temps = Temps.Soleil
            };
            Mock<IDal> mock = new Mock<IDal>();
            mock.Setup(dal => dal.ObtenirLaMeteoDuJour()).Returns(fausseMeteo);

            IDal fausseDal = mock.Object;
            Meteo meteoDuJour = fausseDal.ObtenirLaMeteoDuJour();
            Assert.AreEqual(25, meteoDuJour.Temperature);
            Assert.AreEqual(Temps.Soleil, meteoDuJour.Temps);
        }
    }
}

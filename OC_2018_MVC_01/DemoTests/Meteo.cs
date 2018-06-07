using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoTests
{
    public class Meteo
    {
        public double Temperature { get; set; }
        public Temps Temps { get; set; }
    }

    public enum Temps
    {
        Soleil,
        Pluie
    }
}
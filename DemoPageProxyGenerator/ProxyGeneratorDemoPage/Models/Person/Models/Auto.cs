using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypeLite;

namespace ProxyGeneratorDemoPage.Models.Person.Models
{
    [TsClass]
    public class Auto
    {
        public string Marke { get; set; }

        public int Alter { get; set; }

        public Person Eigentuemer { get; set; }

        public Auto()
        {
            Marke = "BMW";
            Alter = 5;
            Eigentuemer = new Person();
        }
    }
}
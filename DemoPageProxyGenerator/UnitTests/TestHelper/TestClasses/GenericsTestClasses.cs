using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests.TestHelper.TestClasses
{
    public class Oberklasse<T> where T : class
    {
        public List<T> DatenklassenListe { get; set; }
        public string Abc { get; set; }
        public Infoklasse Info { get; set; }
    }

    public class Oberklasse2<T, TZ> where T : class
    {
        public List<T> DatenklassenListe { get; set; }
        public List<TZ> InfoKlasse { get; set; } 
        public string Abc { get; set; }
        public Infoklasse Info { get; set; }
    }

    public class Datenklasse
    {
        public int Id { get; set; }
        public string Textdaten { get; set; }
        public Infoklasse Info { get; set; }
    }

    public class Infoklasse
    {
        public int InfoNr { get; set; }
        public string Bemerkungen { get; set; }
    }

}

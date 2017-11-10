using System.Collections.Generic;

namespace ProxyGeneratorNgDemoPage.Models
{
    //Durch einen Bug im TypeLite aktuell auskommentiert!

   // [TsClass]
    public class Oberklasse<T> where T : class
    {
        public List<T> DatenklassenListe { get; set; }
        public ICollection<T> Test { get; set; }
        public IDictionary<string, T> Dict {get; set; }
        public string Abc { get; set; }
        public Infoklasse Info { get; set; }
    }

   // [TsClass]
    public class Datenklasse
    {
        public int Id { get; set; }
        public string Textdaten { get; set; }
        public Infoklasse Info { get; set; }
    }

   // [TsClass]
    public class Infoklasse
    {
        public int InfoNr { get; set; }
        public string Bemerkungen { get; set; }
    }
}
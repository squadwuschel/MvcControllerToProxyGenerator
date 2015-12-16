using System;
using TypeLite;

namespace ProxyGeneratorDemoPage.Models.Person.Models
{
    [TsClass]
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Erstellt { get; set; }   

        public string Passwort { get; set; }

        public bool IsAktiv { get; set; }   
    }
}
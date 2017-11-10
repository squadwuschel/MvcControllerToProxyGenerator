using System.Collections.Generic;
using TypeLite;

namespace ProxyGeneratorNgDemoPage.Models
{
    [TsClass]
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Passwort { get; set; }

        public bool IsAktiv { get; set; }

        public List<int> CounterValues { get; set; }

        public Person()
        {
            Id = 0;
            Name = "TEST Name";
            Passwort = "P@ssw0rd";
            IsAktiv = true;
            CounterValues = new List<int>() {1, 2, 3, 4, 5};
        }
    }
}
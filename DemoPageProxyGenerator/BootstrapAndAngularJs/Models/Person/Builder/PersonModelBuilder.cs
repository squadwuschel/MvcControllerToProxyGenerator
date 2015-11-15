using System.Collections.Generic;
using System.Linq;
using ProxyGeneratorDemoPage.Models.Person.Interfaces;

namespace ProxyGeneratorDemoPage.Models.Person.Builder
{
    public class PersonModelBuilder : IPersonModelBuilder
    {
        public List<Models.Person> PersonList { get; set; }

        public PersonModelBuilder()
        {
            PersonList = new List<Models.Person>();
        }

        public Models.Person GetPerson(int id)
        {
            return PersonList.FirstOrDefault(p => p.Id == id);
        }

        public int AddOrUpdatePerson(Models.Person person)
        {
            if (person.Id == 0)
            {
                if (PersonList.Count == 0)
                {
                    person.Id = 1;
                }
                else
                {
                    person.Id = PersonList.Max(p => p.Id) + 1;
                }

                PersonList.Add(person);
            }
            else
            {
                var pers = PersonList.FirstOrDefault(p => p.Id == person.Id);
                pers.IsAktiv = person.IsAktiv;
                pers.Name = person.Name;
                pers.Passwort = person.Passwort;
            }

            return person.Id;
        }

        public List<Models.Person> GetAllPersons()
        {
            return PersonList;
        }

        public List<Models.Person> SearchPerson(string name)
        {
            return PersonList.Where(p => p.Name.Contains(name)).ToList();
        }
    }
}
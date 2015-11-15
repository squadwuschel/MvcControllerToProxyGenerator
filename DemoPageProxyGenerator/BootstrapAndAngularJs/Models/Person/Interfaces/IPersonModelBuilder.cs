using System.Collections.Generic;

namespace ProxyGeneratorDemoPage.Models.Person.Interfaces
{
    public interface IPersonModelBuilder
    {
        Models.Person GetPerson(int id);
        int AddOrUpdatePerson(Models.Person person);
        List<Models.Person> GetAllPersons();
        List<Models.Person> SearchPerson(string name);
    }
}
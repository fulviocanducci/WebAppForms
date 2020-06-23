using System.Collections.Generic;

namespace WebAppForms.Models
{
    public interface IDalPerson
    {
        IEnumerable<Person> GetPerson();
        IEnumerable<Person> GetPerson(string name);
    }
}
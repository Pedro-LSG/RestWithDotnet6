using RestWithASPNET.Model;

namespace RestWithASPNET.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person Update(Person person);
        void Delete(Person person);
        Person FindByIdentifier(long identifier);
        List<Person> FindAll();
    }
}

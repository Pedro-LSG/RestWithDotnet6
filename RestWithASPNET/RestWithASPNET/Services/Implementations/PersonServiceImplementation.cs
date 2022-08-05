using RestWithASPNET.Model;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int mockIdentifier;

        public Person Create(Person person)
        {
            //TODO
            return person;
        }
        public Person Update(Person person)
        {
            //TODO
            return person;
        }

        public void Delete(Person person)
        {
            //TODO
        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < 5; i++)
            {
                Person person = MockPerson(i);
                people.Add(person);
            }
            return people;
        }


        public Person FindByIdentifier(long identifier)
        {
            return new Person 
            { 
                Id = IncrementAndGet(), 
                FirstName = "Zoro", 
                LastName = "Roronoa", 
                Address = "East Blue",
                Gear = 4
            };
        }


        #region métodos auxiliares
        private Person MockPerson(int gear)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Luffy",
                LastName = "Monkey",
                Address = "East Blue - Garbage vilage",
                Gear = gear
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref mockIdentifier);
        }
        #endregion
    }
}

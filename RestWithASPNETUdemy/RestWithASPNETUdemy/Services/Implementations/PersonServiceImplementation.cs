using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            var peoples = new List<Person>();
            for (var i = 0; i < 10; i++)
            {
                var person = MockPerson(i);
                peoples.Add(person);
            }
            return peoples;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "First Name",
                LastName = "Last Name",
                Address = "Address",
                Gender = "Gender"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = $"First Name {i}",
                LastName = $"Last Name {i}",
                Address = $"Address {i}",
                Gender = $"Address {i}"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}

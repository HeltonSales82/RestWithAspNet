using System;
using System.Collections.Generic;
using System.Threading;
using RestWithAspNet.Model;

namespace RestWithAspNet.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        //Contador responsavel por gerar um fake ID ja que nao estamos
        // acessando nenhuma base de dados
        private volatile int count;

        //metodo responsavel por criar uma nova pessoa
        // se tivessemos uma base de dados esse seria o
        //momento de persistir os dados
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> findAll()
        {
            List<Person> persons = new List<Person>();
            for (int i =0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementeAndGet(),
                FirstName = "Person Name" + i,
                LastName = "Person LastName" + i,
                Address = "Some address" + i,
                Gender = "Male"
            };
        }

        private long IncrementeAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementeAndGet(),
                FirstName = "Helton",
                LastName = "Sales",
                Address = "Sao Paulo - Interlagos - Brasil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}

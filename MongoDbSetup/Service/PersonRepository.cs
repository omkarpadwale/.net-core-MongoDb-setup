using MongoDB.Driver;
using MongoDbSetup.Data;
using MongoDbSetup.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbSetup.Service
{
    public class PersonRepository : IPersonRepository
    {
        PersonContext _context;
        public PersonRepository(string databseName)
        {
            _context = new PersonContext(databseName);

        }
        public void PostRecord(Person record)
        {
            var collection = _context.AllPersons;
            collection.InsertOne(record);
        }

        public void DeleteRecord(Guid id)
        {
            try
            {
                var collection = _context.AllPersons;
                var filter = Builders<Person>.Filter.Eq("Id", id);
                collection.DeleteOne(filter);

            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }


        public Person GetRecordById(Guid id)
        {
            try
            {
                var collection = _context.AllPersons;
                var filter = Builders<Person>.Filter.Eq("Id", id);
                return collection.Find(filter).FirstOrDefault();

            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public IEnumerable<Person> GetAllRecord()
        {
            try
            {
                var collection = _context.AllPersons.Find(_ => true).ToList();
                return collection;

            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

    }
}

using MongoDbSetup.Model;
using System;
using System.Collections.Generic;

namespace MongoDbSetup.Service
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllRecord();
        Person GetRecordById(Guid id);
        void DeleteRecord(Guid id);
        void PostRecord(Person record);

    }
}
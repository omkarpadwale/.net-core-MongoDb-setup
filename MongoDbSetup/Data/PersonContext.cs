using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbSetup.Common;
using MongoDbSetup.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbSetup.Data
{
    public class PersonContext
    {
        private readonly IMongoDatabase _database = null;
        public PersonContext(String DatabaseName)
        {
            //Add Settings.connectionString if it is not in local environment
            var client = new MongoClient();
            if (client != null)
            _database = client.GetDatabase(DatabaseName);
        }

        public IMongoCollection<Person> AllPersons
        {
            get
            {
                return _database.GetCollection<Person>("Users");
            }
        }


    }
}

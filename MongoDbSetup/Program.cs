using MongoDbSetup.Model;
using MongoDbSetup.Service;
using System;
using System.Linq;

namespace MongoDbSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonRepository personRepo = new PersonRepository("Address");
            //Add user
            personRepo.PostRecord(new Person
            {
                FirstName = "OM",
                LastName = "PADWALE",
                Address = new Address { city = "Thane", street = "MG road", zip = 123123 }
            });


            //Get All user
            var AllUsers = personRepo.GetAllRecord();
            foreach (var userVal in AllUsers)
            {
                Console.WriteLine("Id : " + userVal.Id);
                Console.WriteLine("Name : " + userVal.FirstName + " " + userVal.LastName);
                if (userVal.Address != null)
                {
                    Console.WriteLine("City: " + userVal.Address.city);
                    Console.WriteLine("Zip: " + userVal.Address.zip);

                }
            }

            //Get one user            
            var userIdToProcess = AllUsers.FirstOrDefault().Id;
            var user = personRepo.GetRecordById(userIdToProcess);

            Console.WriteLine("Id : " + user.Id);
            Console.WriteLine("Name : " + user.FirstName + " " + user.LastName);
            if (user.Address != null)
            {
                Console.WriteLine("City: " + user.Address.city);
                Console.WriteLine("zip: " + user.Address.zip);

            }
            personRepo.DeleteRecord(userIdToProcess);

            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            //Get All user
            var AllUsersVal = personRepo.GetAllRecord();
            foreach (var userVal in AllUsersVal)
            {
                Console.WriteLine("Id : " + userVal.Id);
                Console.WriteLine("Name : " + userVal.FirstName + " " + userVal.LastName);
                if (userVal.Address != null)
                {
                    Console.WriteLine("City: " + userVal.Address.city);
                    Console.WriteLine("zip: " + userVal.Address.zip);

                }
            }
        }
    }
}

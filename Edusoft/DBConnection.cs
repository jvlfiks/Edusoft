using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edusoft.Models;
using MongoDB.Driver;

namespace Edusoft
{
    class DBConnection
    {

        string connectionString = "mongodb+srv://admin_Teste:teste@cluster0.xfimp.mongodb.net/test?authSource=admin&replicaSet=atlas-7c6w1h-shard-0&readPreference=primary&appname=MongoDB%20Compass&ssl=true";

        public void insert(Student student)
        {

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Escola");
            var studentDB = database.GetCollection<Student>("alunos");

            studentDB.InsertOne(student);

        }

        public void delete(Student student)
        {

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Escola");
            var studentDB = database.GetCollection<Student>("alunos");

            studentDB.DeleteOne(d => d.Id == student.Id);

        }

        public void update(Student student)
        {

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Escola");
            var studentDB = database.GetCollection<Student>("alunos");

            studentDB.ReplaceOne(d => d.Id == student.Id, student, new UpdateOptions { IsUpsert = false });

        }

        public List<Student> get()
        {

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Escola");
            var studentDB = database.GetCollection<Student>("alunos");

            return studentDB.Find(d => true).ToList<Student>();

        }

    }
}

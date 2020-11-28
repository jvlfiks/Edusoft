using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Edusoft.Models;
using MongoDB.Driver;

namespace Edusoft
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            var client = new MongoClient("mongodb+srv://admin_Teste:teste@cluster0.xfimp.mongodb.net/test?authSource=admin&replicaSet=atlas-7c6w1h-shard-0&readPreference=primary&appname=MongoDB%20Compass&ssl=true");
            var database = client.GetDatabase("Escola");

            var studentDb = database.GetCollection<Student>("alunos");

        }
    }
}

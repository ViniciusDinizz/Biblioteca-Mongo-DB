using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace BibliotecaMongoDB
{
    internal class Book
    {
        public ObjectId Id { get; set; }
        public int Isbn { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int Yearpublication { get; set; }
        public string Authors { get; set; }

        public Book(int isbn, string title, string pcompany, int yearpublication, string authors)
        {
            Id = ObjectId.GenerateNewId();
            Isbn = isbn;
            Title = title;
            Publisher = pcompany;
            Yearpublication = yearpublication;
            Authors = authors;
        }

        public override string ToString()
        {
            return $"Titulo:{Title} \nEditora:{Publisher} \nAno de publicação:{Yearpublication} \nIsbn:{Isbn}\nAutor(es): {Authors}";
        }
    }
}

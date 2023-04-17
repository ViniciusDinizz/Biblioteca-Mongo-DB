using System.ComponentModel.Design;
using BibliotecaMongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

internal class Program
{
    private static void Main(string[] args)
    {
        MongoClient mongo = new MongoClient("mongodb://localhost:27017");
        var basededados = mongo.GetDatabase("biblioteca");
        var books = basededados.GetCollection<BsonDocument>("livros");
        var borrowed = basededados.GetCollection<BsonDocument>("emprestados");
        var initiated = basededados.GetCollection<BsonDocument>("iniciados");

        int option = 0;

        do
        {
            Console.Clear();
            option = Menu();
            switch (option)
            {
                case 1:
                    books.InsertOne(InserirLivro());
                    Console.WriteLine("Livro inserido com sucesso.");
                    break;
                case 2:
                    ViewShelf(books);
                    EmprestarLivro();
                    break;
                case 3:
                    IniciarLivro();
                    break;
                case 4:
                    LivroDevolvido();
                    break;
                case 5:
                    TerminarLivro();
                    break;
                case 6:
                    Console.Write("Até logo...");
                    Thread.Sleep(1000);
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        } while (option != 6);
        

    }

    private static void ViewShelf(IMongoCollection<BsonDocument> books)
    {
        foreach (var book in books.Find(new BsonDocument()).ToList()) 
        {
            Console.WriteLine(book.ToString() + "\n");
        }
    }

    private static void TerminarLivro()
    {
        throw new NotImplementedException();
    }

    private static void LivroDevolvido()
    {
        throw new NotImplementedException();
    }

    private static void IniciarLivro()
    {
        throw new NotImplementedException();
    }

    private static void EmprestarLivro()
    {
        throw new NotImplementedException();
    }

    private static BsonDocument InserirLivro()
    {
        Console.Write("ISBN do livro: ");
        int isbn = int.Parse(Console.ReadLine());
        Console.Write("Título do livro: ");
        string title = Console.ReadLine();
        Console.Write("Editora: ");
        string publisher = Console.ReadLine();
        Console.WriteLine("Ano publicação: ");
        int yearpublic = int.Parse(Console.ReadLine());
        Console.WriteLine("Autor: ");
        string author = Console.ReadLine();
        Book newbook = new(isbn, title, publisher, yearpublic, author);

        Console.Clear();
        Console.WriteLine(newbook.ToString());

         var newbookbson = new BsonDocument
        {
            { "ISBN", newbook.Isbn },
            { "Titulo", newbook.Title },
            { "Editora", newbook.Publisher },
            { "Ano Pulblic.", newbook.Yearpublication },
            { "Autor(es)", newbook.Authors },
        };

        return newbookbson;
    }

    public static int Menu()
        {
            Console.WriteLine("1- Inserir livro\n2- Emprestar livro\n3- Iniciar livro\n4- Livro devolvido\n5- Terminar livro\n6- Sair");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
    }
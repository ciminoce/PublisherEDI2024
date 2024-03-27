
using PublisherEDI2024.Data;
using PublisherEDI2024.Domain;
using System.Linq;

//CreateDb();
//GetAuthors();
//AddAuthor();
//GetAuthors();
//AddSomeBooks();
GetBooks();

void GetBooks()
{
    using var context = new PublisherDbContext();
    //var query = context.Books;
    //var booksList = query.ToList();
    foreach (var book in context.Books.ToList())
    {
        Console.WriteLine($"{book.Title}");
    }
}

void AddSomeBooks()
{
    var b1 = new Book
    {
        Title = "I, Robot",
        PublishedDate = new DateOnly(1960, 10, 2),
        Price = 10.0m,
        AuthorId = 1
    };
    var b2 = new Book
    {
        Title = "Foundation",
        PublishedDate = new DateOnly(1966, 11, 12),
        Price = 10.0m,
        AuthorId = 1
    };
    var b3 = new Book
    {
        Title = "Rama Reaveled",
        PublishedDate = new DateOnly(1980, 10, 2),
        Price = 10.0m,
        AuthorId = 2
    };

    var booksList = new List<Book>()
    {
        b1,b2, b3
    };
    using var context = new PublisherDbContext();
    //context.Books.AddRange(booksList);
    context.AddRange(booksList);
    context.SaveChanges();
    Console.WriteLine("Books added!!!");

}

void AddAuthor()
{
    using var context = new PublisherDbContext();
    var author = new Author
    {
        FirstName = "Ray",
        LastName = "Bradbury"
    };
    context.Authors.Add(author);
    context.SaveChanges();
    Console.WriteLine("Author added!!!");
}

void GetAuthors()
{
    using var context = new PublisherDbContext();
    var authorList = context.Authors.ToList();
    foreach (var author in authorList)
    {
        Console.WriteLine($"{author.FirstName} {author.LastName}");
    }
}

void CreateDb()
{
    using var context = new PublisherDbContext();
    if (!context.Database.CanConnect())
    {
        context.Database.EnsureCreated();
        Console.WriteLine("DataBase created!!!");
    }
    else
    {
        Console.WriteLine("Database already exist!!!");
    }
}
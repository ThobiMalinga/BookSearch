using BookSearchApp.Models;
using BookSearchApp.Repositories;
using BookSearchApp.Services;

var repository = new BookRepository();      
var bookService = new BookService(repository);

while (true)                                
{
    try                                     
    {
        Console.WriteLine();
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Search book by name");
        Console.WriteLine("2. Get book by ID");
        Console.WriteLine("3. Exit");      

        string choice = Console.ReadLine() ?? string.Empty;

        if (choice == "3")                  
        {
            Console.WriteLine("Goodbye!");
            break;                          
        }

        if (choice == "2")
        {
            Console.WriteLine("Enter book ID:");

            string idInput = Console.ReadLine() ?? string.Empty;

            var result = bookService.GetBookById(idInput);

            if (result.Status == LookupStatus.Found)
            {
                PrintBook(result.Book!);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        else if (choice == "1")            
        {
            Console.WriteLine("Enter book name to search:");

            string searchTerm = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.WriteLine(" Please enter a book name.");
            }
            else
            {
                var results = bookService.SearchBooksByName(searchTerm);

                if (results.Any())
                {
                    foreach (var book in results)
                    {
                        PrintBook(book);
                    }
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
        }
        else                               
        {
            Console.WriteLine("Invalid option. Please choose 1, 2, or 3.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("An unexpected error occurred. Please try again.");
        Console.Error.WriteLine($"Error details: {ex.Message}");
    }
}

static void PrintBook(Book book)           
{
    //String literal interpolation
    Console.WriteLine("----------------------------");
    Console.WriteLine($"Id: {book.Id}");
    Console.WriteLine($"Name: {book.Name}");
    Console.WriteLine($"Description: {book.Description}");
    Console.WriteLine($"Published Date: {book.PublishedDate.ToShortDateString()}");
}
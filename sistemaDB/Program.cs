using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;
using SistemaDB.Models;

namespace mysqlefcore
{
  class Program
  {
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true);

        var configuration = builder.Build();
        InsertData(configuration);
        PrintData(configuration);
    }

    private static void InsertData(IConfiguration configuration)
    {
      using(var context = new ERPDBContext(configuration))
      {
        // Creates the database if not exists
        context.Database.EnsureCreated();

        // Adds a publisher
        var publisher = new ClientSystem()
        {
          Name = "Ricardo Alves Santos"
        };

        context.TableClientSystem.Add(publisher);

        // Adds some books
        context.TableClientContract.Add(new ClientContract
        {
            Name = "Academia Completa",
            ClientSystem = publisher
        });

        // Saves changes
        context.SaveChanges();
      }
    }

    private static void PrintData(IConfiguration configuration)
    {
      // Gets and prints all books in database
      using (var context = new ERPDBContext(configuration))
      {
        var clientes = context.TableClientSystem
          .Include(p => p.ClientContracts);
        foreach(var book in clientes)
        {
          var data = new StringBuilder();
          data.AppendLine($"ISBN: {book.Name}");
          data.AppendLine($"Title: {book.ClientContracts.First().Name}");
          Console.WriteLine(data.ToString());
        }
      }
    }
  }
}
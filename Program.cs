using System;
using System.ComponentModel.DataAnnotations;
using ConcertCrudApp;

class Program
{
    static void Main(string[] args)
    {
        Concert concert1 = new Concert();

        // Use a Switch Case to provide menu of different CRUD operations
        Console.WriteLine("Enter your menu option");
        string operationName = Console.ReadLine();

        switch (operationName)
        {
            case "Create":
                concert1.CreateConcert();
                break;
            case "Update":
                concert1.UpdateConcert();
                break;
            case "Read":
                concert1.GetConcert();
                break;
            case "Delete":
                concert1.DeleteConcert();
                break;
            default:
                throw new NotImplementedException("Enter a valid option Create/Read/Update/Delete");

        }

        // Get user input for Create

        // concert1.CreateConcert("Concert 1");
        // concert1.UpdateConcert("Concert 2");
        // concert1.GetConcert("Concert 2");
        // concert1.DeleteConcert("Concert 2");
    }
}


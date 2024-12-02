namespace ConcertCrudApp;

public class Concert
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Venue { get; set; }
    public string DateTime { get; set; }
    public int Capacity { get; set; }

    // public List<Performer> { get; set; }
    
    public void CreateConcert(){
        // Collect user inputs
        Console.WriteLine("Enter the concert name:");
        string concertName = Console.ReadLine();
        Console.WriteLine("Enter the concert venue:");
        string concertVenue = Console.ReadLine();
        Console.WriteLine("Enter the concert time:");
        string concertTime = Console.ReadLine();
        Console.WriteLine("Enter the concert cepacity");
        string concertCepacity = Console.ReadLine();

        // Write to file

        Console.WriteLine($" Created concert: {concertName} {concertVenue} {concertTime} {concertCepacity}");
    }

    public void GetConcert(){
        Console.WriteLine("Enter the concert name:");
        string concertName = Console.ReadLine();

        // Read concerts from File

        // Check if the concert name exists

        // Print the concert details to the user
        Console.WriteLine($" Found concert: {concertName}");
    }

    public void UpdateConcert(){
        Console.WriteLine("Enter the new name:");
        string concertName = Console.ReadLine();
        Console.WriteLine("Enter the new concert venue:");
        string concertVenue = Console.ReadLine();
        Console.WriteLine("Enter the new concert time:");
        string concertTime = Console.ReadLine();
        Console.WriteLine("Enter the new concert cepacity:");
        string concertCepacity = Console.ReadLine();

        Console.WriteLine($" Updated concert: {concertName} {concertVenue} {concertTime} {concertCepacity}");
    
    }

    public void DeleteConcert(){
        Console.WriteLine("Enter the name of the concert you want to delete:");
        string concertName = Console.ReadLine();
        Console.WriteLine($" Deleted concert: {concertName}");
    }

}
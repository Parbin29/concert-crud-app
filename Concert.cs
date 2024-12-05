namespace ConcertCrudApp;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

public class Concert
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Venue { get; set; }
    public string DateTime { get; set; }
    public Int32 Capacity { get; set; }

    // public List<Performer> { get; set; }

    public List<Concert> ReadConcertsFromFile()
    {
        try
        {
            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filePath = Path.Combine(docPath, "WriteFile.txt");

            // Open the file to read from.
            string[] lines = File.ReadAllLines(filePath);
            var foundConcert = string.Empty;
            var concerts = new List<Concert> { };
            foreach (string s in lines)
            {
                // Split the line with comma and find the concert name.
                var name = s.Split(",")[0];
                var venue = s.Split(",")[1];
                var time = s.Split(",")[2];
                var capacity = s.Split(",")[3];

                var concert = new Concert() { Name = name, Venue = venue, DateTime = time, Capacity = Int32.Parse(capacity) };
                concerts.Add(concert);
            }

            return concerts;
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
            return new List<Concert> { };
        }
    }
    public Concert ReadConcert(string name)
    {
        try
        {
            // Read all concerts from file
            var concerts = ReadConcertsFromFile();
            var foundConcert = new Concert() { };
            foreach (Concert concert in concerts)
            {
                // if the concert name matches existsing concerts update foundConcert.
                if (concert.Name.Equals(name))
                {
                    foundConcert = concert;
                }
            }

            return foundConcert;
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
            return new Concert { };
        }
    }
    public void UpdateConcertToFile(string name, string updated)
    {
        try
        {
            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filePath = Path.Combine(docPath, "WriteFile.txt");

            // Open the file to read from.
            string[] lines = File.ReadAllLines(filePath);
            int index = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                // Split the line with comma and find the concert name.
                var concertName = lines[i].Split(",")[0];
                // if the concert name matches existsing concerts update foundConcert.
                if (concertName.Equals(name))
                {
                    index = i;
                }
            }

            lines[index] = updated;

            // replace the etxt in the file "WriteFile.txt".
            File.WriteAllLines(filePath, lines, Encoding.UTF8);

        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
    public void DeleteConcertFromFile(string name)
    {
        try
        {
            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(docPath, "WriteFile.txt");


            // Open the file to read from.
            string[] lines = File.ReadAllLines(filePath);

            // List to store updated lines
            List<string> updatedFileText = new List<string>();

            var isDeleted = false;

            // handle if there is only one line in the file
            if (lines.Length == 1)
            {

                // Split the line with a comma and find the concert name.
                var parts = lines[0].Split(",");
                if (parts.Length > 0)
                {
                    string concertName = parts[0].Trim();

                    // Add the line to updatedFileText if the concert name doesn't match
                    if (concertName.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        isDeleted = true;
                    }
                }

            }

            if (lines.Length > 1)
            {

                for (int i = 0; i < lines.Length; i++)
                {
                    // Split the line with a comma and find the concert name.
                    var parts = lines[i].Split(",");
                    if (parts.Length > 0)
                    {
                        string concertName = parts[0].Trim();

                        // Add the line to updatedFileText if the concert name doesn't match
                        if (!concertName.Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            updatedFileText.Add(lines[i]);
                        }
                        else
                        {
                            isDeleted = true;
                        }
                    }
                }
            }

            // Replace the file with the new content
            if (isDeleted)
            {
                File.WriteAllLines(filePath, updatedFileText);

                Console.WriteLine($"Concert : {name} deleted successfully! Press Enter to continue.");
            }
            else
            {
                Console.WriteLine($"The concert name {name} does not exist.");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"The concert name {name} does not exist.");
            Console.WriteLine(e.Message);
        }
    }

    public void WriteConcertToFile(string concert)
    {
        // Create a string with a line of text.
        string text = concert + Environment.NewLine;

        // Set a variable to the Documents path.
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Write the text to a new file named "WriteFile.txt".
        File.AppendAllText(Path.Combine(docPath, "WriteFile.txt"), text);
    }

    public void CreateConcert()
    {
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
        var cocnertsData = $"{concertName}, {concertVenue}, {concertTime}, {concertCepacity}";
        WriteConcertToFile(cocnertsData);

        Console.WriteLine($" Created concert: {concertName} {concertVenue} {concertTime} {concertCepacity}");
        CreateConcert();
    }

    public void GetConcert()
    {
        Console.WriteLine("Enter the concert name:");
        string concertName = Console.ReadLine();

        // Read concerts from File
        Concert foundConcert = ReadConcert(concertName);
        // check if not empty
        Console.WriteLine($"Name = {foundConcert.Name}, Venue = {foundConcert.Venue}, Time = {foundConcert.DateTime}, Capacity = {foundConcert.Capacity}");

    }

    public void UpdateConcert()
    {
        Console.WriteLine("Enter the concert name you want to update:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the new concert name:");
        string concertName = Console.ReadLine();
        Console.WriteLine("Enter the new concert venue:");
        string concertVenue = Console.ReadLine();
        Console.WriteLine("Enter the new concert time:");
        string concertTime = Console.ReadLine();
        Console.WriteLine("Enter the new concert cepacity:");
        string concertCepacity = Console.ReadLine();

        // Find the concert from the file and update it
        var old = ReadConcert(name);

        if (!old.Name.Equals(concertName))
        {
            old.Name = concertName;
        }
        if (!old.Venue.Equals(concertVenue))
        {
            old.Venue = concertVenue;
        }
        if (!old.DateTime.Equals(concertTime))
        {
            old.DateTime = concertTime;
        }
        if (!old.Capacity.Equals(concertCepacity))
        {
            old.Capacity = Int32.Parse(concertCepacity);
        }

        var cocnertData = $"{concertName}, {concertVenue}, {concertTime}, {concertCepacity}";

        UpdateConcertToFile(name, cocnertData);

        Console.WriteLine($"Name = {old.Name}, Venue = {old.Venue}, Time = {old.DateTime}, Capacity = {old.Capacity}");
    }

    public void DeleteConcert()
    {
        Console.WriteLine("Enter the name of the concert you want to delete:");
        string concertName = Console.ReadLine();
        if (concertName != null)
        {
            DeleteConcertFromFile(concertName);
        }
        else
        {
            Console.WriteLine($"Concert : {concertName} not found. Press Enter to continue.");
        }
        DeleteConcert();
    }

}


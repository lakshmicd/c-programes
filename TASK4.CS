using System;
using System.IO;

class FileHandlingDemo
{
    static void Main(string[] args)
    {
        string fileName = "favorites.txt";

        Console.WriteLine("Enter your 5 favorite colors:");
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"Color {i}: ");
                string color = Console.ReadLine();
                sw.WriteLine(color);
            }
        }

        Console.WriteLine("\nYour favorite colors are:");
        using (StreamReader sr = new StreamReader(fileName))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}





//2. Program

using System;
using System.Threading.Tasks;

class AsyncDemo
{
    static async Task DownloadFileAsync()
    {
        Console.WriteLine("Downloading file...");
        await Task.Delay(5000); 
        Console.WriteLine("Download complete!");
    }

    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting download...");
        await DownloadFileAsync(); 
    }
}

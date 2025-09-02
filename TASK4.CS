//using System;
//using System.IO;

//class FileHandlingDemo
//{
//    static void Main(string[] args)
//    {
//        string fileName = "favorites.txt";

//        // Write 5 colors into the file
//        Console.WriteLine("Enter your 5 favorite colors:");
//        using (StreamWriter sw = new StreamWriter(fileName))
//        {
//            for (int i = 1; i <= 5; i++)
//            {
//                Console.Write($"Color {i}: ");
//                string color = Console.ReadLine();
//                sw.WriteLine(color);
//            }
//        }

//        // Read and display colors from the file
//        Console.WriteLine("\nYour favorite colors are:");
//        using (StreamReader sr = new StreamReader(fileName))
//        {
//            string line;
//            while ((line = sr.ReadLine()) != null)
//            {
//                Console.WriteLine(line);
//            }
//        }
//    }
//}


using System;
using System.Threading.Tasks;

class AsyncDemo
{
    // Async method to simulate download
    static async Task DownloadFileAsync()
    {
        Console.WriteLine("Downloading file...");
        await Task.Delay(5000); // wait 5 seconds
        Console.WriteLine("Download complete!");
    }

    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting download...");
        await DownloadFileAsync(); // call async method
    }
}

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        List<List<List<int>>> meterReadings = new List<List<List<int>>>()
        {
            new List<List<int>> { new List<int>{10}, new List<int>{20}, new List<int>{30} }, 
            new List<List<int>> { new List<int>{11}, new List<int>{21}, new List<int>{31} }, 
            new List<List<int>> { new List<int>{12}, new List<int>{22}, new List<int>{32} }, 
            new List<List<int>> { new List<int>{13}, new List<int>{23}, new List<int>{33} }, 
            new List<List<int>> { new List<int>{14}, new List<int>{24}, new List<int>{34} }, 
            new List<List<int>> { new List<int>{15}, new List<int>{25}, new List<int>{35} },
            new List<List<int>> { new List<int>{16}, new List<int>{26}, new List<int>{36} }  
        };

        Console.WriteLine("Night reading of Day 3: " + meterReadings[2][2][0]);



        var areaData = new Dictionary<string, Dictionary<string, List<int>>>
        {
            ["Area1"] = new Dictionary<string, List<int>>
            {
                ["House1"] = new List<int> { 100, 200, 300, 400, 500, 600, 700 },
                ["House2"] = new List<int> { 110, 210, 310, 410, 510, 610, 710 }
            }
        };

        Console.WriteLine("\nReadings of House1 in Area1:");
        foreach (var r in areaData["Area1"]["House1"])
            Console.Write(r + " ");
        Console.WriteLine();

        var metersInArea = new Dictionary<string, List<string>>
        {
            ["Area1"] = new List<string> { "MeterA", "MeterB", "MeterC" }
        };

        Console.WriteLine("\nMeters in Area1:");
        foreach (var m in metersInArea["Area1"])
            Console.WriteLine(m);

        var complaints = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string>
            {
                {"HouseNum", "H101"}, {"Issue", "Power Cut"}, {"Date", "2025-08-25"}
            },
            new Dictionary<string, string>
            {
                {"MeterNum", "M202"}, {"Issue", "Billing Error"}, {"Date", "2025-08-24"}
            }
        };

        Console.WriteLine("\nComplaints:");
        foreach (var c in complaints)
        {
            foreach (var kvp in c)
                Console.Write(kvp.Key + ": " + kvp.Value + " | ");
            Console.WriteLine();
        }
    }
}




//program2


using System;
using System.Collections.Generic;

enum MeterStatus { Active, Inactive, Fault }

struct Reading
{
    public DateTime Date;
    public int Units;
}

abstract class Notifier
{
    public abstract void SendMessage(string msg);
}

class SmsNotifier : Notifier
{
    public override void SendMessage(string msg) => Console.WriteLine("SMS: " + msg);
}

class EmailNotifier : Notifier
{
    public override void SendMessage(string msg) => Console.WriteLine("Email: " + msg);
}

static class Tariff
{
    public static double RatePerUnit = 5.0;
}

sealed class BillCalculator
{
    public double CalculateBill(int units) => units * Tariff.RatePerUnit;
}

partial class Customer
{
    public string Name { get; set; }
    public string? Email { get; set; }
}
partial class Customer
{
    public string? Phone { get; set; }
}

class Meter
{
    public string MeterId { get; set; }
    public MeterStatus Status { get; set; }

    public event Action<Reading>? OnNewReading;

    public List<Reading> readings = new List<Reading>();

    public void AddReading(Reading r)
    {
        readings.Add(r);
        OnNewReading?.Invoke(r);  
    }

    public class ReadingHistory
    {
        public static void ShowHistory(List<Reading> readings)
        {
            Console.WriteLine("Reading History:");
            foreach (var r in readings)
                Console.WriteLine($"{r.Date.ToShortDateString()} - {r.Units} units");
        }
    }
}

class Program
{
    static void Main()
    {
        Customer cust1 = new Customer { Name = "John", Email = null, Phone = "9999999999" };
        string contact = cust1.Email ?? cust1.Phone;
        Console.WriteLine("Contact for " + cust1.Name + ": " + contact);

        Notifier notifier = cust1.Email == null ? new SmsNotifier() : new EmailNotifier();

        Meter meter = new Meter { MeterId = "M001", Status = MeterStatus.Active };

        meter.OnNewReading += (Reading r) =>
        {
            notifier.SendMessage($"New Reading: {r.Units} units on {r.Date.ToShortDateString()}");
        };

        meter.AddReading(new Reading { Date = DateTime.Now, Units = 120 });
        meter.AddReading(new Reading { Date = DateTime.Now.AddDays(1), Units = 150 });

        Meter.ReadingHistory.ShowHistory(meter.readings);

        BillCalculator billCalc = new BillCalculator();
        double bill = billCalc.CalculateBill(270);
        Console.WriteLine("Bill Generated: Rs. " + bill);
    }
}


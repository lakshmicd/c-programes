using System;

class SmartMeter
{
    public int MeterId { get; set; }
    public string CustomerName { get; set; }
}

class ResidentialMeter : SmartMeter
{
    public string HouseType { get; set; }
}

class CommercialMeter : SmartMeter
{
    public string BusinessType { get; set; }
}

class Program
{
    static void Main()
    {
        ResidentialMeter res = new ResidentialMeter();
        Console.WriteLine("Enter Residential Meter Details:");
        Console.Write("Meter ID: ");
        res.MeterId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Customer Name: ");
        res.CustomerName = Console.ReadLine();
        Console.Write("House Type: ");
        res.HouseType = Console.ReadLine();

        CommercialMeter com = new CommercialMeter();
        Console.WriteLine("\nEnter Commercial Meter Details:");
        Console.Write("Meter ID: ");
        com.MeterId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Customer Name: ");
        com.CustomerName = Console.ReadLine();
        Console.Write("Business Type: ");
        com.BusinessType = Console.ReadLine();

        
        Console.WriteLine($"Residential Meter -> ID: {res.MeterId}, Name: {res.CustomerName}, HouseType: {res.HouseType}");
        Console.WriteLine($"Commercial Meter -> ID: {com.MeterId}, Name: {com.CustomerName}, BusinessType: {com.BusinessType}");
    }
}




//program2
using System;

class SmartMeterAccount
{
    private int balance;

    public void Recharge(int amount)
    {
        balance += amount;
        Console.WriteLine($"Balance after recharge: {balance}");
    }

    public void Consume(int amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Balance after consumption: {balance}");
        }
        else
        {
            Console.WriteLine("Insufficient balance");
        }
    }
}

class Program
{
    static void Main()
    {
        SmartMeterAccount account = new SmartMeterAccount();

        account.Recharge(500);
        account.Consume(200);
        account.Consume(400);
    }
}






//program3
using System;

abstract class MeterReading
{
    public int Units { get; set; }
    public abstract void CalculateBill();
}

class ResidentialReading : MeterReading
{
    public override void CalculateBill()
    {
        int bill = Units * 5;
        Console.WriteLine($"Residential Bill = {bill}");
    }
}

class CommercialReading : MeterReading
{
    public override void CalculateBill()
    {
        int bill = Units * 8;
        Console.WriteLine($"Commercial Bill = {bill}");
    }
}

class Program
{
    static void Main()
    {
        // Residential Reading
        ResidentialReading res = new ResidentialReading();
        res.Units = 100;
        res.CalculateBill();

        // Commercial Reading
        CommercialReading com = new CommercialReading();
        com.Units = 100;
        com.CalculateBill();
    }
}


//program1
using System;

class SmartMeter
{
    static void Main()
    {
        Console.Write("Enter units consumed: ");
        int units = Convert.ToInt32(Console.ReadLine());
        int bill = 0;

        if (units <= 100)
            bill = units * 5;
        else if (units <= 200)
            bill = (100 * 5) + (units - 100) * 7;
        else
            bill = (100 * 5) + (100 * 7) + (units - 200) * 10;

        Console.WriteLine("Total electricity bill: $" + bill);
    }
}



//program2

using System;

class Customer
{
    public int CustomerID { get; set; }
    public string Name { get; set; }
    public int UnitsConsumed { get; set; }

    public Customer(int id, string name, int units)
    {
        CustomerID = id;
        Name = name;
        UnitsConsumed = units;
    }

    public void ShowBill()
    {
        int totalBill = UnitsConsumed * 5;
        Console.WriteLine($"Customer: {Name} (ID: {CustomerID})");
        Console.WriteLine($"Units Consumed: {UnitsConsumed}");
        Console.WriteLine($"Total Bill: ${totalBill}");
    }
}

class CustomerProgram
{
    static void Main()
    {
        Console.Write("Enter Customer ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Units Consumed: ");
        int units = Convert.ToInt32(Console.ReadLine());

        Customer customer = new Customer(id, name, units);
        customer.ShowBill();
    }
}


//program3

using System;

class WeeklyConsumption
{
    enum Days { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

    public static void Calculate(int[] units)
    {
        int total = 0;
        int maxUnits = units[0];
        int maxDayIndex = 0;

        for (int i = 0; i < units.Length; i++)
        {
            total += units[i];
            if (units[i] > maxUnits)
            {
                maxUnits = units[i];
                maxDayIndex = i;
            }
        }

        double average = (double)total / units.Length;

        Console.WriteLine($"Total units: {total}");
        Console.WriteLine($"Average units/day: {average:F2}");
        Console.WriteLine($"Highest consumption: {((Days)maxDayIndex)} ({maxUnits} units)");
    }
}

class WeeklyProgram
{
    static void Main()
    {
        int[] weeklyUnits = new int[7];
        Console.WriteLine("Enter units for each day (Mon-Sun):");
        for (int i = 0; i < weeklyUnits.Length; i++)
        {
            weeklyUnits[i] = Convert.ToInt32(Console.ReadLine());
        }

        WeeklyConsumption.Calculate(weeklyUnits);
    }
}

void Main()
{
	var path = @"C:\Projects\AOC\Advent-of-Code-2019\Day_01\input.txt";
	var masses = new List<int>();
	var line = string.Empty;
	var file = new System.IO.StreamReader(path);
	while ((line = file.ReadLine()) != null)
	{
		if (int.TryParse(line, out var mass)) masses.Add(mass);
	}
	
	// Part One
	PartOne.Solve(masses).Dump();
	
	// Part Two
	PartTwo.Solve(masses).Dump();
}

public static class FuelCounterUpper
{
	public static int Calculate(int mass)
	{
		var fuel = mass / 3 - 2;
		return fuel;
	}
}

public static class PartOne
{
	public static int Solve(List<int> masses)
	{
		var totalFuelNeeded = 0;
		
		foreach (var mass in masses)
		{		
			var fuelNeeded = FuelCounterUpper.Calculate(mass);
			
			totalFuelNeeded += fuelNeeded;
		}
		
		return totalFuelNeeded;
	}
}

public static class PartTwo 
{
	public static int Solve(List<int> masses)
	{
		var totalFuelNeeded = 0;

		foreach (var mass in masses)
		{
			var fuelNeeded = GetTotalFuel(mass);

			totalFuelNeeded += fuelNeeded;
		}

		return totalFuelNeeded;
	}
	
	public static int GetTotalFuel(int mass)
	{
		var total = FuelCounterUpper.Calculate(mass);
		var additionalFuel = FuelCounterUpper.Calculate(total);
		while (additionalFuel > 0)
		{
			total += additionalFuel;
			additionalFuel = FuelCounterUpper.Calculate(additionalFuel);
		}
		
		return total;
	}
}
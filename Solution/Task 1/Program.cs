using System;

class Program
{
    static void Main(string[] args)
    {
        var factories = GetFactories();
        var units = GetUnits();
        var tanks = GetTanks();

        Console.WriteLine($"Количество резервуаров: {tanks.Length}, установок: {units.Length}");

        var foundUnit = FindUnit(units, tanks, "Резервуар 2");
        var factory = FindFactory(factories, foundUnit);

        if (foundUnit != null && factory != null)
        {
            Console.WriteLine($"Резервуар 2 принадлежит установке {foundUnit.Name} и заводу {factory.Name}");
        }

        var totalVolume = GetTotalVolume(tanks);
        Console.WriteLine($"Общий объем резервуаров: {totalVolume}");

        Console.WriteLine("\nСписок резервуаров с названиями установок и заводов:");
        foreach (var tank in tanks)
        {
            var unit = Array.Find(units, u => u.Id == tank.UnitId);
            var fac = Array.Find(factories, f => f.Id == unit.FactoryId);
            Console.WriteLine($"{tank.Name} — {unit.Name} — {fac.Name}");
        }

        Console.WriteLine("\nВведите имя резервуара для поиска:");
        var searchName = Console.ReadLine();
        var searchTank = Array.Find(tanks, t => t.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
        if (searchTank != null)
        {
            var unit = FindUnit(units, tanks, searchTank.Name);
            var fac = FindFactory(factories, unit);
            Console.WriteLine($"Найден: {searchTank.Name}, Установка: {unit.Name}, Завод: {fac.Name}");
        }
        else
        {
            Console.WriteLine("Резервуар не найден.");
        }
    }

    public static Tank[] GetTanks()
    {
        return new Tank[]
        {
            new Tank(1, "Резервуар 1", "Надземный - вертикальный", 1500, 2000, 1),
            new Tank(2, "Резервуар 2", "Надземный - горизонтальный", 2500, 3000, 1),
            new Tank(3, "Дополнительный резервуар 24", "Надземный - горизонтальный", 3000, 3000, 2),
            new Tank(4, "Резервуар 35", "Надземный - вертикальный", 3000, 3000, 2),
            new Tank(5, "Резервуар 47", "Подземный - двустенный", 4000, 5000, 2),
            new Tank(6, "Резервуар 256", "Подводный", 500, 500, 3)
        };
    }

    public static Unit[] GetUnits()
    {
        return new Unit[]
        {
            new Unit(1, "ГФУ-2", "Газофракционирующая установка", 1),
            new Unit(2, "АВТ-6", "Атмосферно-вакуумная трубчатка", 1),
            new Unit(3, "АВТ-10", "Атмосферно-вакуумная трубчатка", 2)
        };
    }

    public static Factory[] GetFactories()
    {
        return new Factory[]
        {
            new Factory(1, "НПЗ№1", "Первый нефтеперерабатывающий завод"),
            new Factory(2, "НПЗ№2", "Второй нефтеперерабатывающий завод")
        };
    }

    public static Unit FindUnit(Unit[] units, Tank[] tanks, string tankName)
    {
        var tank = Array.Find(tanks, t => t.Name == tankName);
        if (tank == null) return null;
        return Array.Find(units, u => u.Id == tank.UnitId);
    }

    public static Factory FindFactory(Factory[] factories, Unit unit)
    {
        if (unit == null) return null;
        return Array.Find(factories, f => f.Id == unit.FactoryId);
    }

    public static int GetTotalVolume(Tank[] tanks)
    {
        int total = 0;
        foreach (var tank in tanks)
        {
            total += tank.Volume;
        }
        return total;
    }
}

public class Factory
{
    public int Id;
    public string Name;
    public string Description;

    public Factory(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}

public class Unit
{
    public int Id;
    public string Name;
    public string Description;
    public int FactoryId;

    public Unit(int id, string name, string description, int factoryId)
    {
        Id = id;
        Name = name;
        Description = description;
        FactoryId = factoryId;
    }
}

public class Tank
{
    public int Id;
    public string Name;
    public string Description;
    public int Volume;
    public int MaxVolume;
    public int UnitId;

    public Tank(int id, string name, string description, int volume, int maxVolume, int unitId)
    {
        Id = id;
        Name = name;
        Description = description;
        Volume = volume;
        MaxVolume = maxVolume;
        UnitId = unitId;
    }
}

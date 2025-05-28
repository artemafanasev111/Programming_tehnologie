using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Models;

class Program
{
    static void Main(string[] args)
    {
        var factories = LoadFromJson<Factory>("factories.json");
        var units = LoadFromJson<Unit>("units.json");
        var tanks = LoadFromJson<Tank>("tanks.json");

        Console.WriteLine($"Количество резервуаров: {tanks.Length}, установок: {units.Length}");

        var foundUnit = FindUnit(units, tanks, "Резервуар 2");
        var factory = FindFactory(factories, foundUnit);

        Console.WriteLine($"Резервуар 2 принадлежит установке {foundUnit?.Name} и заводу {factory?.Name}");

        var totalVolume = GetTotalVolume(tanks);
        Console.WriteLine($"Общий объем резервуаров: {totalVolume}");

        Console.WriteLine("\nСписок всех резервуаров с установками и заводами:");
        foreach (var tank in tanks)
        {
            var unit = units.FirstOrDefault(u => u.Id == tank.UnitId);
            var fac = factories.FirstOrDefault(f => f.Id == unit?.FactoryId);
            Console.WriteLine($"{tank.Name} -> {unit?.Name} -> {fac?.Name}");
        }

        Console.Write("Введите название резервуара для поиска: ");
        string? searchName = Console.ReadLine();
        var result = tanks.FirstOrDefault(t => t.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine(result != null ? $"Найден: {result.Name}, объем: {result.Volume}" : "Не найден");
    }

    public static T[] LoadFromJson<T>(string path)
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<T[]>(json) ?? Array.Empty<T>();

    }

    public static Unit? FindUnit(Unit[] units, Tank[] tanks, string tankName)

    {
        var tank = tanks.FirstOrDefault(t => t.Name == tankName);
        return units.FirstOrDefault(u => u.Id == tank?.UnitId);
    }

    public static Factory? FindFactory(Factory[] factories, Unit? unit)

    {
        return factories.FirstOrDefault(f => f.Id == unit?.FactoryId);
    }

    public static int GetTotalVolume(Tank[] tanks)
    {
        return tanks.Sum(t => t.Volume); // метод-синтаксис LINQ
        // return (from t in tanks select t.Volume).Sum(); // запросный синтаксис LINQ
    }
}
